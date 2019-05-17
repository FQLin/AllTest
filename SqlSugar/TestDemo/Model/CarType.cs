using SqlSugar;
using System;

namespace TestDemo.Model
{
    ///<summary>
    ///
    ///</summary>
    public partial class CarType
    {
        public CarType()
        {


        }
        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:False
        /// </summary>           
        [SugarColumn(IsPrimaryKey = true)] public Guid ID { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string Name { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:False
        /// </summary>           
        public int Price { get; set; }

        /// <summary>
        /// Desc:保险费
        /// Default:
        /// Nullable:False
        /// </summary>           
        public int Premium { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string Introduce { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        public Guid? Picture_ID { get; set; }

        /// <summary>
        /// Desc:状态：0：删除，1：正常
        /// Default:1
        /// Nullable:False
        /// </summary>           
        public bool State { get; set; }

    }
}
