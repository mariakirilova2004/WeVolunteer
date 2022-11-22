using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WeVolunteer.Core.Services.Organization
{
    public interface IOrganizationService
    {
        bool ExistsById(string userId);
        bool UserWithNameExists(string email);
        bool UserHasCauses(int organizationId);
        void Create(string userId,
                    string name,
                    string headquarter,
                    string description);
        int GetOrganizationId(string userId);
    }
}
