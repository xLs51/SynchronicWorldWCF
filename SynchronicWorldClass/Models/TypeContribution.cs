using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynchronicWorldClass.Models
{
    public class TypeContribution
    {
        [Key]
        public int TypeContributionId { get; set; }
        [Required]
        public String Name { get; set; }
    }
}
