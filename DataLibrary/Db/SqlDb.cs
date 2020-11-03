using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Db
{
    public class SqlDb : IDataAccess
    {
        private readonly IConfiguration _config;
        public SqlDb(IConfiguration config)
        {
            _config = config;
        }


        public async Task<List<T>> LoadData<T, U>(string storedProcedure, U parameters, string connectionStringName)
        {
            string connectionString = _config.GetConnectionString(connectionStringName);

            //USING -> to make sure connection closed everytime after used no matter success, failed, or exceptions
            using (IDbConnection connection = new SqlConnection(connectionString))
            {

                //Dapper able to bind to class instead of return data table (IEnumerable <T>)
                var rows = await connection.QueryAsync<T>(storedProcedure,  //raw query @ stored procedure
                                                          parameters,       //paramters to insert to SP (safety measures for sql injection)
                                                          commandType: CommandType.StoredProcedure);

                return rows.ToList();
            }
        }

        public async Task<int> SaveData<U>(string storedProcedure, U parameters, string connectionStringName)
        {
            string connectionString = _config.GetConnectionString(connectionStringName);

            using (IDbConnection connection = new SqlConnection(connectionString))
            {

                return await connection.ExecuteAsync(storedProcedure,  //raw query @ stored procedure
                                                     parameters,       //paramters to insert to SP (safety measures for sql injection)
                                                     commandType: CommandType.StoredProcedure);

            }
        }
    }
}
