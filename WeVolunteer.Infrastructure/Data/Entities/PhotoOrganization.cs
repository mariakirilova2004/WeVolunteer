using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeVolunteer.Infrastructure.Data.Entities.Account;

namespace WeVolunteer.Infrastructure.Data.Entities
{
    public class PhotoOrganization
    {
        /// <summary>
        /// Contains the identifier of the Photo.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Contains the photo
        /// </summary>
        [Required]
        public byte[] Image { get; set; }

        /// <summary>
        /// Contains the format of the photo
        /// </summary>
        [Required]
        public string ImageFormat { get; set; }

        /// <summary>
        /// Contains the identification of the organization using the current photo
        /// </summary>
        [Required]
        public int OrganizationId { get; set; }
        /// <summary>
        /// Contains the reference of the organization using the current photo
        /// </summary>
        [ForeignKey(nameof(OrganizationId))]
        public Organization? Organization { get; set; }
    }
}
