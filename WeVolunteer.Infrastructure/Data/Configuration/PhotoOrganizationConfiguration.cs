using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeVolunteer.Infrastructure.Data.Entities;

namespace WeVolunteer.Infrastructure.Data.Configuration
{
    internal class PhotoOrganizationConfiguration : IEntityTypeConfiguration<PhotoOrganization>
    {
        public void Configure(EntityTypeBuilder<PhotoOrganization> builder)
        {
            builder.HasData(CreatePhotosOrganizations());
        }

        private List<PhotoOrganization> CreatePhotosOrganizations()
        {
            var photosOrgazanizations = new List<PhotoOrganization>();

            var photoOrgaznization1 = new PhotoOrganization()
            {
                Id = 1,
                ImageUrl = "~/images/Organization.jpg",
                UserId = "deal12856-c198-4129-b3f3-b893d8395082"
            };

            photosOrgazanizations.Add(photoOrgaznization1);

            return photosOrgazanizations;
        }
    }
}
