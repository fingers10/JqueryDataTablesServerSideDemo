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
                    FirstName = "Airi",
                    LastName = "Satou",
                    Position = Position.Accountant,
                    Office = "Tokyo",
                    DemoNestedLevelOne = new DemoNestedLevelOneEntity
                    {
                        Experience = null,
                        Extn = null,
                        DemoNestedLevelTwo = new DemoNestedLevelTwoEntity
                        {
                            StartDate = null,
                            Salary = null
                        }
                    }
                },
                new DemoEntity {
                    FirstName = "Angelica",
                    LastName = "Ramos",
                    Position = Position.ChiefExecutiveOfficer,
                    Office = "London",
                    DemoNestedLevelOne = new DemoNestedLevelOneEntity
                    {
                        Experience = 1,
                        Extn = 5797,
                        DemoNestedLevelTwo = new DemoNestedLevelTwoEntity
                        {
                            StartDate = new DateTime(2009,10,09),
                            Salary = 1200000
                        }
                    }
                },
                new DemoEntity {
                    FirstName = "Ashton",
                    LastName = "Cox",
                    Position = Position.JuniorTechnicalAuthor,
                    Office = "San Francisco",
                    DemoNestedLevelOne = new DemoNestedLevelOneEntity
                    {
                        Experience = 2,
                        Extn = 1562,
                        DemoNestedLevelTwo = new DemoNestedLevelTwoEntity
                        {
                            StartDate = new DateTime(2009,01,12),
                            Salary = 86000
                        }
                    }
                },
                new DemoEntity {
                    FirstName = "Bradley",
                    LastName = "Greer",
                    Position = Position.SoftwareEngineer,
                    Office = "London",
                    DemoNestedLevelOne = new DemoNestedLevelOneEntity
                    {
                        Experience = 3,
                        Extn = 2558,
                        DemoNestedLevelTwo = new DemoNestedLevelTwoEntity
                        {
                            StartDate = new DateTime(2012,10,13),
                            Salary = 132000
                        }
                    }
                },
                new DemoEntity {
                    FirstName = "Brenden",
                    LastName = "Wagner",
                    Position = Position.SoftwareEngineer,
                    Office = "San Francisco",
                    DemoNestedLevelOne = new DemoNestedLevelOneEntity
                    {
                        Experience = 4,
                        Extn = 1314,
                        DemoNestedLevelTwo = new DemoNestedLevelTwoEntity
                        {
                            StartDate = new DateTime(2011,06,07),
                            Salary = 206850
                        }
                    }
                },
                new DemoEntity {
                    FirstName = "Brielle",
                    LastName = "Williamson",
                    Position = Position.IntegrationSpecialist,
                    Office = "New York",
                    DemoNestedLevelOne = new DemoNestedLevelOneEntity
                    {
                        Experience = 5,
                        Extn = 4804,
                        DemoNestedLevelTwo = new DemoNestedLevelTwoEntity
                        {
                           StartDate = new DateTime(2012,12,02),
                           Salary = 372000
                        }
                    }
                },
                new DemoEntity {
                    FirstName = "Bruno",
                    LastName = "Nash",
                    Position = Position.SoftwareEngineer,
                    Office = "London",
                    DemoNestedLevelOne = new DemoNestedLevelOneEntity
                    {
                        Experience = 6,
                        Extn = 6222,
                        DemoNestedLevelTwo = new DemoNestedLevelTwoEntity
                        {
                            StartDate = new DateTime(2011,05,03),
                            Salary = 163500
                        }
                    }
                },
                new DemoEntity {
                    FirstName = "Caesar",
                    LastName = "Vance",
                    Position = Position.PreSalesSupport,
                    Office = "New York",
                    DemoNestedLevelOne = new DemoNestedLevelOneEntity
                    {
                        Experience = 7,
                        Extn = 8330,
                        DemoNestedLevelTwo = new DemoNestedLevelTwoEntity
                        {
                            StartDate = new DateTime(2011,12,12),
                            Salary = 106450
                        }
                    }
                },
                new DemoEntity {
                    FirstName = "Cara",
                    LastName = "Stevens",
                    Position = Position.SalesAssistant,
                    Office = "New York",
                    DemoNestedLevelOne = new DemoNestedLevelOneEntity
                    {
                        Experience = 8,
                        Extn = 3990,
                        DemoNestedLevelTwo = new DemoNestedLevelTwoEntity
                        {
                            StartDate = new DateTime(2011,12,06),
                            Salary = 145600
                        }
                    }
                },
                new DemoEntity {
                    FirstName = "Cedric",
                    LastName = "Kelly",
                    Position = Position.SeniorJavascriptDeveloper,
                    Office = "Edinburgh",
                    DemoNestedLevelOne = new DemoNestedLevelOneEntity
                    {
                        Experience = 9,
                        Extn = 6224,
                        DemoNestedLevelTwo = new DemoNestedLevelTwoEntity
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
