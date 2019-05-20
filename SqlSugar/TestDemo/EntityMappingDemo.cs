using Newtonsoft.Json;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;
using TestDemo.Model;

namespace TestDemo
{
    public static class EntityMappingDemo
    {
        /// <summary>
        /// 直接调用原生 HasValue 方法
        /// 
        /// 
        ///         SqlSugar.SqlSugarException
        ///           HResult = 0x80131500
        ///   Message=English Message : Entity mapping error.将字符串转换为 uniqueidentifier 时失败。
        /// Chinese Message : 实体与表映射出错。将字符串转换为 uniqueidentifier 时失败。
        ///   Source=SqlSugar
        ///   StackTrace:
        ///    at SqlSugar.Check.Exception(Boolean isException, String message, String[] args)
        ///    at SqlSugar.DbBindAccessory.GetEntityList[T](SqlSugarClient context, IDataReader dataReader)
        ///    at SqlSugar.DbBindProvider.DataReaderToList[T](Type type, IDataReader dataReader)
        ///    at SqlSugar.QueryableProvider`1.GetData[TResult](KeyValuePair`2 sqlObj)
        ///    at SqlSugar.QueryableProvider`1._ToList[TResult]()
        ///    at SqlSugar.QueryableProvider`1.ToList()
        ///    at TestDemo.HasValueDemo.Test2(Guid storeId, DateTime startDate, DateTime endDate) in E:\GitHub\AllTest\SqlSugar\TestDemo\HasValueDemo.cs:line 61
        ///    at TestDemo.Program.Main(String[] args) in E:\GitHub\AllTest\SqlSugar\TestDemo\Program.cs:line 42
        /// </summary>
        /// <param name="storeId"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        public static void Test1(Guid storeId, DateTime startDate, DateTime endDate)
        {
            List<OrdersCar> oc = Program._db.Queryable<OrdersCar>()
                .Where(o =>
                o.Car_ID.HasValue &&
                o.EndTime >= startDate
             && o.StartTime < endDate.AddDays(1))
             .OrderBy(o => o.AddTime)
             .ToList();

            Console.WriteLine(JsonConvert.SerializeObject(oc));
        }

        /// <summary>
        /// 使用 SqlFunc.HasValue 方法
        /// </summary>
        /// <param name="storeId"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        public static void Test2(Guid storeId, DateTime startDate, DateTime endDate)
        {
            List<OrdersCar> oc = Program._db.Queryable<OrdersCar>()
                .Where(o => SqlFunc.HasValue(o.Car_ID)
                //.Where(o => SqlFunc.HasValue(o.Car_ID.Value)  
                && o.EndTime >= startDate
             && o.StartTime < endDate.AddDays(1))
             .OrderBy(o => o.AddTime)
             .ToList();

            Console.WriteLine(JsonConvert.SerializeObject(oc));
        }

        /// <summary>
        /// 使用 SqlFunc.IsNullOrEmpty 方法
        /// </summary>
        /// <param name="storeId"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        public static void Test3(Guid storeId, DateTime startDate, DateTime endDate)
        {
            List<OrdersCar> oc = Program._db.Queryable<OrdersCar>()
                .Where(o => SqlFunc.IsNullOrEmpty(o.Car_ID)
                //.Where(o => SqlFunc.IsNullOrEmpty(o.Car_ID.Value)
                && o.EndTime >= startDate
             && o.StartTime < endDate.AddDays(1))
             .OrderBy(o => o.AddTime)
             .ToList();

            Console.WriteLine(JsonConvert.SerializeObject(oc));
        }


        /// <summary>
        /// 不进行判断 完美运行
        /// </summary>
        /// <param name="storeId"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        public static void Test4(Guid storeId, DateTime startDate, DateTime endDate)
        {
            List<OrdersCar> oc = Program._db.Queryable<OrdersCar>()
                .Where(o => o.EndTime >= startDate
             && o.StartTime < endDate.AddDays(1))
             .OrderBy(o => o.AddTime)
             .ToList();

            Console.WriteLine(JsonConvert.SerializeObject(oc));
        }
    }
}
