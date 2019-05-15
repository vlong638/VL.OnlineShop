using ServiceStack.Redis;
using System;
using System.Collections.Generic;

namespace VL.Cache.Redis
{
    class Program
    {
        static void Main(string[] args)
        {
            var redisClient = new RedisClient("localhost", 6379, null, 2);
            SetAndGetValue(redisClient);
            SetAndGetClass(redisClient);
        }

        private static void SetAndGetValue(RedisClient redisClient)
        {
            //Set
            redisClient.Set<string>("UserName", "xia");
            //Get
            var userName = redisClient.Get<string>("UserName");
        }
        private static void SetAndGetClass(RedisClient redisClient)
        {
            TStudent student = new TStudent();
            student.Name = "xia";
            student.Age = 26;
            student.Gender = EGender.Man;
            student.Dresses.Add(new Dress() { Name = "Shirt" });
            student.Dresses.Add(new Dress() { Name = "Jeans" });
            //Set
            redisClient.Set<TStudent>("Student1", student);
            //Get
            var student1 = redisClient.Get<TStudent>("Student1");
        }
    }
    public enum EGender
    {
        None,
        Man,
        Woman
    }
    public class TStudent
    {
        public string Name { set; get; }
        public long Age { set; get; }
        public EGender Gender { set; get; }
        public List<Dress> Dresses { set; get; } = new List<Dress>();
    }
    public class Dress
    {
        public string Name { get; set; }
    }
}
