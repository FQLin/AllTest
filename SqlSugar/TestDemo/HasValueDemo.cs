using Newtonsoft.Json;
using SqlSugar;
using System;
using System.Collections.Generic;
using TestDemo.Model;

namespace TestDemo
{
    public static class HasValueDemo
    {
        /// <summary>
        /// 测试HasValue
        ///      System.Data.SqlClient.SqlException
        ///        HResult = 0x80131904
        ///Message=Conversion failed when converting from a character string to uniqueidentifier.
        ///Source=Core.Net SqlClient Data Provider
        ///StackTrace:
        /// at System.Data.SqlClient.SqlConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
        /// at System.Data.SqlClient.TdsParser.ThrowExceptionAndWarning(TdsParserStateObject stateObj, Boolean callerHasConnectionLock, Boolean asyncClose)
        /// at System.Data.SqlClient.TdsParser.TryRun(RunBehavior runBehavior, SqlCommand cmdHandler, SqlDataReader dataStream, BulkCopySimpleResultSet bulkCopyHandler, TdsParserStateObject stateObj, Boolean& dataReady)
        /// at System.Data.SqlClient.SqlDataReader.TryHasMoreRows(Boolean& moreRows)
        /// at System.Data.SqlClient.SqlDataReader.TryReadInternal(Boolean setTimeout, Boolean& more)
        /// at System.Data.SqlClient.SqlDataReader.Read()
        /// at SqlSugar.ContextMethods.DataReaderToList[T](IDataReader reader)
        /// at SqlSugar.QueryableProvider`1.GetData[TResult](KeyValuePair`2 sqlObj)
        /// at SqlSugar.QueryableProvider`1._ToList[TResult]()
        /// at SqlSugar.QueryableProvider`1.ToList()
        /// at SqlSugar.QueryableProvider`1.ToArray()
        /// at TestDemo.HasValueDemo.Test1(Guid storeId, DateTime startDate, DateTime endDate) in E:\GitHub\AllTest\SqlSugar\TestDemo\HasValueDemo.cs:line 17
        /// at TestDemo.Program.Main(String[] args) in E:\GitHub\AllTest\SqlSugar\TestDemo\Program.cs:line 42
        /// </summary>
        /// <param name="storeId"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        public static void Test1(Guid storeId, DateTime startDate, DateTime endDate)
        {
            Program._db.Queryable<OrdersCar, CarType, Store, Store>((o, c, ss, es) => new Object[]
               {
                JoinType.Left,o.CarType_ID==c.ID,
                JoinType.Left,o.StartStore_ID==ss.ID,
                JoinType.Left,o.EndStore_ID==es.ID
               })
                .Where((o, c, ss, es) => (o.StartStore_ID == storeId || o.EndStore_ID == storeId)
             && o.Car_ID.HasValue
             && o.EndTime >= startDate
             && o.StartTime < endDate.AddDays(1))
             .OrderBy((o, c, ss, es) => o.AddTime)
             .Select((o, c, ss, es) => new
             {
                 c.Name,
                 StartStore = ss.Name,
                 EndStore = es.Name,
                 o.StartTime,
                 o.EndTime
             })
             .ToArray();
        }

        /// <summary>
        /// sql没问题
        /// </summary>
        /// <param name="storeId"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        public static void Test2(Guid storeId, DateTime startDate, DateTime endDate)
        {
            List<OrdersCar> oc= Program._db.Queryable<OrdersCar>()
                .Where(o => 
                //(o.StartStore_ID == storeId || o.EndStore_ID == storeId)&& 
                o.Car_ID.HasValue && 
                o.EndTime >= startDate
             && o.StartTime < endDate.AddDays(1))
             .OrderBy(o => o.AddTime)
             .ToList();
            Console.WriteLine(JsonConvert.SerializeObject(oc));
        }

        public static void Test3(Guid storeId, DateTime startDate, DateTime endDate)
        {
            var oc = Program._db.Queryable<OrdersCar,CarType,Store,Store>((o,c,ss,es)=>new Object[] 
            {
                JoinType.Left,o.CarType_ID==c.ID,
                JoinType.Left,o.StartStore_ID==ss.ID,
                JoinType.Left,o.EndStore_ID==es.ID
            })
                .Where((o, c, ss, es) =>
                (o.StartStore_ID == storeId || o.EndStore_ID == storeId)&& 
                !o.Car_ID.HasValue &&
                o.EndTime >= startDate
             && o.StartTime < endDate.AddDays(1))
             .OrderBy((o, c, ss, es) => o.AddTime)
             .Select((o, c, ss, es) => new
             {
                 c.Name,
                 StartStore = ss.Name,
                 EndStore=es.Name,
                 o.StartTime,
                 o.EndTime
             })
             .ToArray();


            Console.WriteLine(JsonConvert.SerializeObject(oc));
        }
    }
}


