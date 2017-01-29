using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynchronicWorldClass.Models
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
        public String Address { get; set; }
        [Required]
        public String Description { get; set; }
        [Required]
        public DateTime Date { get; set; }
       
        [ForeignKey("Person")]
        public int CreatorId { get; set; }
        public virtual Person Person { get; set; }

        [ForeignKey("TypeEvent")]
        public int TypeEventId { get; set; }
        public virtual TypeEvent TypeEvent { get; set; }

        [ForeignKey("StatusEvent")]
        public int StatusEventId { get; set; }
        public virtual StatusEvent StatusEvent { get; set; }
    }
}
