using System.ComponentModel;
using WeVolunteer.Core.Models.Cause;
using WeVolunteer.Infrastructure.Data.Entities;

namespace WeVolunteer.Core.Models.Cause
{
    public class AllCausesQueryModel
    {
        public const int CausesPerPage = 3;

        public string Category { get; init; }

        [DisplayName("Search by text")]
        public string SearchTerm { get; init; }

        public CauseSorting Sorting { get; init; }
        public int CurrentPage { get; init; } = 1;
        public int TotalCausesCount { get; set; }
        public IEnumerable<string> Categories { get; set; }
        public IEnumerable<CauseViewModel> Causes { get; set; } = new List<CauseViewModel>();
    }
}
