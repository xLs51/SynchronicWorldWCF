using SynchronicWorldClass.DTO;
using SynchronicWorldClass.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynchronicWorldClass.Translation
{
    public class TypeEventTranslation
    {
        public static TypeEventDTO TypeEventToDto(TypeEvent typeEvent)
        {
            return new TypeEventDTO
            {
                TypeEventId = typeEvent.TypeEventId,
                Name = typeEvent.Name,
            };
        }

        public static TypeEvent DtoToTypeEvent(TypeEventDTO typeEvent)
        {
            return new TypeEvent
            {
                TypeEventId = typeEvent.TypeEventId,
                Name = typeEvent.Name,
            };
        }
    }
}
