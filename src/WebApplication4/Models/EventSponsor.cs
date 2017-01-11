using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class EventSponsor
    {
        [Key]
        public int EventSponsorID { get; set; }
        [Required]
        public int EventID { get; set; }
        [Required]
        public int SponsorID { get; set; }

        public Event Event { get; set; }
        public Sponsor Sponsor { get; set; }
    }
}