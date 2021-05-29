using Dapper;
using HRAM.UI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRAM.UI.Helpers
{
    public class DataAccess
    {
        public static Employee GetEmployee(string emailadd)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(SqlConnectionHelper.ConnVal("HRAMData")))
            {
                var sqlq = $"SELECT * FROM dbo.[User] WHERE Email= '{emailadd}' ";
                var output = connection.QueryAsync<Employee>(sqlq, types: new[] { typeof(Employee)}, map: (obj) =>
                {
                    return (Employee)obj.Single();
                }
                ).Result;
                return output.FirstOrDefault<Employee>();
            }
        }
        
    }
}
