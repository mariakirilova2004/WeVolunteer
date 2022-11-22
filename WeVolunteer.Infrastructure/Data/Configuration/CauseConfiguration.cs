using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeVolunteer.Infrastructure.Data.Entities;
using WeVolunteer.Infrastructure.Data.Entities;

namespace WeVolunteer.Infrastructure.Data.Configuration
{
    public class CauseConfiguration : IEntityTypeConfiguration<Cause>
    {
        public void Configure(EntityTypeBuilder<Cause> builder)
        {
            builder.HasData(CreateCauses());
        }

        private List<Cause> CreateCauses()
        {
            var causes = new List<Cause>();

            var cause1 = new Cause()
            {
                Id = 1,
                Name = "Get in the network",
                Place = "Sofia, Bulgaria",
                Time = new DateTime(2001, 1, 1, 10, 0, 0),
                OrganizationId = 1,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                Photos = new List<PhotoCause>(),
                CategoryId = 3
            };

            causes.Add(cause1);

            var cause2 = new Cause()
            {
                Id = 2,
                Name = "Gift giving",
                Place = "Sofia, Bulgaria",
                Time = new DateTime(2001, 2, 1, 10, 0, 0),
                OrganizationId = 1,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                Photos = new List<PhotoCause>(),
                CategoryId = 4
            };

            causes.Add(cause2);

            var cause3 = new Cause()
            {
                Id = 3,
                Name = "Elderly homes improvement",
                Place = "Sofia, Bulgaria",
                Time = new DateTime(2001, 3, 1, 10, 0, 0),
                OrganizationId = 1,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                Photos = new List<PhotoCause>(),
                CategoryId = 1
            };

            causes.Add(cause3);

            var cause4 = new Cause()
            {
                Id = 4,
                Name = "Humans Best friends",
                Place = "Sofia, Bulgaria",
                Time = new DateTime(2001, 4, 1, 10, 0, 0),
                OrganizationId = 1,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                Photos = new List<PhotoCause>(),
                CategoryId = 2
            };

            causes.Add(cause4);

            return causes;
        }
    }
}
