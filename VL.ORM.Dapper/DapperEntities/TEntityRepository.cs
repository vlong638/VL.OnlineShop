using Dapper;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using static Dapper.Contrib.Extensions.SqlMapperExtensions;

namespace VL.ORM.Dapper.DapperEntities
{
    /// <inheritdoc />
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private static ConcurrentDictionary<Type, TypeMapper> typecache = new ConcurrentDictionary<Type, TypeMapper>();
        private static ConcurrentDictionary<Type, string> typeConcurrentUpdateSqlcache = new ConcurrentDictionary<Type, string>();

        /// <summary>
        /// 数据库连接
        /// </summary>
        protected IDbConnection connection;

        /// <inheritdoc />
        public Repository(IDbConnection connection)
        {
            this.connection = connection;
        }

        /// <inheritdoc />
        public bool Delete(TEntity entity)
        {
            return connection.Delete(entity);
        }

        /// <inheritdoc />
        public TEntity GetById(long id)
        {
            return connection.Get<TEntity>(id);
        }

        /// <inheritdoc />
        public long Insert(TEntity entity)
        {
            return connection.Insert(entity);
        }

        /// <inheritdoc />
        public long Insert(TEntity[] entities)
        {
            return connection.Insert(entities);
        }

        /// <inheritdoc />
        public bool Update(TEntity entity)
        {
            return connection.Update(entity);
        }


        ///// <inheritdoc />
        //public bool ConcurrentUpdate(TEntity entity)
        //{
        //    if (entity is IRowVersion)
        //    {
        //        var typeMapper = GetEntityMapper();
        //        var updateSql = GetConcurrentUpdateSql(typeMapper);
        //        return connection.Execute(updateSql, entity) > 0;
        //    }
        //    else
        //    {
        //        return Update(entity);
        //    }
        //}

        ///// <inheritdoc />
        //public bool Delete(long id)
        //{
        //    var obj = Activator.CreateInstance<TEntity>();
        //    var type = typeof(TEntity);
        //    var propertyInfo = type.GetProperty("Id");
        //    var instance = Expression.Parameter(typeof(TEntity), "instance");
        //    var parameter = Expression.Parameter(typeof(long), "param");
        //    var body = Expression.Call(instance, propertyInfo.GetSetMethod(), parameter);
        //    var parameters = new ParameterExpression[] { instance, parameter };
        //    var setterDelete = Expression.Lambda<Action<TEntity, long>>(body, parameters).Compile();
        //    setterDelete.Invoke(obj, id);

        //    return Delete(obj);
        //}

        ///// <inheritdoc />
        //public IEnumerable<TEntity> GetByIds(long[] ids)
        //{
        //    return connection.Query<TEntity>($" select *  from {typeof(TEntity).Name} where user_id in @ids ;", new { ids });
        //}

        ///// <inheritdoc />
        //public TEntity GetByIdAndOrgId(long id, long orgId)
        //{
        //    return connection.Query<TEntity>($" select *  from {typeof(TEntity).Name} where id=@Id and orgId = @orgId ", new { Id = id, orgId = orgId }).FirstOrDefault();
        //}

        ///// <inheritdoc />
        //public int UpdateWithColumnsById<TEnity>(Dictionary<string, object> dict, long id)
        //{
        //    var columns = new StringBuilder();
        //    var parameters = new DynamicParameters(new { });

        //    foreach (var item in dict)
        //    {
        //        columns.Append(item.Key + "=@" + item.Key + ",");
        //        parameters.Add("@" + item.Key, item.Value);
        //    }
        //    parameters.Add("@Id", id);
        //    var substring = columns.ToString().Substring(0, columns.ToString().Length - 1);
        //    var sql = $"update {typeof(TEntity).Name} set { substring } where id=@Id ";
        //    return connection.Execute(sql, parameters);
        //}

        //private string GetConcurrentUpdateSql(TypeMapper typeMapper)
        //{
        //    string sql = string.Empty;
        //    var entityType = typeof(TEntity);
        //    if (!typeConcurrentUpdateSqlcache.TryGetValue(entityType, out sql))
        //    {
        //        var columnBuilder = typeMapper.Properties.Aggregate(new StringBuilder(), (sb, property) => (property.Name == "RowVersion" ? sb.AppendFormat("{0}=@{0}+1,", property.Name) : sb.AppendFormat("{0}=@{0},", property.Name)));
        //        var columns = columnBuilder.Remove(columnBuilder.Length - 1, 1);
        //        //var sb = new StringBuilder();

        //        sql = string.Format("update {0} set {1} where id=@Id and rowversion=@RowVersion;", typeMapper.Name, columns);
        //        typeConcurrentUpdateSqlcache.TryAdd(entityType, sql);
        //    }
        //    return sql;
        //}

        //private static TypeMapper GetEntityMapper()
        //{
        //    var entityType = typeof(TEntity);
        //    var properties = entityType.GetProperties();

        //    if (!typecache.TryGetValue(entityType, out TypeMapper typeMapper))
        //    {
        //        typeMapper = new TypeMapper()
        //        {
        //            Name = nameof(entityType),
        //            Properties = properties
        //        };

        //        typecache.TryAdd(entityType, typeMapper);
        //    }

        //    return typeMapper;
        //}
    }

    class TypeMapper
    {
        public string Name { get; set; }

        public PropertyInfo[] Properties { get; set; }
    }

    /// <summary>
    /// 自定义TableNameMapper
    /// </summary>
    public class CustomTableNameMapper : ITableNameMapper
    {
        /// <summary>
        /// 自定义获取table规则，取消dapper在表名后自动加"s"的逻辑
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public string GetTableName(Type type)
        {
            string name;
            var tableAttr = type.GetCustomAttributes(false).SingleOrDefault(attr => attr.GetType().Name == "TableAttribute") as dynamic;
            if (tableAttr != null)
            {
                name = tableAttr.Name;
            }
            else
            {
                name = type.Name;
                if (type.IsInterface && name.StartsWith("I"))
                    name = name.Substring(1);
            }

            return name;
        }
    }
}
