using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MileageTracker.Data;

namespace MileageTracker.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MTContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MTContext>>()))
            {
                // Look for any clients.
                if (context.Client.Any())
                {
                    return;   // DB has been seeded
                }

                context.Client.AddRange(
                    new Client
                    {
                        UserID = 1,
                        Name = "Major Client"
                    },
                    new Client
                    {
                        UserID = 1,
                        Name = "Other Client"
                    },
                    new Client
                    {
                        UserID = 1,
                        Name = "Acme Incorporated"
                    },
                    new Client
                    {
                        UserID = 1,
                        Name = "Louis's Dog Walking Services"
                    }

                    );

                context.SaveChanges();
            }
        }
    }
}
