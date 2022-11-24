using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeVolunteer.Core.Models.Cause
{
    public interface ICauseModel
    {
        public string Name { get; }
        public string Place { get; }
    }
}
