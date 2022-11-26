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
                //ImageUrl = "~/images/Organization.jpg",
                OrganizationId = 1
            };

            photosOrgazanizations.Add(photoOrgaznization1);

            var photoOrgaznization2 = new PhotoOrganization()
            {
                Id = 2,
                //ImageUrl = "~/images/Organization2.jpg",
                OrganizationId = 2
            };

            photosOrgazanizations.Add(photoOrgaznization2);

            return photosOrgazanizations;
        }
    }
}
