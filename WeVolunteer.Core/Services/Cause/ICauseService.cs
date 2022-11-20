using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeVolunteer.Core.Models.Cause;
using WeVolunteer.Infrastructure.Data.Entities;

namespace WeVolunteer.Core.Services.Cause
{
    public interface ICauseService
    {
        List<PhotoCause> GetPhotosByCauseId(int id);

        List<CauseAllViewModel> GetAllCauses();
    }
}
