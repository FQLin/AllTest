using Microsoft.Extensions.Configuration;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using TestDemo.Model;

namespace TestDemo
{
    class Program
    {
        public static SqlSugarClient _db;

        static List<Guid> extendIds = new List<Guid>();

        static void Main(string[] args)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("app.json", false, true)
                .Build();

            _db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = configuration.GetConnectionString("DefaultConnection"),
                DbType = DbType.SqlServer,
                IsAutoCloseConnection = true,
                InitKeyType = InitKeyType.Attribute
            });

            _db.Aop.OnLogExecuting = (sql, pars) =>
            {
                Console.Write($"{sql}\r\n{_db.Utilities.SerializeObject(pars.ToDictionary(it => it.ParameterName, it => it.Value))}\r\n");
            };

            IEnumerbleContains.Test1();

            Console.ReadKey();
        }


        #region Parame
        static void WithT()
        {
            //插入数据
            List<CarTypeExtend> carTypeExtends = new List<CarTypeExtend>();
            for (int i = 0; i < 10; i++)
            {
                Guid c_id = Guid.NewGuid();
                extendIds.Add(c_id);
                carTypeExtends.Add(new CarTypeExtend
                {
                    ID = c_id,
                    CarType_ID = default(Guid),
                    Type = 1,
                    Indexing = i,
                    Name = null,
                    Value = null,
                    Picture_ID = default(Guid)
                });
            }

            _db.Insertable<CarTypeExtend>(carTypeExtends).ExecuteCommand();


            //WithList();

            //WithArray();

            WithDictionary();
        }


        static void WithList()
        {
            if (extendIds.Any())
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                StringBuilder sql =
                    new StringBuilder(
                        $"update {nameof(CarTypeExtend)} set {nameof(CarTypeExtend.Indexing)} = case {nameof(CarTypeExtend.ID)} ");
                for (int i = 0; i < extendIds.Count; i++)
                {
                    sql.Append($" when @{nameof(CarTypeExtend.ID)}{i} then {i}");
                    parameters.Add(new SqlParameter($"@{nameof(CarTypeExtend.ID)}{i}",
                        extendIds[i]));
                }

                sql.Append(
                    $" end where {nameof(CarTypeExtend.CarType_ID)} = @{nameof(CarTypeExtend.CarType_ID)}");
                parameters.Add(new SqlParameter($"@{nameof(CarTypeExtend.CarType_ID)}", default(Guid)));
                _db.Ado.ExecuteCommand(sql.ToString(), parameters);
            }
        }

        static void WithArray()
        {
            if (extendIds.Any())
            {
                SqlParameter[] parameters = new SqlParameter[extendIds.Count + 1];
                StringBuilder sql =
                    new StringBuilder(
                        $"update {nameof(CarTypeExtend)} set {nameof(CarTypeExtend.Indexing)} = case {nameof(CarTypeExtend.ID)} ");
                for (int i = 0; i < extendIds.Count; i++)
                {
                    sql.Append($" when @{nameof(CarTypeExtend.Picture_ID)}{i} then {i}");
                    parameters[i] = new SqlParameter($"@{nameof(CarTypeExtend.Picture_ID)}{i}", extendIds[i]);
                }

                parameters[extendIds.Count] = new SqlParameter($"@{nameof(CarTypeExtend.CarType_ID)}", default(Guid));
                _db.Ado.ExecuteCommand(sql.ToString(), parameters);
            }
        }


        static void WithDictionary()
        {
            Dictionary<string, Object> parameters = new Dictionary<string, Object>();
            StringBuilder sql =
                new StringBuilder(
                    $"update {nameof(CarTypeExtend)} set {nameof(CarTypeExtend.Indexing)} = case {nameof(CarTypeExtend.ID)} ");
            for (int i = 0; i < extendIds.Count; i++)
            {
                sql.Append($" when @Id{i}t then {i}");
                parameters.Add($"@Id{i}t", extendIds[i]);
            }

            sql.Append(
                $" end where {nameof(CarTypeExtend.CarType_ID)} = @{nameof(CarTypeExtend.CarType_ID)} ");
            parameters.Add($"@{nameof(CarTypeExtend.CarType_ID)}", default(Guid));
            _db.Ado.ExecuteCommand(sql.ToString(), parameters);
        } 
        #endregion
    }
}
