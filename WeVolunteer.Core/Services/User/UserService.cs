using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeVolunteer.Core.Models.User;
//using WeVolunteer.Core.Exceptions;
using WeVolunteer.Infrastructure.Data;

namespace WeVolunteer.Core.Services.User
{
    //such service is already done by usermanager
    public class UserService : IUserService
    {
        private readonly IRepository repository;
        public UserService(IRepository _repository)
        {
            this.repository = _repository;
        }

        //SHOULD BE TESTED
        public IEnumerable<UserServiceModel> All()
        {
            var allUsers = new List<UserServiceModel>();

            var organizations = this.repository
                    .All<Infrastructure.Data.Entities.Account.Organization>();

            allUsers = this.repository.All<Infrastructure.Data.Entities.Account.User>()
                                               .Select(u => new UserServiceModel
                                               {
                                                   Id = u.Id,
                                                   Email = u.Email,
                                                   FullName = u.FirstName + " " + u.LastName,
                                                   PhoneNumber = u.PhoneNumber,
                                                   IsOrganization = false
                                               })
                                               .ToList();

            for (int i = 0; i < allUsers.Count; i++)
            {
                if(organizations.Any(o => o.UserId == allUsers[i].Id))
                {
                    allUsers[i].IsOrganization = true;
                }
                else
                {
                    allUsers[i].IsOrganization = false;
                }
            }

            return allUsers;
        }

        public bool EmailExists(string email)
        {
            return this.repository.All<Infrastructure.Data.Entities.Account.User>(u => u.Email == email).ToList().Count > 0;
        }

        public bool IdExists(string userId)
        {
            return this.repository.All<Infrastructure.Data.Entities.Account.User>(u => u.Id == userId).ToList().Count > 0;
        }

        public bool NameExists(string name)
        {
            return this.repository.All<Infrastructure.Data.Entities.Account.User>(u => u.UserName == name).ToList().Count > 0;
        }
    }
}
