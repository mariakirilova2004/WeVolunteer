using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeVolunteer.Core.Models.User;

namespace WeVolunteer.Core.Services.User
{
    //such service is already done by usermanager
    public interface IUserService
    {
        public bool EmailExists(string email);
        bool IdExists(string userId);
        public bool NameExists(string name);

        IEnumerable<UserServiceModel> All();
    }
}
