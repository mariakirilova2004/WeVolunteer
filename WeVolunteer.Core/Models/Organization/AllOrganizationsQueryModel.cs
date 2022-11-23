using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeVolunteer.Infrastructure.Data.Entities;

namespace WeVolunteer.Core.Models.Organization
{
    public class AllOrganizationsQueryModel
    {
        public const int OrganizationsPerPage = 2;

        public string Category { get; init; }

        [DisplayName("Search by text")]
        public string SearchTerm { get; init; }

        //public Organization Sorting Sorting { get; init; }
        public int CurrentPage { get; init; } = 1;
        public int TotalOrganizationsCount { get; set; }
        public IEnumerable<string> Categories { get; set; }
        public IEnumerable<OrganizationViewModel> Organizations { get; set; } = new List<OrganizationViewModel>();
    }
}
