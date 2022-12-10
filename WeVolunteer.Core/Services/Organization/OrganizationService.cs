using Ganss.Xss;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeVolunteer.Core.Models.Organization;
using WeVolunteer.Core.Models.Photos;
using WeVolunteer.Core.Services.Category;
using WeVolunteer.Infrastructure.Data;
using WeVolunteer.Infrastructure.Data.Entities;

namespace WeVolunteer.Core.Services.Organization
{
    public class OrganizationService : IOrganizationService
    {
        private readonly IRepository repository;
        private readonly ICategoryService categoryService;
        private readonly ILogger logger;

        public OrganizationService(IRepository _repository,
                                   ICategoryService _categoryService,
                                   ILogger<OrganizationService> _logger)
        {
            this.repository = _repository;
            this.categoryService = _categoryService;
            this.logger = _logger;
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
                    Photo = new PhotoViewModel
                    {
                        Image = Convert.ToBase64String(o.Photos.First().Image),
                        ImageFormat = o.Photos.First().ImageFormat
                    },
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

        public async Task CreateAsync(string userId, 
                           string name,
                           string headquarter,
                           string description,
                           IFormFile image)
        {
            var sanitalizer = new HtmlSanitizer();

            var organization = new Infrastructure.Data.Entities.Account.Organization()
            {
                UserId = sanitalizer.Sanitize(userId),
                Name = sanitalizer.Sanitize(name),
                Headquarter = sanitalizer.Sanitize(headquarter),
                Description = sanitalizer.Sanitize(description),
                Causes = new List<Infrastructure.Data.Entities.Cause>()
            };

            var photo = new Infrastructure.Data.Entities.PhotoOrganization()
            {
                ImageFormat = image.ContentType,
                OrganizationId = organization.Id,
                Organization = organization
            };

            var memoryStream = new MemoryStream();
            image.CopyTo(memoryStream);
            photo.Image = memoryStream.ToArray();

            organization.Photos = new List<PhotoOrganization>() { photo };

            try
            {
                await this.repository.AddAsync(organization);
                await this.repository.SaveChangesAsync();
            }
            catch (Exception)
            {
                this.logger.LogInformation("{0} did not manage to become organization!", userId);
                throw;
            }
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
            List<string> categories = this.categoryService.AllCategoriesNames().ToList();
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

        public async Task<bool> HasCauses(int organizationId)
        {
            var organization = await this.repository.GetByIdAsync<Infrastructure.Data.Entities.Account.Organization>(organizationId);
            return organization.Causes.Count != 0;
        }

        public PhotoOrganization GetPhotoOrganizationByOrganizationId(int id)
        {
            return repository.All<Infrastructure.Data.Entities.PhotoOrganization>(po => po.OrganizationId == id).ToList().First();
        }

        public string GetOrganizationNameById(int organizationId)
        {
            string name =  this.repository.GetByIdAsync<Infrastructure.Data.Entities.Account.Organization>(organizationId).Result.Name;
            return name;
        }

        public bool NameExists(string name)
        {
            return this.repository.All<Infrastructure.Data.Entities.Account.Organization>(o => o.Name == name).ToList().Count != 0;
        }
    }
}
