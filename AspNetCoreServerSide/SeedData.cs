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
            if (context.Demos.Any())
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
                    NestedLevelOne = new DemoNestedLevelOneEntity
                    {
                        Experience = null,
                        Extn = null,
                        NestedLevelTwo = new DemoNestedLevelTwoEntity
                        {
                            StartDate = null,
                            Salary = null
                        }
                    }
                },
                new DemoEntity {
                    Name = "Angelica Ramos",
                    Position = "Chief Executive Officer (CEO)",
                    Office = "London",
                    NestedLevelOne = new DemoNestedLevelOneEntity
                    {
                        Experience = 1,
                        Extn = 5797,
                        NestedLevelTwo = new DemoNestedLevelTwoEntity
                        {
                            StartDate = new DateTime(2009,10,09),
                            Salary = 1200000
                        }
                    }
                },
                new DemoEntity {
                    Name = "Ashton Cox",
                    Position = "Junior Technical Author",
                    Office = "San Francisco",
                    NestedLevelOne = new DemoNestedLevelOneEntity
                    {
                        Experience = 2,
                        Extn = 1562,
                        NestedLevelTwo = new DemoNestedLevelTwoEntity
                        {
                            StartDate = new DateTime(2009,01,12),
                            Salary = 86000
                        }
                    }
                },
                new DemoEntity {
                    Name = "Bradley Greer",
                    Position = "Software Engineer",
                    Office = "London",
                    NestedLevelOne = new DemoNestedLevelOneEntity
                    {
                        Experience = 3,
                        Extn = 2558,
                        NestedLevelTwo = new DemoNestedLevelTwoEntity
                        {
                            StartDate = new DateTime(2012,10,13),
                            Salary = 132000
                        }
                    }
                },
                new DemoEntity {
                    Name = "Brenden Wagner",
                    Position = "Software Engineer",
                    Office = "San Francisco",
                    NestedLevelOne = new DemoNestedLevelOneEntity
                    {
                        Experience = 4,
                        Extn = 1314,
                        NestedLevelTwo = new DemoNestedLevelTwoEntity
                        {
                            StartDate = new DateTime(2011,06,07),
                            Salary = 206850
                        }
                    }
                },
                new DemoEntity {
                    Name = "Brielle Williamson",
                    Position = "Integration Specialist",
                    Office = "New York",
                    NestedLevelOne = new DemoNestedLevelOneEntity
                    {
                        Experience = 5,
                        Extn = 4804,
                        NestedLevelTwo = new DemoNestedLevelTwoEntity
                        {
                           StartDate = new DateTime(2012,12,02),
                           Salary = 372000
                        }
                    }
                },
                new DemoEntity {
                    Name = "Bruno Nash",
                    Position = "Software Engineer",
                    Office = "London",
                    NestedLevelOne = new DemoNestedLevelOneEntity
                    {
                        Experience = 6,
                        Extn = 6222,
                        NestedLevelTwo = new DemoNestedLevelTwoEntity
                        {
                            StartDate = new DateTime(2011,05,03),
                            Salary = 163500
                        }
                    }
                },
                new DemoEntity {
                    Name = "Caesar Vance",
                    Position = "Pre-Sales Support",
                    Office = "New York",
                    NestedLevelOne = new DemoNestedLevelOneEntity
                    {
                        Experience = 7,
                        Extn = 8330,
                        NestedLevelTwo = new DemoNestedLevelTwoEntity
                        {
                            StartDate = new DateTime(2011,12,12),
                            Salary = 106450
                        }
                    }
                },
                new DemoEntity {
                    Name = "Cara Stevens",
                    Position = "Sales Assistant",
                    Office = "New York",
                    NestedLevelOne = new DemoNestedLevelOneEntity
                    {
                        Experience = 8,
                        Extn = 3990,
                        NestedLevelTwo = new DemoNestedLevelTwoEntity
                        {
                            StartDate = new DateTime(2011,12,06),
                            Salary = 145600
                        }
                    }
                },
                new DemoEntity {
                    Name = "Cedric Kelly",
                    Position = "Senior Javascript Developer",
                    Office = "Edinburgh",
                    NestedLevelOne = new DemoNestedLevelOneEntity
                    {
                        Experience = 9,
                        Extn = 6224,
                        NestedLevelTwo = new DemoNestedLevelTwoEntity
                        {
                            StartDate = new DateTime(2012,03,29),
                            Salary = 433060
                        }
                    }
                }
            };

            context.Demos.AddRange(testData);

            await context.SaveChangesAsync();
        }
    }
}
