using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeVolunteer.Core.Models.Organization;
using WeVolunteer.Infrastructure.Data.Entities;

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
                    string description,
                    IFormFile image);
        Task<Infrastructure.Data.Entities.Account.Organization> GetOrganizationById(int organizationId);

        string GetOrganizationCategory(int organizationId);

        Infrastructure.Data.Entities.Account.Organization GetOrganizationByUserId(string userId);

        string GetOrganizationName(string userId);
        AllOrganizationsQueryModel All(string category, string searchTerm, int currentPage, int organizationsPerPage);
        IEnumerable<string> AllCategoriesNames();
        string GetOrganizationNameById(int organizationId);
    }
}
