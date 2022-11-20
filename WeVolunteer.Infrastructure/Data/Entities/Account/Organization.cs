using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WeVolunteer.Infrastructure.Data.Entities.Account;
using WeVolunteer.Infrastructure.Data.Entities;
using static WeVolunteer.Infrastructure.Data.DataConstants.Organization;

namespace WeVolunteer.Infrastructure.Data.Entities.Account
{
    public class Organization
    {
        /// <summary>
        /// Contains the identification of the organization
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Contains the name of the organization
        /// </summary>
        [Required]
        [StringLength(OrganizationMaxLengthName, MinimumLength = OrganizationMinLengthName)]
        public string Name { get; set; }

        /// <summary>
        /// Contains the headquarter of the organization
        /// </summary>
        [Required]
        [StringLength(OrganizationMaxLengthHeadquarter, MinimumLength = OrganizationMinLengthHeadquarter)]
        public string Headquarter { get; set; }

        /// <summary>
        /// Contains description of the organization (Further information)
        /// </summary>
        [Required]
        [StringLength(OrganizationMaxLengthDescription, MinimumLength = OrganizationMinLengthDescription)]
        public string Description { get; set; }

        /// <summary>
        /// Contains several or one photo representing the organization (logo, photo from event)
        /// </summary>
        public List<PhotoOrganization> Photos { get; set; } = new List<PhotoOrganization>();

        /// <summary>
        /// Contains all the causes that are organized by this organization
        /// </summary>
        public List<Cause> Causes { get; set; } = new List<Cause>();

        /// <summary>
        /// Contains the main user of the organization
        /// </summary>
        [Required]
        public string UserId { get; set; }
    }
}