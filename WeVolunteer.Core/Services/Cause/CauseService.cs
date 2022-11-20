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

        public List<CauseAllViewModel> GetAllCauses()
        {
            return context.Causes.Select(c =>
                new CauseAllViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Place = c.Place,
                    Time = c.Time,
                    Description = c.Description,
                    Photo = c.Photos.First()
                })
                .ToList();
        }

        public List<PhotoCause> GetPhotosByCauseId(int id)
        {
            return this.context.PhotosCauses.Where(pe => pe.CauseId == id).ToList();
        }
    }
}
