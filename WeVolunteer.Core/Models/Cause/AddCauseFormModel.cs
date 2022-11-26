using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeVolunteer.Infrastructure.Data.Entities;
using static WeVolunteer.Infrastructure.Data.DataConstants.Cause;

namespace WeVolunteer.Core.Models.Cause
{
    public class AddCauseFormModel
    {
        [Required]
        [StringLength(CauseMaxLengthName, ErrorMessage = "Must be between {2} and {1} characters long.", MinimumLength = CauseMinLengthName)]
        public string Name { get; set; }

        [Required]
        [StringLength(CauseMaxLengthPlace, ErrorMessage = "Must be between {2} and {1} characters long.", MinimumLength = CauseMinLengthPlace)]
        public string Place { get; set; }

        [Required]
        public DateTime Time { get; set; }


        [Required]
        [StringLength(CauseMaxLengthDescription, ErrorMessage = "Must be between {2} and {1} characters long.", MinimumLength = CauseMinLengthDescription)]
        public string Description { get; set; }

        [Required]
        public IFormFile Image { get; set; }

        [Required]
        public int CategoryId { get; set; }
        public List<Category>? Categories { get; set; }
    }
}
