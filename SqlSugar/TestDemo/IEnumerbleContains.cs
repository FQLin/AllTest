using System;
using System.Collections.Generic;
using System.Linq;
using TestDemo.Model;

namespace TestDemo
{
    public static class IEnumerbleContains
    {
        public static IEnumerable<CarTypeExtend> Data()
        {
            for (int i = 0; i < 100; i++)
            {
                yield return new CarTypeExtend
                {
                    ID = Guid.NewGuid(),
                    CarType_ID = Guid.NewGuid(),
                    Indexing = i,
                    Name = $"name{i}",
                    Picture_ID = Guid.NewGuid(),
                    Type = 1,
                    Value = $"value{i}"
                };
            }
        }

        public static void Test1()
        {
            List<CarTypeExtend> cts = Data().ToList();
            Program._db.Insertable<CarTypeExtend>(cts).ExecuteCommand();

            //List<Guid> ids = cts.Select(c => c.ID).ToList();
            Program._db.Deleteable<CarTypeExtend>()
                    .Where(p => /*ids.*/cts.Select(c => c.ID).Contains(p.ID))
                    .ExecuteCommand();

            Console.WriteLine(Program._db.Queryable<CarTypeExtend>().Count());
        }
    }
}
