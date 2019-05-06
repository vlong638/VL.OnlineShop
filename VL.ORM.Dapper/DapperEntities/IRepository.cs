using System.Collections.Generic;

namespace VL.ORM.Dapper.DapperEntities
{
    /// <summary>
    /// 仓储接口类
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// insert 
        /// </summary>
        /// <param name="entity"></param>
        long Insert(TEntity entity);
        /// <summary>
        /// insert
        /// </summary>
        /// <param name="entity"></param>
        long Insert(TEntity[] entity);
        //void InsertOrUpdate(TEntity entity);
        //void InsertOrUpdate(TEntity[] entity);
        /// <summary>
        /// update
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool Update(TEntity entity);
        /// <summary>
        /// 删除对象
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool Delete(TEntity entity);
        /// <summary>
        /// 根据id查询对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TEntity GetById(long id);

        ///// <summary>
        ///// 批量查询对象
        ///// </summary>
        ///// <param name="ids"></param>
        ///// <returns></returns>
        //IEnumerable<TEntity> GetByIds(long[] ids);

        ///// <summary>
        ///// 带并发验证的更新，实体需实现IRowVersion
        ///// </summary>
        ///// <param name="entity"></param>
        ///// <returns></returns>
        //bool ConcurrentUpdate(TEntity entity);
        ///// <summary>
        ///// 根据id删除对象
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //bool Delete(long id);
        ///// <summary>
        ///// 根据id和orgId查询对象
        ///// </summary>
        ///// <param name="id"></param>
        ///// <param name="orgId"></param>
        ///// <returns></returns>
        //TEntity GetByIdAndOrgId(long id, long orgId);

        ///// <summary>
        ///// 根据id更新指定的字段
        ///// </summary>
        ///// <typeparam name="TEnity"></typeparam>
        ///// <param name="dict">更新的字段以及字段值(key为字段名；value为字段值)</param>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //int UpdateWithColumnsById<TEnity>(Dictionary<string, object> dict, long id);
    }
}
