using SynchronicWorldClass.DTO;
using SynchronicWorldClass.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynchronicWorldClass.Translation
{
    public class StatusEventTranslation
    {
        public static StatusEventDTO StatusEventToDto(StatusEvent statusEvent)
        {
            return new StatusEventDTO
            {
                StatusEventId = statusEvent.StatusEventId,
                Name = statusEvent.Name,
            };
        }

        public static StatusEvent DtoToStatusEvent(StatusEventDTO statusEvent)
        {
            return new StatusEvent
            {
                StatusEventId = statusEvent.StatusEventId,
                Name = statusEvent.Name,
            };
        }
    }
}
