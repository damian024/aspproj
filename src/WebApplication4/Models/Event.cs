using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApplication4.Validators;

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

        [DateValidator(ErrorMessage = "Wrong date!")]
        public string StartDate { get; set; }

        public ICollection<EventSponsor> EventSponsors { get; set; }
    }
}
