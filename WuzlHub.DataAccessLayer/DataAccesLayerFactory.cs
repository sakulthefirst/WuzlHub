using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WuzlHub.DataAccessLayer
{
    public class DataAccesLayerFactory
    {
        private static string connectionString;
        private static string dataAccesLayer;
        private static Assembly dataAccessLayerAssembly;

        static DataAccesLayerFactory()
        {
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString;
            dataAccesLayer = ConfigurationManager.AppSettings["DataAccessLayer"];
            dataAccessLayerAssembly = Assembly.Load("WuzlHub.DataAccessLayer." + dataAccesLayer);
        }

        public IDatabase GetDatabase()
        {
            Activator.CreateInstance
        }

        public static string GetInfo()
        {
            return "ConnectionString: " + connectionString + "\nDataAccessLayer: " + dataAccesLayer;
        }
    }
}