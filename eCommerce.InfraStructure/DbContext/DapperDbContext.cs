using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.InfraStructure.DbContext
{
    
    public class DapperDbContext
    {
        private readonly IConfiguration _configuration;
        private readonly IDbConnection _connection;
        public DapperDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
            string connectionStringTemplate=_configuration.GetConnectionString("DefaultConnection")!;
            string connectionStringValues = connectionStringTemplate.Replace("$HOST_NAME", Environment.GetEnvironmentVariable("HOST_NAME")).
            Replace("$DB_NAME", Environment.GetEnvironmentVariable("DB_NAME")).
            Replace("$DB_USER", Environment.GetEnvironmentVariable("DB_USER")).
            Replace("$DB_PASSWORD", Environment.GetEnvironmentVariable("DB_PASSWORD"));         
          
            //string connectionString = _configuration.GetConnectionString("DefaultConnection")!;
            _connection = new SqlConnection(connectionStringValues);
        }
        public IDbConnection DbConnection => _connection;
    }
}
