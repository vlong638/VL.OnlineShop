using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace VL.ORM.Dapper.DapperEntities
{
    class UserRepository : Repository<User>
    {
        public UserRepository(IDbConnection connection) : base(connection)
        {
        }

        /// <inheritdoc />
        public List<User> GetByIds(long[] ids)
        {
            return connection.Query<User>($" select *  from {nameof(User)} where user_id in @ids ;", new { ids }).ToList();
        }
    }
}
