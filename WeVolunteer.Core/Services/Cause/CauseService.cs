using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeVolunteer.Core.Services.Cause;
using WeVolunteer.Infrastructure.Data;
using WeVolunteer.Infrastructure.Data.Entities;
using WeVolunteer.Core.Models.Cause;
//using WeVolunteer.Core.Exceptions;

namespace WeVolunteer.Core.Services.Cause
{
    public class CauseService : ICauseService
    {
        private readonly IRepository repository;

        private readonly WeVolunteerDbContext context;

        public CauseService(WeVolunteerDbContext _context, IRepository _repository)
        {
            this.context = _context;
            this.repository = _repository;
        }

        public AllCausesQueryModel All(string category = null,
                                          string searchTerm = null,
                                          CauseSorting sorting = CauseSorting.Newest,
                                          int currentPage = 1,
                                          int causesPerPage = 1)
        {
            var causesQuery = repository.All<Infrastructure.Data.Entities.Cause>();

            if (!string.IsNullOrWhiteSpace(category))
            {
                causesQuery = repository
                    .All<Infrastructure.Data.Entities.Cause>(h => h.Categories.Any(c => c.Name == category));
            }

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                causesQuery = causesQuery.Where(h =>
                    h.Name.ToLower().Contains(searchTerm.ToLower()) ||
                    h.Place.ToLower().Contains(searchTerm.ToLower()) ||
                    h.Description.ToLower().Contains(searchTerm.ToLower()));
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
                    Photo = c.Photos.FirstOrDefault()
                })
                .ToList();

            var totalCauses = causesQuery.Count();

            return new AllCausesQueryModel()
            {
                TotalCausesCount = totalCauses,
                Causes = causes
            };
        }

        public IEnumerable<string> AllCategoriesNames()
        {
            return this.repository.All<Category>()
                        .Select(c => c.Name)
                        .Distinct()
                        .ToList();
        }

        public List<PhotoCause> GetPhotosByCauseId(int id)
        {
            return repository.All<PhotoCause>(pe => pe.CauseId == id).ToList();
        }
    }
}
