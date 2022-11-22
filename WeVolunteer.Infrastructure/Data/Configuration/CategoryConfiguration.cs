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
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(CreateCategories());
        }

        private List<Category> CreateCategories()
        {
            var categories = new List<Category>();

            var category1 = new Category()
            {
                Id = 1,
                Name = "Environmental Work",
                Description = "Permaculture Projects, Farming, Ecovillages and Environmental Conservation",
               
            };

            categories.Add(category1);

            var category2 = new Category()
            {
                Id = 2,
                Name = "Animals",
                Description = "Animal Farms, Wildlife Conservation, Animal Rescue and Animal Care"
            };

            categories.Add(category2);

            var category3 = new Category()
            {
                Id = 3,
                Name = "Social Impact",
                Description = "Children and Youth NGOs, Education & Teaching, Community Development, Women’s Empowerment"
            };

            categories.Add(category3);

            var category4 = new Category()
            {
                Id = 4,
                Name = "Health Care",
                Description = "Health Care, Holistic Centers"
            };

            categories.Add(category4);

            var category5 = new Category()
            {
                Id = 5,
                Name = "Tourism",
                Description = "Hostel/Guest House Administration, Digital Marketing, SEO and Web Development"
            };

            categories.Add(category5);

            return categories;
        }
    }
}
