using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Branch
    {
        [Key]
        public int ID { get; set; }
        public int Name { get; set; }
        public int About { get; set; }

        ICollection<Sponsor> Sponsors { get; set; }

    }
}