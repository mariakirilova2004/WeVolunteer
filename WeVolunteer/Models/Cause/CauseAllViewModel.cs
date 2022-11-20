using WeVolunteer.Infrastructure.Data.Entities;

namespace WeVolunteer.Models.Cause
{
    public class CauseAllViewModel
    {
        public string Name { get; set; }
        public string Place { get; set; }
        public DateTime Time { get; set; }
        public string Description { get; set; }
        public PhotoCause Photo { get; set; }
    }
}
