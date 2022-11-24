using WeVolunteer.Infrastructure.Data.Entities;

namespace WeVolunteer.Core.Models.Cause
{
    public class CauseViewModel :ICauseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Place { get; set; }
        public DateTime Time { get; set; }
        public string Description { get; set; }
        public PhotoCause Photo { get; set; }
    }
}
