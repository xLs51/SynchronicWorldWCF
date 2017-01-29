using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynchronicWorldClass.Models
{
    public class Contribution
    {
        [Key]
        public int ContributionId { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
        public String Quantity { get; set; }

        [ForeignKey("TypeContribution")]
        public int TypeContributionId { get; set; }
        public virtual TypeContribution TypeContribution { get; set; }

        [ForeignKey("Person")]
        public int PersonId { get; set; }
        public virtual Person Person { get; set; }

        [ForeignKey("Event")]
        public int EventId { get; set; }
        public virtual Event Event { get; set; }
    }
}
