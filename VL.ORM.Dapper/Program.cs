using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using VL.ORM.Dapper.DapperEntities;

namespace VL.ORM.Dapper
{

    class Program
    {
        static IDbConnection Connection = new MySqlConnection("Server=192.168.10.185;Database=vl;User ID=root;Password=123456;port=3306;CharSet=utf8;pooling=true;");
        static UserRepository UserRepository = new UserRepository(Connection);
        static List<User> Users = new List<User>();

        static void Main(string[] args)
        {
            Insert();
            var user = Query();
            var result_u = Update();
            var result_d = Delete();
            var result_mi = SQL_MultipleInsert();
            var result_si = SQL_In();

            Console.WriteLine("Hello World!");
        }

        #region Samples

        private static User GenerateUser()
        {
            var user = new User()
            {
                UserName = $"xia_{DateTime.Now.ToString("MM_dd_HH_MM")}_{DateTime.Now.Ticks}",
                Password = "123456",
                Sex = Sex.None,
                AddTime = DateTime.Now,
            };
            user.NickName = user.UserName;
            return user;
        }

        public static void Insert()
        {
            User user = GenerateUser();
            var id = UserRepository.Insert(user);
        }

        public static User Query()
        {
            for (int i = 0; i < 1000; i++)
            {
                var user = UserRepository.GetById(i);
                if (user != null)
                {
                    return user;
                }
            }
            return null;
        }

        public static bool Update()
        {
            var user = Query();
            user.EditTime = DateTime.Now;
            return UserRepository.Update(user);
        }

        public static bool Delete()
        {
            var user = Query();
            return UserRepository.Delete(user);
        }

        public static long SQL_MultipleInsert()
        {
            User[] users = new User[3];
            users[0] = GenerateUser();
            users[1] = GenerateUser();
            users[2] = GenerateUser();
            return UserRepository.Insert(users);
        }

        public static List<User> SQL_In()
        {
            long[] ids = new long[1000];
            for (int i = 0; i < 1000; i++)
            {
                ids[i] = i;
            }
            return UserRepository.GetByIds(ids).ToList();
        }

        /// <summary>
        /// TODO 多表查询
        /// </summary>
        public static void SQL_MultiTableQuery()
        {

        } 

        #endregion
    }
}
