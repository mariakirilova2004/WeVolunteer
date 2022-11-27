using System.ComponentModel.DataAnnotations;

namespace ImageUpload.Models;

public class UserViewModel
{
    [Required]
    public string Name { get; set; }

    [Required]
    public IFormFile Picture { get; set; }
}
