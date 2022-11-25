using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeVolunteer.Core.Models.Cause;
using WeVolunteer.Infrastructure.Data.Entities;

namespace WeVolunteer.Core.Services.Cause
{
    public interface ICauseService
    {
        List<PhotoCause> GetPhotosByCauseId(int id);

        AllCausesQueryModel All(string category = null,
                                          string searchTerm = null,
                                          CauseSorting sorting = CauseSorting.Newest,
                                          int currentPage = 1,
                                          int causesPerPage = 1);

        IEnumerable<string> AllCategoriesNames();

        Task<bool> Exists(int id);
        CauseDetailsViewModel CauseDeatilsById(int id);
        Task BecomePartAsync(int id, string userId);
        Task<bool> IsMadeBy(int id, string userId);
    }
}
