using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeVolunteer.Core.Models.Cause
{
    public class CauseDetailsViewModel : ICauseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Place { get; set; }
        public DateTime Time { get; set; }
        public string OrganizationName { get; set; }
        public string Description { get; set; }
        public List<string> Photos { get; set; } = new List<string>();
        public string CategoryName { get; set; }
    }
}
