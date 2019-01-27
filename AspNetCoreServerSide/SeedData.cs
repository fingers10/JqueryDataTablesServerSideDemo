using AspNetCoreServerSide.Models;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspNetCoreServerSide
{
    public static class SeedData
    {
        public static async Task InitializeAsync(IServiceProvider services)
        {
            await AddTestData(
                services.GetRequiredService<Fingers10DbContext>());
        }

        public static async Task AddTestData(Fingers10DbContext context)
        {
            if(context.Demos.Any())
            {
                // Already has data
                return;
            }

            var testData = new List<DemoEntity>()
            {
                new DemoEntity {
                    Name = "Airi Satou",
                    Position = "Accountant",
                    Office = "Tokyo",
                    Extn = 5407,
                    StartDate = new DateTime(2008,11,28),
                    Salary = 162700
                },
                new DemoEntity {
                    Name = "Angelica Ramos",
                    Position = "Chief Executive Officer (CEO)",
                    Office = "London",
                    Extn = 5797,
                    StartDate = new DateTime(2009,10,09),
                    Salary = 1200000
                },
                new DemoEntity {
                    Name = "Ashton Cox",
                    Position = "Junior Technical Author",
                    Office = "San Francisco",
                    Extn = 1562,
                    StartDate = new DateTime(2009,01,12),
                    Salary = 86000
                },
                new DemoEntity {
                    Name = "Bradley Greer",
                    Position = "Software Engineer",
                    Office = "London",
                    Extn = 2558,
                    StartDate = new DateTime(2012,10,13),
                    Salary = 132000
                },
                new DemoEntity {
                    Name = "Brenden Wagner",
                    Position = "Software Engineer",
                    Office = "San Francisco",
                    Extn = 1314,
                    StartDate = new DateTime(2011,06,07),
                    Salary = 206850
                },
                new DemoEntity {
                    Name = "Brielle Williamson",
                    Position = "Integration Specialist",
                    Office = "New York",
                    Extn = 4804,
                    StartDate = new DateTime(2012,12,02),
                    Salary = 372000
                },
                new DemoEntity {
                    Name = "Bruno Nash",
                    Position = "Software Engineer",
                    Office = "London",
                    Extn = 6222,
                    StartDate = new DateTime(2011,05,03),
                    Salary = 163500
                },
                new DemoEntity {
                    Name = "Caesar Vance",
                    Position = "Pre-Sales Support",
                    Office = "New York",
                    Extn = 8330,
                    StartDate = new DateTime(2011,12,12),
                    Salary = 106450
                },
                new DemoEntity {
                    Name = "Cara Stevens",
                    Position = "Sales Assistant",
                    Office = "New York",
                    Extn = 3990,
                    StartDate = new DateTime(2011,12,06),
                    Salary = 145600
                },
                new DemoEntity {
                    Name = "Cedric Kelly",
                    Position = "Senior Javascript Developer",
                    Office = "Edinburgh",
                    Extn = 6224,
                    StartDate = new DateTime(2012,03,29),
                    Salary = 433060
                }
            };

            context.Demos.AddRange(testData);

            await context.SaveChangesAsync();
        }
    }
}
