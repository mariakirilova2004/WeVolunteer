using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeVolunteer.Core.Services.Cause;
using WeVolunteer.Infrastructure.Data;
using WeVolunteer.Infrastructure.Data.Entities;
using WeVolunteer.Core.Models.Cause;
using WeVolunteer.Core.Services.Organization;
using WeVolunteer.Core.Models.Photos;
using Microsoft.AspNetCore.Http;
using Ganss.Xss;
using WeVolunteer.Core.Models.User;

//using WeVolunteer.Core.Exceptions;

namespace WeVolunteer.Core.Services.Cause
{
    public class CauseService : ICauseService
    {
        private readonly IRepository repository;
        private readonly IOrganizationService organizationService;

        public CauseService(IRepository _repository, IOrganizationService _organizationService)
        {
            this.repository = _repository;
            this.organizationService = _organizationService;
        }

        public AllCausesQueryModel All(string category = "",
                                          string searchTerm = "",
                                          CauseSorting sorting = CauseSorting.Newest,
                                          int currentPage = 1,
                                          int causesPerPage = 1)
        {
            var causesQuery = repository.All<Infrastructure.Data.Entities.Cause>();

            if (!string.IsNullOrWhiteSpace(category))
            {
                causesQuery = repository
                    .All<Infrastructure.Data.Entities.Cause>(c => c.Category.Name == category);
            }

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                causesQuery = causesQuery.Where(c =>
                    c.Name.ToLower().Contains(searchTerm.ToLower()) ||
                    c.Place.ToLower().Contains(searchTerm.ToLower()) ||
                    c.Description.ToLower().Contains(searchTerm.ToLower()));
            }

            causesQuery = sorting switch
            {
                CauseSorting.Latest => causesQuery
                    .OrderBy(c => c.Time),
                CauseSorting.Active => causesQuery
                    .Where(c => c.Time > DateTime.Now)
                    .OrderBy(c => c.Time),
                _ => causesQuery.OrderByDescending(c => c.Id)
            };

            var causes = causesQuery
                .Skip((currentPage - 1) * causesPerPage)
                .Take(causesPerPage)
                .Select(c => new CauseViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Place = c.Place,
                    Time = c.Time,
                    Description = c.Description,
                    Photo = 
                    new PhotoViewModel 
                    { 
                        Image = Convert.ToBase64String(c.Photos[0].Image),
                        ImageFormat = c.Photos[0].ImageFormat
                    }
                })
                .ToList();

            var totalCauses = causesQuery.Count();

            return new AllCausesQueryModel()
            {
                TotalCausesCount = totalCauses,
                Causes = causes
            };
        }

        public MineCausesQueryModel Mine(string category = "",
                                          string searchTerm = "",
                                          CauseSorting sorting = CauseSorting.Newest,
                                          int currentPage = 1,
                                          int causesPerPage = 1,
                                          string userId = "")
        {
            var causesQuery = repository.All<Infrastructure.Data.Entities.Cause>(c => c.Organization.UserId == userId);

            if (!string.IsNullOrWhiteSpace(category))
            {
                causesQuery = repository
                    .All<Infrastructure.Data.Entities.Cause>(c => c.Category.Name == category);
            }

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                causesQuery = causesQuery.Where(c =>
                    c.Name.ToLower().Contains(searchTerm.ToLower()) ||
                    c.Place.ToLower().Contains(searchTerm.ToLower()) ||
                    c.Description.ToLower().Contains(searchTerm.ToLower()));
            }

            causesQuery = sorting switch
            {
                CauseSorting.Latest => causesQuery
                    .OrderBy(c => c.Time),
                CauseSorting.Active => causesQuery
                    .Where(c => c.Time > DateTime.Now)
                    .OrderBy(c => c.Time),
                _ => causesQuery.OrderByDescending(c => c.Id)
            };

            var causes = causesQuery
                .Skip((currentPage - 1) * causesPerPage)
                .Take(causesPerPage)
                .Select(c => new CauseViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Place = c.Place,
                    Time = c.Time,
                    Description = c.Description,
                    Photo = 
                   new PhotoViewModel
                   {
                       Image = Convert.ToBase64String(c.Photos[0].Image),
                       ImageFormat = c.Photos[0].ImageFormat
                   }
                })
                .ToList();

            var totalCauses = causesQuery.Count();

            return new MineCausesQueryModel()
            {
                TotalCausesCount = totalCauses,
                Causes = causes
            };
        }

        public async Task BecomePartAsync(int id, string userId)
        {
            var cause = await this.repository.GetByIdAsync<Infrastructure.Data.Entities.Cause>(id);
            var user = await this.repository.GetByIdAsync<Infrastructure.Data.Entities.Account.User>(userId);


            user.Causes.Add(cause);
            cause.Users.Add(user);

            this.repository.Update(user);
            this.repository.Update(cause);

            await this.repository.SaveChangesAsync();
        }

        public CauseDetailsViewModel CauseDetailsById(int id)
        {
            var causes = this.repository.All<Infrastructure.Data.Entities.Cause, Infrastructure.Data.Entities.Account.User>(c => c.Users);
            var cause = causes.Where(c => c.Id == id).ToList()[0];
            var users = cause.Users.Select(u => new CauseUsersViewModel { FirstName = u.FirstName, LastName = u.LastName, Email = u.Email }).ToList();

            return this.repository
                    .All<Infrastructure.Data.Entities.Cause>(c => c.Id == id)
                    .Select(c => new CauseDetailsViewModel()
                    {
                        Id = c.Id,
                        Name = c.Name,
                        Place = c.Place,
                        Description = c.Description,
                        Time = c.Time,
                        OrganizationName = c.Organization.Name,
                        Photos = c.Photos.Select(p => new PhotoViewModel
                        {
                            Image = Convert.ToBase64String(p.Image),
                            ImageFormat = p.ImageFormat
                        }).ToList(),
                        CategoryName = c.Category.Name,
                        Users = users
                    })
                    .FirstOrDefault();
        }

        public async Task<bool> Exists(int id)
        {
            return await  repository.GetByIdAsync<Infrastructure.Data.Entities.Cause>(id) != null;
        }

        public List<PhotoCause> GetPhotosByCauseId(int id)
        {
            return repository.All<PhotoCause>(pc => pc.CauseId == id).ToList();
        }

        public async Task<bool> IsMadeBy(int id, string userId)
        {
            var cause = await this.repository.GetByIdAsync<Infrastructure.Data.Entities.Cause>(id);

            return organizationService.GetOrganizationByUserId(userId) != null && cause.OrganizationId == organizationService.GetOrganizationByUserId(userId).Id; ;
        }

        public bool CauseWithNameExists(string name, string userId)
        {
            return this.repository.All<Infrastructure.Data.Entities.Cause>(c => c.Name == name && c.Organization.UserId == userId).ToList().Count > 0;
        }

        public async Task CreateAsync(int organizationId, 
                                      string name, 
                                      string place,
                                      DateTime time, 
                                      string description,
                                      IFormFile image, 
                                      int categoryId)
        {
            var sanitalizer = new HtmlSanitizer();

            var cause = new Infrastructure.Data.Entities.Cause()
            {
                OrganizationId = organizationId,
                Name = sanitalizer.Sanitize(name),
                Place = sanitalizer.Sanitize(place),
                Time = time,
                Description = sanitalizer.Sanitize(description),
                CategoryId = categoryId
            };

            var photo = new Infrastructure.Data.Entities.PhotoCause()
            {
                ImageFormat = image.ContentType,
                CauseId = cause.Id,
                Cause = cause
            };

            var memoryStream = new MemoryStream();
            image.CopyTo(memoryStream);
            photo.Image = memoryStream.ToArray();

            cause.Photos = new List<PhotoCause>() { photo };

            await this.repository.AddAsync(cause);
            await this.repository.SaveChangesAsync();
        }

        public async Task Edit(int id, string name, string place, DateTime time, string description, IFormFile image, int categoryId)
        {
            var sanitalizer = new HtmlSanitizer();

            var cause = await this.repository.GetByIdAsync<Infrastructure.Data.Entities.Cause>(id);

            this.repository.Detach(cause);

            cause.OrganizationId = id;
            cause.Name = sanitalizer.Sanitize(name);
            cause.Place = sanitalizer.Sanitize(place);
            cause.Time = time;
            cause.Description = sanitalizer.Sanitize(description);
            cause.CategoryId = categoryId;

            var photo = new Infrastructure.Data.Entities.PhotoCause()
            {
                ImageFormat = image.ContentType,
                CauseId = cause.Id,
                Cause = cause
            };

            var memoryStream = new MemoryStream();
            image.CopyTo(memoryStream);
            photo.Image = memoryStream.ToArray();

            GetPhotosByCauseId(cause.Id).Add(photo);

            this.repository.Update(cause);
            await this.repository.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var cause = await this.repository.GetByIdAsync<Infrastructure.Data.Entities.Cause>(id);
            this.repository.Detach(cause);
            cause.Users.Clear();
            cause.Organization = null;
            this.repository.Delete(cause);
            await this.repository.SaveChangesAsync();
        }

        public async Task Cancel(int id, string userId)
        {
            var causes = this.repository.All<Infrastructure.Data.Entities.Cause, Infrastructure.Data.Entities.Account.User>(c => c.Users);
            var cause = causes.Where(c => c.Id == id && c.Users.Any(u => u.Id == userId)).ToList();
            var user = cause[0].Users.Find(u  => u.Id == userId);
            cause[0].Users.Remove(user);
            await this.repository.SaveChangesAsync(); 
        }

        public bool IsAlreadyPart(string userId, int id)
        {
            var cause = this.repository.All<Infrastructure.Data.Entities.Cause>(c => c.Id == id && c.Users.Any(u => u.Id == userId)).ToList();

            return cause.Count != 0;
        }
    }
}
