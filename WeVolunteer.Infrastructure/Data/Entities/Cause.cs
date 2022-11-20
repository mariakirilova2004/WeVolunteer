using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeVolunteer.Infrastructure.Data.Entities.Account;
using WeVolunteer.Infrastructure.Data.Entities;
using static WeVolunteer.Infrastructure.Data.DataConstants.Cause;

namespace WeVolunteer.Infrastructure.Data.Entities
{
    public class Cause
    {
        /// <summary>
        /// The identifier of the Event
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Contains the name of the event
        /// </summary>
        [Required]
        [StringLength(CauseMaxLengthName, MinimumLength = CauseMinLengthName)]
        public string Name { get; set; }

        /// <summary>
        /// Contains the place where the event takes place
        /// </summary>
        [Required]
        [StringLength(CauseMaxLengthPlace, MinimumLength = CauseMinLengthPlace)]
        public string Place { get; set; }

        /// <summary>
        /// Contains the exact time when the event starts
        /// </summary>
        [Required]
        public DateTime Time { get; set; }

        /// <summary>
        /// Contains the organization of the event
        /// </summary>
        [Required]
        public Organization? Organization { get; set; }
        /// <summary>
        /// Contains the Id of the organization of the event
        /// </summary>
        [ForeignKey(nameof(Organization))]
        public int OrganizationId { get; set; }

        /// <summary>
        /// Conatins the summary of the event (Further information)
        /// </summary>
        [Required]
        [StringLength(CauseMaxLengthDescription, MinimumLength = CauseMinLengthDescription)]
        public string Description { get; set; }

        /// <summary>
        /// Conatins several or one photo representing the event
        /// </summary>
        public List<PhotoCause> Photos { get; set; } = new List<PhotoCause>();

        /// <summary>
        /// Contains the categories'references which the event is helping to
        /// </summary>
        public List<Category> Categories { get; set; } = new List<Category>();
    }
}
