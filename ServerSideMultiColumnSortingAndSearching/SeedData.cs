using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;
using ServerSideMultiColumnSortingAndSearching.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServerSideMultiColumnSortingAndSearching
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
                    Name = "Abdul Rahman 1",
                    BirthDate = new DateTime(1993,2,10),
                    BankBalance = 12345678910
                },
                new DemoEntity {
                    Name = "Abdul Rahman 2",
                    BirthDate = new DateTime(1993,2,10),
                    BankBalance = 12345678910
                },
                new DemoEntity {
                    Name = "Abdul Rahman 3",
                    BirthDate = new DateTime(1993,2,10),
                    BankBalance = 12345678910
                },
                new DemoEntity {
                    Name = "Abdul Rahman 4",
                    BirthDate = new DateTime(1993,2,10),
                    BankBalance = 12345678910
                },
                new DemoEntity {
                    Name = "Abdul Rahman 5",
                    BirthDate = new DateTime(1993,2,10),
                    BankBalance = 12345678910
                }
            };

            context.Demos.AddRange(testData);

            await context.SaveChangesAsync();
        }
    }
}
