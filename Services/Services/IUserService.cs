using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public interface IUserService
    {
        User Create(User usr);
        List<User> Get();
        User Get(string id);
        User IsUserExists(int id);
        void Remove(string id);
        void Update(string id, User Usr);

    }
}
