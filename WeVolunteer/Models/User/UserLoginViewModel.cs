using System.ComponentModel.DataAnnotations;
using static WeVolunteer.Infrastructure.Data.DataConstants.User;

namespace WeVolunteer.Models.User
{
    public class UserLoginViewModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(UserMaxLengthPassword, MinimumLength = UserMinLengthPassword)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
    }
}
