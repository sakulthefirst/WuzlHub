using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WuzlHub.DataAccessLayer.DataAccessObjects;
using WuzlHub.DomainModels;

namespace WuzlHub.DataAccessLayer.MySQL.DataAccessObjects
{
    public class UserDAO : IUserDAO
    {

        private IDatabase database;

        public UserDAO(IDatabase database)
        {
            this.database = database;
        }

        public void Delete(User user)
        {
            throw new NotImplementedException();
        }

        public List<User> FetchAll()
        {
            List<User> users = new List<User>();
            var cmd = this.database.CreateCommand("SELECT * FROM user");
            var reader = this.database.ExecuteReader(cmd);
            while (reader.Read())
            {
                users.Add(
                    new User
                    {
                        FirstName = (string)reader["firstName"],
                        LastName = (string)reader["lastName"],


                    }
                   );

            }

            return users;
        }

        public User FetchById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(User user)
        {
            throw new NotImplementedException();
        }

        public void Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
