using SynchronicWorldClass.DTO;
using SynchronicWorldClass.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynchronicWorldClass.Translation
{
    public class PersonEventTranslation
    {
        public static PersonEventDTO PersonEventToDto(PersonEvent personEvent)
        {
            return new PersonEventDTO
            {
                PersonEventId = personEvent.PersonEventId,
                PersonId = personEvent.PersonId,
                EventId = personEvent.EventId,
            };
        }

        public static PersonEvent DtoToPersonEvent(PersonEventDTO personEvent)
        {
            return new PersonEvent
            {
                PersonEventId = personEvent.PersonEventId,
                PersonId = personEvent.PersonId,
                EventId = personEvent.EventId,
            };
        }
    }
}
