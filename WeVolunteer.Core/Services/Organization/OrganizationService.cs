using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeVolunteer.Infrastructure.Data;

namespace WeVolunteer.Core.Services.Organization
{
    public class OrganizationService : IOrganizationService
    {
        private readonly WeVolunteerDbContext data;
        private readonly IRepository repository;

        public OrganizationService(WeVolunteerDbContext data,
                                   IRepository _repository)
        {
            this.data = data;
            this.repository = _repository;
        }

        public void Create(string userId, 
                           string name,
                           string headquarter,
                           string description)
        {
            var organization = new Infrastructure.Data.Entities.Account.Organization()
            {
                UserId = userId,
                Name = name,
                Headquarter = headquarter,
                Description = description
            };

            this.repository.AddAsync<Infrastructure.Data.Entities.Account.Organization>(organization);
            this.repository.SaveChangesAsync();
        }

        public bool ExistsById(string userId)
        {
            return this.data.Organizations.Where(o => o.UserId == userId).ToList().Count != 0;
        }

        public int GetOrganizationId(string organizationId)
        {
            return this.repository.GetByIdAsync<Infrastructure.Data.Entities.Account.Organization>(organizationId).Id;
        }

        public bool UserHasCauses(int organizationId)
        {
            var organization = this.data.Organizations.FindAsync(organizationId).Result;
            return organization.Causes.Count == 0;
        }

        public bool UserWithNameExists(string name)
        {
            return this.data.Organizations.Any(o => o.Name == name);
        }
    }
}
