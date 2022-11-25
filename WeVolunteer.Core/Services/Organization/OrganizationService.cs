using Ganss.Xss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeVolunteer.Core.Models.Organization;
using WeVolunteer.Infrastructure.Data;
using WeVolunteer.Infrastructure.Data.Entities;

namespace WeVolunteer.Core.Services.Organization
{
    public class OrganizationService : IOrganizationService
    {
        private readonly IRepository repository;

        public OrganizationService(IRepository _repository)
        {
            this.repository = _repository;
        }

        public AllOrganizationsQueryModel All(string category = null,
                                          string searchTerm = null,
                                          int currentPage = 1,
                                          int organizationsPerPage = 1)
        {
            var organizationsQuery = repository.All<Infrastructure.Data.Entities.Account.Organization>();

            if (!string.IsNullOrWhiteSpace(category) && category != "All")
            {
                organizationsQuery = repository
                    .All<Infrastructure.Data.Entities.Account.Organization>(o => o.Causes.Any(c => c.Category.Name == category));
            }

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                organizationsQuery = organizationsQuery.Where(h =>
                    h.Name.ToLower().Contains(searchTerm.ToLower()) ||
                    h.Headquarter.ToLower().Contains(searchTerm.ToLower()) ||
                    h.Description.ToLower().Contains(searchTerm.ToLower()));
            }


            var organizations = organizationsQuery
                .Skip((currentPage - 1) * organizationsPerPage)
                .Take(organizationsPerPage)
                .Select(o => new OrganizationViewModel
                {
                    Id = o.Id,
                    Name = o.Name,
                    Headquarter = o.Headquarter,
                    Description = o.Description,
                    UserName = o.User.UserName,
                    Photo = o.Photos.FirstOrDefault().ImageUrl,
                    LastName = o.User.LastName
                })
                .ToList();

            var TotalOrganizationsCount = organizationsQuery.Count();

            return new AllOrganizationsQueryModel()
            {
                TotalOrganizationsCount = TotalOrganizationsCount,
                Organizations = organizations
            };
        }

        public IEnumerable<string> AllCategoriesNames()
        {
            return repository.All<Category>()
                        .Select(c => c.Name)
                        .Distinct()
                        .ToList();
        }

        public async Task CreateAsync(string userId, 
                           string name,
                           string headquarter,
                           string description)
        {
            var sanitalizer = new HtmlSanitizer();

            var organization = new Infrastructure.Data.Entities.Account.Organization()
            {
                UserId = sanitalizer.Sanitize(userId),
                Name = sanitalizer.Sanitize(name),
                Headquarter = sanitalizer.Sanitize(headquarter),
                Description = sanitalizer.Sanitize(description),
                Photos = new List<PhotoOrganization>(),
                Causes = new List<Infrastructure.Data.Entities.Cause>()
            };

            await this.repository.AddAsync(organization);
            await this.repository.SaveChangesAsync();
        }

        public bool ExistsById(string userId)
        {
            return this.repository.All<Infrastructure.Data.Entities.Account.Organization>(o => o.UserId == userId).ToList().Count != 0;
        }

        public async Task<Infrastructure.Data.Entities.Account.Organization> GetOrganizationById(int organizationId)
        {
            return await this.repository.GetByIdAsync<Infrastructure.Data.Entities.Account.Organization>(organizationId);
        }

        public Infrastructure.Data.Entities.Account.Organization GetOrganizationByUserId(string userId)
        {
            return this.repository.All<Infrastructure.Data.Entities.Account.Organization>(o => o.UserId == userId).ToList().FirstOrDefault();
        }

        public string GetOrganizationCategory(int organizationId)
        {
            var organization = GetOrganizationById(organizationId).Result;
            List<string> categories = AllCategoriesNames().ToList();
            Dictionary<string, int> categoriesWithTotal = new Dictionary<string, int>();

            for (int i = 0; i < categories.Count(); i++)
            {
                categoriesWithTotal.Add(categories[i], 0);
            }

            foreach (var cause in organization.Causes)
            {
                categoriesWithTotal[cause.Category.Name]++;
            }
            return categoriesWithTotal.OrderByDescending(cwt => cwt.Value).First().Key;
        }

        public string GetOrganizationName(string userId)
        {
            return GetOrganizationByUserId(userId).Name;
        }

        public async Task<bool> UserHasCauses(int organizationId)
        {
            var organization = await this.repository.GetByIdAsync<Infrastructure.Data.Entities.Account.Organization>(organizationId);
            return organization.Causes.Count == 0;
        }

        public bool UserWithNameExists(string name)
        {
            return this.repository.All<Infrastructure.Data.Entities.Account.Organization>(o => o.Name == name).ToList().Count > 0;
        }
    }
}
