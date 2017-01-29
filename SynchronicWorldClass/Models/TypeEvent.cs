
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynchronicWorldClass.Models
{
    public class TypeEvent
    {
        [Key]
        public int TypeEventId { get; set; }
        [Required]
        public String Name { get; set; }
    }
}
