using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using WeVolunteer.Core.Exceptions;
using WeVolunteer.Infrastructure.Data;

namespace WeVolunteer.Core.Services.User
{
    //such service is already done by usermanager
    public class UserService : IUserService
    {
        private readonly IRepository repository;
        private readonly WeVolunteerDbContext context;
        public UserService(WeVolunteerDbContext _context, IRepository _repository)
        {
            this.context = _context;
            this.repository = _repository;
        }

        public bool EmailExists(string email)
        {
            return context.Users.Any(u => u.Email == email);
        }
    }
}
