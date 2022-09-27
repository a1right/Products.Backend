using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Persistence
{
    internal static class ConnectionAndCommandConsts
    {
        public const string dbName = "TestDB";
        public const string rootConnectionString =
            "Server=(localdb)\\mssqllocaldb;Trusted_Connection=True;MultipleActiveResultSets=true";
        public const string connectionString =
            "Server=(localdb)\\mssqllocaldb;Database=" + dbName + ";Trusted_Connection=True;MultipleActiveResultSets=true";

        public const string isDatabaseExistsQuerry =
            $"SELECT db_id('{dbName}')";

        public const string dbCreateScriptName = "TestDbCreate.sql";
        public const string dbCreateScriptPath = "Products.Backend\\Product.Persistence\\DbCreationSqlScript\\";
        public const string projectName = "Products.Backend";
    }
}
