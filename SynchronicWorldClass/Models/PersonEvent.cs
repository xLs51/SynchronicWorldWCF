using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynchronicWorldClass.Models
{
    public class PersonEvent
    {
        [Key]
        public int PersonEventId { get; set; }

        [ForeignKey("Person")]
        public int PersonId { get; set; }
        public virtual Person Person { get; set; }

        [ForeignKey("Event")]
        public int EventId { get; set; }
        public virtual Event Event { get; set; }
    }
}
