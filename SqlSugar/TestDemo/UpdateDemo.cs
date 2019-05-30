using System;
using TestDemo.Model;

namespace TestDemo
{
    public static  class UpdateDemo
    {
        public static void Update1()
        {
            Program._db.Updateable<CarType>()
                .UpdateColumns(c => new { c.State })
                .ReSetValue(c => c.State == !c.State)
                //.Where(c => c.ID == id)
                .ExecuteCommand();
        }


        #region 测试c.State ? true : false方式
        /// <summary>
        /// https://github.com/sunkaixuan/SqlSugar/issues/364#issuecomment-493759392
        /// </summary>
        public static void Update2()
        {
            Program._db.Updateable<CarType>()
                .UpdateColumns(c => new { c.State })
                .ReSetValue(c => c.State == (c.State ? true : false))
                //.Where(c => c.ID == id)
                .ExecuteCommand();
        }


        //public static void Update3()
        //{
        //    Program._db.Updateable<CarType>()
        //    .UpdateColumns(it => new CarType { State = (it.State ? true : false) })
        //    //.Where(c => c.ID == Guid.Empty)
        //    .ExecuteCommand();
        //}
        #endregion
    }
}
