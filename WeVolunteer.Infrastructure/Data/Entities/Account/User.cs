using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeVolunteer.Infrastructure.Attributes;
using static WeVolunteer.Infrastructure.Data.DataConstants.User;

namespace WeVolunteer.Infrastructure.Data.Entities.Account
{
    public class User: IdentityUser
    {
        /// <summary>
        /// Contains the first name of the user
        /// </summary>
        [Required]
        [StringLength(UserMaxLengthFirstName, MinimumLength = UserMinLengthFirstName)]
        public string FirstName { get; set; }

        /// <summary>
        /// Contains the last name of the user
        /// </summary>
        [Required]
        [StringLength(UserMaxLengthLastName, MinimumLength = UserMinLengthLastName)]
        public string LastName { get; set; }

        /// <summary>
        /// Contains the phone number of the user
        /// </summary>
        [Required]
        [StringLength(UserLengthPhoneNumber)]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Contains the birth date of the user
        /// </summary>
        [Required]
        [CustomBirthDateAttribute]
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// Contains the list of the causes of the user
        /// </summary>
        [Required]
        public List<Cause> Causes { get; set; } = new List<Cause>();
    }
}
