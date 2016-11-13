using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WuzlHub.DomainModels;

namespace WuzlHub.DataAccessLayer.DataAccessObjects
{
    public interface IUserDAO
    {
        List<User> FetchAll();

        User FetchById(int id);

        void Update(User user);

        void Delete(User user);

        void Insert(User user);

    
    }
}
