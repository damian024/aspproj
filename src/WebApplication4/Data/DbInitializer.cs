using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class DbInitializer
    {
        public static void Initialize(EventsDbContext context)
        {
            context.Database.EnsureCreated();

           if (context.Events.Any())
           {
              return;   // DB has been seeded
           }

            var events = new Event[]
            {
                new Event { Name="nowyevent",About="cosidkf",StartDate="2002-09-01 17:30" }
            };
            foreach (Event s in events)
            {
                context.Events.Add(s);
            }
            context.SaveChanges();
        }
    }
}
