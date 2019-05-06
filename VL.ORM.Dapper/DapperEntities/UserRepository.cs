using System.Data;

namespace VL.ORM.Dapper.DapperEntities
{
    class UserRepository : Repository<User>
    {
        public UserRepository(IDbConnection connection) : base(connection)
        {
        }
    }
}
