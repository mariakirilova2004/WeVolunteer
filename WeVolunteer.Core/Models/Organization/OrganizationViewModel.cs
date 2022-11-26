using WeVolunteer.Core.Models.Photos;
using WeVolunteer.Infrastructure.Data.Entities;

namespace WeVolunteer.Core.Models.Organization
{
    public class OrganizationViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Headquarter { get; set; }
        public string Description { get; set; }
        public PhotoViewModel Photo { get; set; }
        public string UserName { get; set; }
        public string LastName { get; set; }
        public string CategoryName { get; set; }

    }
}