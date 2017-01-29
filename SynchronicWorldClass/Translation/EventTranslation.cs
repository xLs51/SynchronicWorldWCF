using SynchronicWorldClass.DTO;
using SynchronicWorldClass.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynchronicWorldClass.Translation
{
    public class EventTranslation
    {
        public static EventDTO EventToDto(Event events)
        {
            return new EventDTO
            {
                EventId = events.EventId,
                Name = events.Name,
                Address = events.Address,
                Description = events.Description,
                Date = events.Date,
                CreatorId = events.CreatorId,
                TypeEventId = events.TypeEventId,
                StatusEventId = events.StatusEventId,
            };
        }

        public static Event DtoToEvent(EventDTO events)
        {
            return new Event
            {
                EventId = events.EventId,
                Name = events.Name,
                Address = events.Address,
                Description = events.Description,
                Date = events.Date,
                CreatorId = events.CreatorId,
                TypeEventId = events.TypeEventId,
                StatusEventId = events.StatusEventId,
            };
        }
    }
}
