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
    }
}
