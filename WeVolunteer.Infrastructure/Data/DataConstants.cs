using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeVolunteer.Infrastructure.Data
{
    public class DataConstants
    {
        public class User
        {
            public const int UserMinLengthFirstName = 3;
            public const int UserMaxLengthFirstName = 30;

            public const int UserMinLengthLastName = 3;
            public const int UserMaxLengthLastName = 30;

            public const int UserMinLengthUsername = 3;
            public const int UserMaxLengthUsername = 30;

            public const int UserMinLengthPassword = 6;
            public const int UserMaxLengthPassword = 18;

            public const int UserLengthPhoneNumber = 10;
        }

        public class Cause
        {
            public const int CauseMinLengthName = 5;
            public const int CauseMaxLengthName = 30;

            public const int CauseMinLengthPlace = 5;
            public const int CauseMaxLengthPlace = 30;

            public const int CauseMinLengthDescription = 20;
            public const int CauseMaxLengthDescription = 400;
        }

        public class Organization
        {
            public const int OrganizationMinLengthName = 5;
            public const int OrganizationMaxLengthName = 30;

            public const int OrganizationMinLengthHeadquarter = 5;
            public const int OrganizationMaxLengthHeadquarter = 30;

            public const int OrganizationMinLengthDescription = 20;
            public const int OrganizationMaxLengthDescription = 400;
        }

        public class Category
        {
            public const int CategoryMinLengthName = 5;
            public const int CategoryMaxLengthName = 30;

            public const int CategoryMinLengthDescription = 20;
            public const int CategoryMaxLengthDescription = 400;
        }
    }
}
