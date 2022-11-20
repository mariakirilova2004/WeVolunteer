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
        /// Contains the URL of the photo
        /// </summary>
        [Required]
        public string ImageUrl { get; set; }

        /// <summary>
        /// Contains the identification of the user using the current photo
        /// </summary>
        [Required]
        public string UserId { get; set; }
        /// <summary>
        /// Contains the reference of the user using the current photo
        /// </summary>
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
    }
}
