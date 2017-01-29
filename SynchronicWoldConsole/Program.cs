using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SynchronicWoldConsole.SynchronicWorldServiceReference;

namespace SynchronicWoldConsole
{
    class Program
    {
        public static Service1Client service = new Service1Client();
        public static string choice = "";

        static void Main(string[] args)
        {
            Initialize();

            do {
                Console.WriteLine("1. Person - Create");
                Console.WriteLine("2. Person - Read");
                Console.WriteLine("3. Person - Update");
                Console.WriteLine("4. Person - Delete");
                Console.WriteLine("");
                Console.WriteLine("5. Event - Create");
                Console.WriteLine("6. Event - Read");
                Console.WriteLine("7. Event - Update");
                Console.WriteLine("8. Event - Delete");
                Console.WriteLine("");
                Console.WriteLine("9. Event - Search by Name");
                Console.WriteLine("10. Event - Search by Date");
                Console.WriteLine("11. Event - Search between two Dates");
                Console.WriteLine("12. Event - Search by Type");
                Console.WriteLine("13. Event - Search by Status");
                Console.WriteLine("14. Event - Delete closed");
                Console.WriteLine("15. Event - Update pending");
                Console.WriteLine("");
                Console.WriteLine("16. Add person to an open event");
                Console.WriteLine("17. Get all person from an open event");
                Console.WriteLine("");
                Console.WriteLine("18. Get all contribution from an event");
                Console.WriteLine("19. Get all contribution of a person for all event");
                Console.WriteLine("20. Delete all contribution of a person for all event");
                Console.WriteLine("");
                Console.WriteLine("0. Exit");

                choice = Console.ReadLine();

                switch (choice) {
                    case "0":
                        Console.WriteLine("Bye.");
                        break;

                    case "1":
                        CreatePerson();
                        break;

                    case "2":
                        ReadPerson();
                        break;

                    case "3":
                        UpdatePerson();
                        break;

                    case "4":
                        DeletePerson();
                        break;

                    case "5":
                        CreateEvent();
                        break;

                    case "6":
                        ReadEvent();
                        break;

                    case "7":
                        UpdateEvent();
                        break;

                    case "8":
                        DeleteEvent();
                        break;

                    case "9":
                        SearchEventByName();
                        break;

                    case "10":
                        SearchEventByDate();
                        break;

                    case "11":
                        SearchEventBetweenDate();
                        break;

                    case "12":
                        SearchEventByType();
                        break;

                    case "13":
                        SearchEventByStatus();
                        break;

                    case "14":
                        RemoveEventClosed();
                        break;

                    case "15":
                        UpdateEventPending();
                        break;

                    case "16":
                        AddPersonToEvent();
                        break;

                    case "17":
                        FindPersonFromEvent();
                        break;

                    case "18":
                        FindContributionFromEvent();
                        break;

                    case "19":
                        FindContributionFromPerson();
                        break;

                    case "20":
                        RemoveContributionFromPerson();
                        break;
                }
            } while (choice != "0");
        }

        private static void Initialize() {
            var type = service.GetAllTypeEvent();
            if (!type.Any())
            {
                var typeEvents = new List<TypeEventDTO>
                {
                    new TypeEventDTO {TypeEventId = 1, Name = "Party"},
                    new TypeEventDTO {TypeEventId = 2,Name = "Seminar"},
                };

                typeEvents.ForEach(x => service.InsertTypeEvent(x));
            }

            var status = service.GetAllStatusEvent();
            if (!status.Any())
            {
                var statusEvents = new List<StatusEventDTO>
                {
                    new StatusEventDTO {StatusEventId = 1, Name = "Pending"},
                    new StatusEventDTO {StatusEventId = 2, Name = "Open"},
                    new StatusEventDTO {StatusEventId = 3, Name = "Close"},
                };

                statusEvents.ForEach(x => service.InsertStatusEvent(x));
            }

            var persons = service.GetAllPerson();
            if (!persons.Any())
            {
                var person = new PersonDTO {PersonId = 1, Username = "Admin", Password = "admin", Name = "Toto", LastName = "Dupont", Email = "Admin@admin.fr"};
                service.InsertPerson(person);
            }

            var events = service.GetAllEvent();
            if (!events.Any())
            {
                var date = new DateTime(2014, 10, 10);
                var person = service.GetAllPerson().FirstOrDefault();
                var party = service.GetTypeEventByName("Party");
                var pending = service.GetStatusEventByName("Pending");
                var closed = service.GetStatusEventByName("Close");

                var eventsList = new List<EventDTO>
                {
                    new EventDTO {EventId = 1, Name = "Event1", Address = "Address1", Description = "Desc1", Date = date, CreatorId = person.PersonId, TypeEventId = party.TypeEventId, StatusEventId = pending.StatusEventId},
                    new EventDTO {EventId = 2, Name = "Event2", Address = "Address2", Description = "Desc2", Date = date, CreatorId = person.PersonId, TypeEventId = party.TypeEventId, StatusEventId = pending.StatusEventId},
                    new EventDTO {EventId = 3, Name = "Event3", Address = "Address3", Description = "Desc3", Date = date, CreatorId = person.PersonId, TypeEventId = party.TypeEventId, StatusEventId = closed.StatusEventId},
                    new EventDTO {EventId = 4, Name = "Event4", Address = "Address4", Description = "Desc4", Date = date, CreatorId = person.PersonId, TypeEventId = party.TypeEventId, StatusEventId = closed.StatusEventId},
                };

                eventsList.ForEach(x => service.InsertEvent(x));
            }
            
            var typeContributions = service.GetAllTypeContribution();
            if (!typeContributions.Any())
            {
                var typeContribution = new TypeContributionDTO {TypeContributionId = 1, Name = "Food & Drink"};
                service.InsertTypeContribution(typeContribution);
            }

            var contributions = service.GetAllContribution();
            if (!contributions.Any())
            {
                var person = service.GetAllPerson().FirstOrDefault();
                var event1 = service.GetEventByName("Event1").FirstOrDefault();
                var event2 = service.GetEventByName("Event2").FirstOrDefault();
                var typeContribution = service.GetTypeContributionByName("Food & Drink");

                var contribution = new List<ContributionDTO>
                {
                    new ContributionDTO {ContributionId = 1, Name = "Cake", Quantity = "1", TypeContributionId = typeContribution.TypeContributionId, PersonId = person.PersonId, EventId = event1.EventId},
                    new ContributionDTO {ContributionId = 2, Name = "Drinks", Quantity = "2", TypeContributionId = typeContribution.TypeContributionId, PersonId = person.PersonId, EventId = event1.EventId},
                    new ContributionDTO {ContributionId = 3, Name = "Musics", Quantity = "3", TypeContributionId = typeContribution.TypeContributionId, PersonId = person.PersonId, EventId = event1.EventId},
                    new ContributionDTO {ContributionId = 4, Name = "Alcohols", Quantity = "4", TypeContributionId = typeContribution.TypeContributionId, PersonId = person.PersonId, EventId = event2.EventId},
                };

                contribution.ForEach(x => service.InsertContribution(x));
            }
        }

        private static void CreatePerson()
        {
            Console.WriteLine("Last Name ?");
            var lastName = Console.ReadLine();

            Console.WriteLine("First Name ?");
            var name = Console.ReadLine();

            Console.WriteLine("Username ?");
            var username = Console.ReadLine();

            Console.WriteLine("Password ?");
            var password = Console.ReadLine();

            Console.WriteLine("Email ?");
            var email = Console.ReadLine();

            var person = new PersonDTO { Username = username, Password = password, Name = name, LastName = lastName, Email = email };
            service.InsertPerson(person);
            Console.WriteLine("Person created !");
        }

        private static void ReadPerson()
        {
            Console.WriteLine("Person List :");
            var persons = service.GetAllPerson().ToList();

            persons.ForEach(x => Console.WriteLine("ID : " + x.PersonId + " - " + x.LastName + " " + x.Name + " " + x.Username + " " + x.Password + " " + x.Email));
            if (!persons.Any())
                Console.WriteLine("No person found !");
        }

        private static void UpdatePerson()
        {
            ReadPerson();
            Console.WriteLine("ID Person ?");
            var id = Convert.ToInt32(Console.ReadLine());          

            var person = service.GetPerson(id);
            Console.WriteLine("Edit the person ID : " + id);
            Console.WriteLine("Press enter to keep the default value");

            Console.WriteLine("Last Name ? Default : " + person.LastName);
            var lastName = Console.ReadLine();
            if (lastName.Equals(""))
                lastName = person.LastName;

            Console.WriteLine("First Name ? Default : " + person.Name);
            var name = Console.ReadLine();
            if (name.Equals(""))
                name = person.Name;

            Console.WriteLine("Username ? Default : " + person.Username);
            var username = Console.ReadLine();
            if (username.Equals(""))
                username = person.Username;

            Console.WriteLine("Password ? Default : " + person.Password);
            var password = Console.ReadLine();
            if (password.Equals(""))
                password = person.Password;

            Console.WriteLine("Email ? Default : " + person.Email);
            var email = Console.ReadLine();
            if (email.Equals(""))
                email = person.Email;

            person.LastName = lastName;
            person.Name = name;
            person.Username = username;
            person.Password = password;
            person.Email = email;
   
            service.EditPerson(person);
            Console.WriteLine("Person updated !");
        }

        private static void DeletePerson()
        {
            ReadPerson();
            Console.WriteLine("ID Person ?");
            var id = Convert.ToInt32(Console.ReadLine());          

            var person = service.GetPerson(id);
            service.RemovePerson(person);
            Console.WriteLine("Person deleted !");
        }

        private static void CreateEvent()
        {
            Console.WriteLine("Name ?");
            var name = Console.ReadLine();

            Console.WriteLine("Address ?");
            var address = Console.ReadLine();

            Console.WriteLine("Description ?");
            var description = Console.ReadLine();

            Console.WriteLine("Date - dd/mm/yyyy ?");
            var date_str = Console.ReadLine();
            var date = Convert.ToDateTime(date_str);

            ReadTypeEvent();
            Console.WriteLine("ID Type Event ?");
            var id_typeEvent = Convert.ToInt32(Console.ReadLine());
            var typeEvent = service.GetTypeEvent(id_typeEvent);

            var statusEvent = service.GetStatusEventByName("Pending");

            ReadPerson();
            Console.WriteLine("ID Person Creator ?");
            var id_person = Convert.ToInt32(Console.ReadLine());
            var person = service.GetPerson(id_person);

            var events = new EventDTO { Name = name, Address = address, Description = description, Date = date, CreatorId = person.PersonId, TypeEventId = typeEvent.TypeEventId, StatusEventId = statusEvent.StatusEventId };
            service.InsertEvent(events);
            Console.WriteLine("Event created !");
        }

        private static void ReadEvent()
        {
            Console.WriteLine("Event List :");
            var events = service.GetAllEvent().ToList();

            events.ForEach(x => Console.WriteLine("ID : " + x.EventId + " - " + x.Name + " " + x.Address + " " + x.Description + " " + x.Date + " " + service.GetTypeEvent(x.TypeEventId).Name + " " + service.GetStatusEvent(x.StatusEventId).Name + " " + service.GetPerson(x.CreatorId).Name));
            if (!events.Any())
                Console.WriteLine("No event found !");
        }

        private static void UpdateEvent()
        {
            ReadEvent();
            Console.WriteLine("ID Event ?");
            var id = Convert.ToInt32(Console.ReadLine());

            var events = service.GetEvent(id);
            Console.WriteLine("Edit the event ID : " + id);
            Console.WriteLine("Press enter to keep the default value");

            Console.WriteLine("Name ? Default : " + events.Name);
            var name = Console.ReadLine();
            if (name.Equals(""))
                name = events.Name;

            Console.WriteLine("Address ? Default : " + events.Address);
            var address = Console.ReadLine();
            if (address.Equals(""))
                address = events.Address;

            Console.WriteLine("Description ? Default : " + events.Description);
            var description = Console.ReadLine();
            if (description.Equals(""))
                description = events.Description;

            Console.WriteLine("Date - dd/mm/yyyy ? Default : " + events.Date);
            var date_str = Console.ReadLine();

            var date = new DateTime();
            if (date_str.Equals(""))
                date = events.Date;
            else
                date = Convert.ToDateTime(date_str);

            ReadTypeEvent();
            Console.WriteLine("ID Type Event ? Default : " + events.TypeEventId);
            var id_typeEvent_str = Console.ReadLine();

            var id_typeEvent = 0;
            if (id_typeEvent_str.Equals(""))
                id_typeEvent = events.TypeEvent.TypeEventId;
            else
                id_typeEvent = Convert.ToInt32(id_typeEvent_str);

            var typeEvent = service.GetTypeEvent(id_typeEvent);

            ReadStatusEvent();
            Console.WriteLine("ID Status Event ? Default : " + events.StatusEventId);
            var id_statusEvent_str = Console.ReadLine();

            var id_statusEvent = 0;
            if (id_statusEvent_str.Equals(""))
                id_statusEvent = events.StatusEvent.StatusEventId;
            else
                id_statusEvent = Convert.ToInt32(id_statusEvent_str);

            var statusEvent = service.GetStatusEvent(id_statusEvent);

            ReadPerson();
            Console.WriteLine("ID Person Creator ? Default : " + events.CreatorId);
            var id_person_str = Console.ReadLine();

            var id_person = 0;
            if (id_person_str.Equals(""))
                id_person = events.CreatorId;
            else
                id_person = Convert.ToInt32(id_person_str);

            var person = service.GetPerson(id_person);

            events.Name = name;
            events.Address = address;
            events.Description = description;
            events.Date = date;
            events.CreatorId = person.PersonId;
            events.TypeEventId = typeEvent.TypeEventId;
            events.StatusEventId = statusEvent.StatusEventId;

            service.EditEvent(events);
            Console.WriteLine("Event updated !");
        }

        private static void DeleteEvent()
        {
            ReadEvent();
            Console.WriteLine("ID Event ?");
            var id = Convert.ToInt32(Console.ReadLine());

            var events = service.GetEvent(id);
            service.RemoveEvent(events);
            Console.WriteLine("Event deleted !");
        }

        private static void SearchEventByName()
        {
            Console.WriteLine("Event name ?");
            var name = Console.ReadLine();

            var events = service.GetEventByName(name).ToList();
            events.ForEach(x => Console.WriteLine("ID : " + x.EventId + " - " + x.Name + " " + x.Address + " " + x.Description + " " + x.Date + " " + service.GetTypeEvent(x.TypeEventId).Name + " " + service.GetStatusEvent(x.StatusEventId).Name + " " + service.GetPerson(x.CreatorId).Name));
            if(!events.Any())
                Console.WriteLine("No event found !");
        }

        private static void SearchEventByDate()
        {
            Console.WriteLine("Event date - dd/mm/yyyy ?");
            var date_str = Console.ReadLine();
            var date = Convert.ToDateTime(date_str);

            var events = service.GetEventByDate(date).ToList();
            events.ForEach(x => Console.WriteLine("ID : " + x.EventId + " - " + x.Name + " " + x.Address + " " + x.Description + " " + x.Date + " " + service.GetTypeEvent(x.TypeEventId).Name + " " + service.GetStatusEvent(x.StatusEventId).Name + " " + service.GetPerson(x.CreatorId).Name));
            if(!events.Any())
                Console.WriteLine("No event found !");
        }

        private static void SearchEventBetweenDate()
        {
            Console.WriteLine("Event date start - dd/mm/yyyy ?");
            var start_str = Console.ReadLine();
            var start = Convert.ToDateTime(start_str);

            Console.WriteLine("Event date end - dd/mm/yyyy ?");
            var end_str = Console.ReadLine();
            var end = Convert.ToDateTime(end_str);

            var events = service.GetEventBetweenDate(start, end).ToList();
            events.ForEach(x => Console.WriteLine("ID : " + x.EventId + " - " + x.Name + " " + x.Address + " " + x.Description + " " + x.Date + " " + service.GetTypeEvent(x.TypeEventId).Name + " " + service.GetStatusEvent(x.StatusEventId).Name + " " + service.GetPerson(x.CreatorId).Name));
            if(!events.Any())
                Console.WriteLine("No event found !");
        }

        private static void SearchEventByType()
        {
            Console.WriteLine("Type name ?");
            var name = Console.ReadLine();

            var events = service.GetEventByType(name).ToList();
            events.ForEach(x => Console.WriteLine("ID : " + x.EventId + " - " + x.Name + " " + x.Address + " " + x.Description + " " + x.Date + " " + service.GetTypeEvent(x.TypeEventId).Name + " " + service.GetStatusEvent(x.StatusEventId).Name + " " + service.GetPerson(x.CreatorId).Name));
            if (!events.Any())
                Console.WriteLine("No event found !");
        }

        private static void SearchEventByStatus()
        {
            Console.WriteLine("Status name ?");
            var name = Console.ReadLine();

            var events = service.GetEventByStatus(name).ToList();
            events.ForEach(x => Console.WriteLine("ID : " + x.EventId + " - " + x.Name + " " + x.Address + " " + x.Description + " " + x.Date + " " + service.GetTypeEvent(x.TypeEventId).Name + " " + service.GetStatusEvent(x.StatusEventId).Name + " " + service.GetPerson(x.CreatorId).Name));
            if (!events.Any())
                Console.WriteLine("No event found !");
        }

        private static void RemoveEventClosed()
        {
            Console.WriteLine("Removing closed event...");
            service.RemoveEventClosed();
            Console.WriteLine("Event removed !");
        }

        private static void UpdateEventPending()
        {
            Console.WriteLine("Updating pending event...");
            var events = service.UpdateEventPending().ToList();

            events.ForEach(x => Console.WriteLine("Upate ID : " + x.EventId));
            if (!events.Any())
                Console.WriteLine("No event found !");
        }

        private static void AddPersonToEvent()
        {
            ReadPerson();
            Console.WriteLine("ID Person ?");
            var id_person = Convert.ToInt32(Console.ReadLine());
            var person = service.GetPerson(id_person);

            var events = service.GetEventByStatus("Open").ToList();
            if (!events.Any())
                Console.WriteLine("No open event found !");
            else
            {
                events.ForEach(x => Console.WriteLine("ID : " + x.EventId + " - " + x.Name + " " + x.Address + " " + x.Description + " " + x.Date + " " + service.GetTypeEvent(x.TypeEventId).Name + " " + service.GetStatusEvent(x.StatusEventId).Name + " " + service.GetPerson(x.CreatorId).Name));
                Console.WriteLine("ID Event ?");
                var id_event = Convert.ToInt32(Console.ReadLine());
                var my_event = service.GetEvent(id_event);

                var personEvent = new PersonEventDTO { PersonId = person.PersonId, EventId = my_event.EventId };
                service.InsertPersonEvent(personEvent);

                Console.WriteLine("Person " + id_person + " added to the event " + id_event + " !");
            }
        }

        private static void FindPersonFromEvent()
        {
            var events = service.GetEventByStatus("Open").ToList();
            if (!events.Any())
                Console.WriteLine("No open event found !");
            else
            {
                events.ForEach(x => Console.WriteLine("ID : " + x.EventId + " - " + x.Name + " " + x.Address + " " + x.Description + " " + x.Date + " " + service.GetTypeEvent(x.TypeEventId).Name + " " + service.GetStatusEvent(x.StatusEventId).Name + " " + service.GetPerson(x.CreatorId).Name));
                Console.WriteLine("ID Event ?");
                var id_event = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Person List from event " + id_event + " :");
                var persons = service.GetPersonEventByEvent(id_event).ToList();

                persons.ForEach(x => Console.WriteLine("ID : " + x.PersonId + " - " + service.GetPerson(x.PersonId).LastName + " " + service.GetPerson(x.PersonId).Name + " " + service.GetPerson(x.PersonId).Username + " " + service.GetPerson(x.PersonId).Password + " " + service.GetPerson(x.PersonId).Email));
                if (!persons.Any())
                    Console.WriteLine("No person found !");
            }           
        }

        private static void FindContributionFromEvent()
        {
            ReadEvent();
            Console.WriteLine("ID Event ?");
            var id_event = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Contribution List from event " + id_event + " :");
            var contributions = service.GetContributionByEvent(id_event).ToList();

            contributions.ForEach(x => Console.WriteLine("ID : " + x.ContributionId + " - " + x.Name + " " + x.Quantity + " " + service.GetTypeContribution(x.TypeContributionId).Name + " " + service.GetPerson(x.PersonId).Name));
            if (!contributions.Any())
                Console.WriteLine("No contribution found !");
        }

        private static void FindContributionFromPerson()
        {
            ReadPerson();
            Console.WriteLine("ID Person ?");
            var id_person = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Contribution List from person " + id_person + " :");
            var contributions = service.GetContributionByPerson(id_person).ToList();

            contributions.ForEach(x => Console.WriteLine("ID : " + x.ContributionId + " - " + x.Name + " " + x.Quantity + " " + service.GetTypeContribution(x.TypeContributionId).Name + " " + service.GetPerson(x.PersonId).Name));
            if (!contributions.Any())
                Console.WriteLine("No contribution found !");
        }

        private static void RemoveContributionFromPerson()
        {
            ReadPerson();
            Console.WriteLine("ID Person ?");
            var id_person = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Removing contribution for person " + id_person + "...");
            service.RemoveContributionByPerson(id_person);
            Console.WriteLine("Contribution removed !");
        }

        private static void ReadTypeEvent()
        {
            Console.WriteLine("Type Event List :");
            service.GetAllTypeEvent().ToList().ForEach(x => Console.WriteLine("ID : " + x.TypeEventId + " - " + x.Name));
        }

        private static void ReadStatusEvent()
        {
            Console.WriteLine("Status Event List :");
            service.GetAllStatusEvent().ToList().ForEach(x => Console.WriteLine("ID : " + x.StatusEventId + " - " + x.Name));
        }
    }
}
