using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeVolunteer.Core.Models.Organization;

namespace WeVolunteer.Core.Services.Organization
{
    public interface IOrganizationService
    {
        bool ExistsById(string userId);
        bool UserWithNameExists(string email);
        Task<bool> UserHasCauses(int organizationId);
        Task CreateAsync(string userId,
                    string name,
                    string headquarter,
                    string description);
        Task<Infrastructure.Data.Entities.Account.Organization> GetOrganizationById(int organizationId);

        string GetOrganizationCategory(int organizationId);

        Infrastructure.Data.Entities.Account.Organization GetOrganizationByUserId(string userId);

        string GetOrganizationName(string userId);
        AllOrganizationsQueryModel All(string category, string searchTerm, int currentPage, int organizationsPerPage);
        IEnumerable<string> AllCategoriesNames();
    }
}
