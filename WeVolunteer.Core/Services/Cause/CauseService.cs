﻿using System;
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

        public CauseDetailsViewModel CauseDeatilsById(int id)
        {
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
                        Photos = c.Photos.Select(p =>  p.ImageUrl).ToList(),
                        CategoryName = c.Category.Name
                    })
                    .FirstOrDefault();
        }

        public bool Exists(int id)
        {
            return repository.GetByIdAsync<Infrastructure.Data.Entities.Cause>(id) != null;
        }

        public List<PhotoCause> GetPhotosByCauseId(int id)
        {
            return repository.All<PhotoCause>(pc => pc.CauseId == id).ToList();
        }
    }
}
