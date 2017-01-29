using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SynchronicWorldClass.DTO
{
    [DataContract]
    public class TypeContributionDTO
    {
        [DataMember]
        public int TypeContributionId { get; set; }
        [DataMember]
        public String Name { get; set; }
    }
}
