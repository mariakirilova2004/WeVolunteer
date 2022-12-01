using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeVolunteer.Infrastructure.Data.Entities;
using WeVolunteer.Infrastructure.Data.Entities.Account;
using WeVolunteer.Infrastructure.Data.Entities;

namespace WeVolunteer.Infrastructure.Data.Configuration
{
    public class OrganizationConfiguration : IEntityTypeConfiguration<Organization>
    {
        public void Configure(EntityTypeBuilder<Organization> builder)
        {
            builder.HasData(new Organization()
            {
                Id = 2,
                Name = "Admin organization",
                Headquarter = "Sofia, Bulgaria",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt.",
                Photos = new List<PhotoOrganization>(),
                Causes = new List<Cause>(),
                UserId = "deal12856-c198-4129-b3f3-b893d8395082"
            });
        }
    }
}
