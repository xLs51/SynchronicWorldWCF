using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SynchronicWorldClass.DTO
{
    [DataContract]
    public class PersonDTO
    {
        [DataMember]
        public int PersonId { get; set; }
        [DataMember]
        public String Username { get; set; }
        [DataMember]
        public String Password { get; set; }
        [DataMember]
        public String Name { get; set; }
        [DataMember]
        public String LastName { get; set; }
        [DataMember]
        public String Email { get; set; }
    }
}
