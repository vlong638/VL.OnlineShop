using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Microsoft.eShopWeb.ApplicationCore.Entities
{
    /// <summary>
    /// DB表基础属性
    /// </summary>
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            CreateTime = DateTime.Now;
        }

        /// <summary>
        /// 主键Id
        /// </summary>
        [DataMember]
        [Key]
        public virtual int Id { get; set; }

        /// <summary>
        /// DB版号,Mysql详情参考;http://www.cnblogs.com/shanyou/p/6241612.html
        /// </summary>
        //[Timestamp]//Mysql不允许byte[]类型上标记TimeStamp/RowVersion，这里使用DateTime类型配合标记ConcurrencyCheck达到并发控制
        [ConcurrencyCheck]
        public virtual  DateTime RowVersion { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public virtual  DateTime CreateTime { get; set; }
    }
}
