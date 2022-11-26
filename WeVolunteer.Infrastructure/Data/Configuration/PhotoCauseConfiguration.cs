using Grpc.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using WeVolunteer.Infrastructure.Data.Entities;

namespace WeVolunteer.Infrastructure.Data.Configuration
{
    internal class PhotoCauseConfiguration : IEntityTypeConfiguration<PhotoCause>
    {
        public void Configure(EntityTypeBuilder<PhotoCause> builder)
        {
            builder.HasData(CreatePhotosCauses()); ;
        }

        private List<PhotoCause> CreatePhotosCauses()
        {
            var photosCauses = new List<PhotoCause>();


            var photoCause1 = new PhotoCause()
            {

                Id = 1,
                //ImageUrl = "~/images/1.jpg",
                CauseId = 1
            };

            photosCauses.Add(photoCause1);

            var photoCause2 = new PhotoCause()
            {
                Id = 2,
                //ImageUrl = "~/images/2.jpg",
                CauseId = 3
            };

            photosCauses.Add(photoCause2);

            var photoCause3 = new PhotoCause()
            {
                Id = 3,
                //ImageUrl = "~/images/3.jpg",
                CauseId = 2
            };

            photosCauses.Add(photoCause3);

            var photoCause4 = new PhotoCause()
            {
                Id = 4,
                //ImageUrl = "~/images/4.jpg",
                CauseId = 3
            };

            photosCauses.Add(photoCause4);

            var photoEvent5 = new PhotoCause()
            {
                Id = 5,
                //ImageUrl = "~/images/5.jpg",
                CauseId = 4
            };

            photosCauses.Add(photoEvent5);

            return photosCauses;
        }
        

    }
}
