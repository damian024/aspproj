using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Sponsor
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        public string Name { get; set; }
        public int About { get; set; }
        public int BranchID { get; set; }

        public Branch Branch { get; set; }
        public ICollection<EventSponsor> EventSponsors { get; set; }
    }
}