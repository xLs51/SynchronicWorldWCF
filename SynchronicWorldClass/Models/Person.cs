using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynchronicWorldClass.Models
{
    public class Person
    {
        [Key]
        public int PersonId { get; set; }
        [Required]
        public String Username { get; set; }
        [Required]
        public String Password { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
        public String LastName { get; set; }
        [Required]
        public String Email { get; set; }
    }
}
