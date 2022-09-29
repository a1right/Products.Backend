
using System.Text;
using Microsoft.Data.SqlClient;
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

            string script = File.ReadAllText(GetDbCreateScriptPath(), Encoding.GetEncoding(ConnectionAndCommandConsts.dbCreateScriptEncoding));

            SqlConnection conn = new SqlConnection(sqlConnectionString);

            Server server = new Server(new ServerConnection(conn));

            server.ConnectionContext.ExecuteNonQuery(script);
        }
    }
}
