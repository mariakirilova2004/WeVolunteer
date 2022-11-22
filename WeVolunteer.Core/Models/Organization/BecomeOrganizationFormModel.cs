using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WeVolunteer.Infrastructure.Data.DataConstants.Organization;

namespace WeVolunteer.Core.Models.Organization
{
    public class BecomeOrganizationFormModel
    {
        [Required]
        [StringLength(OrganizationMaxLengthName, ErrorMessage = "Must be between {2} and {1} characters long.", MinimumLength = OrganizationMinLengthName)]
        public string Name { get; set; }

        [Required]
        [StringLength(OrganizationMaxLengthHeadquarter, ErrorMessage = "Must be between {2} and {1} characters long.", MinimumLength = OrganizationMinLengthHeadquarter)]
        public string Headquarter { get; set; }

        [Required]
        [StringLength(OrganizationMaxLengthDescription, ErrorMessage = "Must be between {2} and {1} characters long.", MinimumLength = OrganizationMinLengthDescription)]
        public string Description { get; set; }
    }
}
