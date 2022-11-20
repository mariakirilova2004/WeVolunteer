using System.ComponentModel.DataAnnotations;
using WeVolunteer.Core.Attributes;
using static WeVolunteer.Infrastructure.Data.DataConstants.User;

namespace WeVolunteer.Models.User
{
    public class UserRegisterViewModel
    {
        /// <summary>
        /// Contains the first name of the user
        /// </summary>
        [Required]
        [StringLength(UserMaxLengthFirstName,ErrorMessage = "Must be between {2} and {1} characters long.", MinimumLength = UserMinLengthFirstName)]
        public string FirstName { get; set; }

        /// <summary>
        /// Contains the last name of the user
        /// </summary>
        [Required]
        [StringLength(UserMaxLengthLastName, ErrorMessage = "Must be between {2} and {1} characters long.", MinimumLength = UserMinLengthLastName)]
        public string LastName { get; set; }

        /// <summary>
        /// Contains the username of the user
        /// </summary>
        [Required]
        [StringLength(UserMaxLengthUsername, ErrorMessage = "Must be between {2} and {1} characters long.", MinimumLength = UserMinLengthUsername)]
        public string Username { get; set; }

        [Required]
        [StringLength(UserMaxLengthPassword, ErrorMessage = "Must be between {2} and {1} characters long.", MinimumLength = UserMinLengthPassword)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Compare(nameof(Password))]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; } = null!;

        /// <summary>
        /// Contains the email of the user
        /// </summary>
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// Contains the phone number of the user
        /// </summary>
        [Required]
        [StringLength(UserLengthPhoneNumber, ErrorMessage = "Must be with length 10.", MinimumLength = UserLengthPhoneNumber)]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Contains the birth date of the user
        /// </summary>
        [Required]
        [CustomDateAttribute]
        public DateTime BirthDate { get; set; }
    }
}
