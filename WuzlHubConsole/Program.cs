using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WuzlHub.DataAccessLayer;
using WuzlHub.DataAccessLayer.MySQL;
using WuzlHub.DataAccessLayer.MySQL.DataAccessObjects;

namespace WuzlHubConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine(DataAccesLayerFactory.GetInfo());
            IDatabase database = new Database("Server=127.0.0.1;Database=wuzlhub;Uid=root;Pwd=;");
            UserDAO userDAO = new UserDAO(database);
            var test = userDAO.FetchAll();




            test.ForEach(user =>
            {
                Console.WriteLine(user.FirstName);
            });


        }
    }
}
