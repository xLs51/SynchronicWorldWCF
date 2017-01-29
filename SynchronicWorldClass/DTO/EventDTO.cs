using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SynchronicWorldClass.DTO
{
    [DataContract]
    public class EventDTO
    {
        [DataMember]
        public int EventId { get; set; }
        [DataMember]
        public String Name { get; set; }
        [DataMember]
        public String Address { get; set; }
        [DataMember]
        public String Description { get; set; }
        [DataMember]
        public DateTime Date { get; set; }
        
        [DataMember]
        public int CreatorId { get; set; }
        [DataMember]
        public virtual PersonDTO Person { get; set; }

        [DataMember]
        public int TypeEventId { get; set; }
        [DataMember]
        public virtual TypeEventDTO TypeEvent { get; set; }

        [DataMember]
        public int StatusEventId { get; set; }
        [DataMember]
        public virtual StatusEventDTO StatusEvent { get; set; }
    }
}
