using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;

namespace Products.Persistence
{
    public class DbInitializer
    {
        public static void Initialize()
        {
            if (!IsDatabaseExists())
            {
                ExecuteDbCreateQuerry();
            }
            
        }
        private static bool IsDatabaseExists()
        {
            string connectionString = ConnectionAndCommandConsts.rootConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand(ConnectionAndCommandConsts.isDatabaseExistsQuerry, connection))
                {
                    connection.Open();
                    return (command.ExecuteScalar() != DBNull.Value);
                }
            }
        }
        private static string GetDbCreateScriptPath()
        {
            var currentFolder = Environment.CurrentDirectory;
            var scriptPath = currentFolder
                                 .Substring(0, currentFolder.IndexOf(ConnectionAndCommandConsts.projectName)) +
                             ConnectionAndCommandConsts.dbCreateScriptPath +
                             ConnectionAndCommandConsts.dbCreateScriptName;
            return scriptPath;
        }

        private static void ExecuteDbCreateQuerry()
        {
            string sqlConnectionString = ConnectionAndCommandConsts.rootConnectionString;

            string script = File.ReadAllText(GetDbCreateScriptPath(), Encoding.GetEncoding(1251));

            SqlConnection conn = new SqlConnection(sqlConnectionString);

            Server server = new Server(new ServerConnection(conn));

            server.ConnectionContext.ExecuteNonQuery(script);
        }
    }
}
