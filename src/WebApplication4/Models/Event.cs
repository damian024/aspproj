using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Event
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [DisplayName("About Event")]
        public string About { get; set; }
        [DisplayName("Start")]
        public DateTime StartDate { get; set; }

        public ICollection<EventSponsor> EventSponsors { get; set; }
    }
}
