using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SynchronicWorldClass.DTO
{
    [DataContract]
    public class TypeEventDTO
    {
        [DataMember]
        public int TypeEventId { get; set; }
        [DataMember]
        public String Name { get; set; }
    }
}
