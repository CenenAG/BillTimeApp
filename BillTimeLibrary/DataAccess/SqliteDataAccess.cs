using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Security.Cryptography;

namespace BillTimeLibrary.DataAccess
{
    public static class SqliteDataAccess
    {
        //LoadData<PersonModel>("select * from person", null) = List<Personmodel>
        public static List<T> LoadData<T>(string sqlStatement, Dictionary<string, object> parameters, string connectionName = "Default")
        {
            DynamicParameters dynParameDapperQuery = parameters.ToDynamicParameters();
            using (IDbConnection cnn = new SQLiteConnection(DataAccessHelpers.LoadConnectionString(connectionName)))
            {
                var rows = cnn.Query<T>(sqlStatement, dynParameDapperQuery);
                return rows.ToList();
            }
        }

        public static void SaveData(string sqlStatement, Dictionary<string, object> parameters, string connectionName = "Default")
        {
            DynamicParameters dynParamDapperQuery = parameters.ToDynamicParameters();
            using (IDbConnection cnn = new SQLiteConnection(DataAccessHelpers.LoadConnectionString(connectionName)))
            {
                cnn.Execute(sqlStatement, dynParamDapperQuery);
            }
        }

        private static DynamicParameters ToDynamicParameters(this Dictionary<string, object> parameters)
        {
            DynamicParameters output = new DynamicParameters();
            parameters.ToList().ForEach(x => output.Add(x.Key, x.Value));
            return output;
        }
    }
}
