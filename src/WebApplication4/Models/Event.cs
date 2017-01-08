using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Event
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string About { get; set; }
        public DateTime StartDate { get; set; }

        public ICollection<EventSponsor> EventSponsors { get; set; }
    }
}
