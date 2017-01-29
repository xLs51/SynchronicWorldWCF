using SynchronicWorldClass.DTO;
using SynchronicWorldClass.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynchronicWorldClass.Translation
{
    public class PersonTranslation
    {
        public static PersonDTO PersonToDto(Person person)
        {
            return new PersonDTO
            {
                PersonId = person.PersonId,
                Username = person.Username,
                Password = person.Password,
                Name = person.Name,
                LastName = person.LastName,
                Email = person.Email,
            };
        }

        public static Person DtoToPerson(PersonDTO person)
        {
            return new Person
            {
                PersonId = person.PersonId,
                Username = person.Username,
                Password = person.Password,
                Name = person.Name,
                LastName = person.LastName,
                Email = person.Email,
            };
        }
    }
}
