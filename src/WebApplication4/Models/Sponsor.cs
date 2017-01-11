using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WebApplication4.Validators;

namespace WebApplication1.Models
{
    public class Sponsor
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public string About { get; set; }
        public int BranchID { get; set; }

        [DisplayName("REGON")]
        [isRegon(ErrorMessage = "Wrong REGON code!")]
        public string Regon { get; set; }

        [DisplayName("NIP")]
        [isNip(ErrorMessage = "Wrong NIP code!")]
        public string Nip { get; set; }

        public Branch Branch { get; set; }
        public ICollection<EventSponsor> EventSponsors { get; set; }
    }
}