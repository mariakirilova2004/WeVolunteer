using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeVolunteer.Core.Services;
using WeVolunteer.Core.Services.Category;
using WeVolunteer.Core.Services.User;
using WeVolunteer.Infrastructure.Data;

namespace WeVolunteer.Tests.Mocks
{
    public static class DatabaseMock
    {
        public static WeVolunteerDbContext Instance
        {
            get
            {
                var dbContextOptions = new DbContextOptionsBuilder<WeVolunteerDbContext>()
                    .UseInMemoryDatabase("WeVolunteerInMemoryDb"
                                            + DateTime.Now.Ticks.ToString())
                    .Options;

                return new WeVolunteerDbContext(dbContextOptions, false);
            }
        }

    }
}
