using System.ComponentModel.DataAnnotations;
using static WeVolunteer.Infrastructure.Data.DataConstants.Category;

namespace WeVolunteer.Infrastructure.Data.Entities
{
    public class Category
    {
        /// <summary>
        /// The identifier of the Category
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// The Name of the category
        /// </summary>
        [Required]
        [StringLength(CategoryMaxLengthName, MinimumLength = CategoryMinLengthName)]
        public string Name { get; set; }

        /// <summary>
        /// The description of the category
        /// </summary>
        [Required]
        [StringLength(CategoryMaxLengthDescription, MinimumLength = CategoryMinLengthDescription)]
        public string Description { get; set; }

        /// <summary>
        /// Contains the causes'references to the category it is helping to
        /// </summary>
        public List<Cause> Causes { get; set; } = new List<Cause>();
    }
}