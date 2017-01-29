using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SynchronicWorldClass.DTO
{
    [DataContract]
    public class PersonEventDTO
    {
        [DataMember]
        public int PersonEventId { get; set; }

        [DataMember]
        public int PersonId { get; set; }
        [DataMember]
        public virtual PersonDTO Person { get; set; }

        [DataMember]
        public int EventId { get; set; }
        [DataMember]
        public virtual EventDTO Event { get; set; }
    }
}
