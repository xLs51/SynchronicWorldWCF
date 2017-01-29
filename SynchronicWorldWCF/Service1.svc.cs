using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using SynchronicWorldClass.DTO;
using SynchronicWorldClass.Repository;
using SynchronicWorldClass.Translation;

namespace SynchronicWorldWCF
{
    public class Service1 : IService1
    {
        private readonly PersonDbRepository _personDbRepository = new PersonDbRepository();
        private readonly EventDbRepository _eventDbRepository = new EventDbRepository();
        private readonly TypeEventDbRepository _typeEventDbRepository = new TypeEventDbRepository();
        private readonly StatusEventDbRepository _statusEventDbRepository = new StatusEventDbRepository();
        private readonly PersonEventDbRepository _personEventDbRepository = new PersonEventDbRepository();
        private readonly ContributionDbRepository _contributionDbRepository = new ContributionDbRepository();
        private readonly TypeContributionDbRepository _typeContributionDbRepository = new TypeContributionDbRepository();

        public List<PersonDTO> GetAllPerson()
        {
            var persons = _personDbRepository.GetAll();
            return persons.Select(PersonTranslation.PersonToDto).ToList();
        }

        public PersonDTO GetPerson(int id)
        {
            var person = _personDbRepository.Get(id);
            return PersonTranslation.PersonToDto(person);
        }

        public PersonDTO InsertPerson(PersonDTO person)
        {
            _personDbRepository.Insert(PersonTranslation.DtoToPerson(person));
            return person;
        }

        public PersonDTO EditPerson(PersonDTO person)
        {
            _personDbRepository.Edit(PersonTranslation.DtoToPerson(person));
            return person;
        }

        public void RemovePerson(PersonDTO person)
        {
            _personDbRepository.Remove(PersonTranslation.DtoToPerson(person));
        }

        public List<EventDTO> GetAllEvent()
        {
            var events = _eventDbRepository.GetAll();
            return events.Select(EventTranslation.EventToDto).ToList();
        }

        public EventDTO GetEvent(int id)
        {
            var events = _eventDbRepository.Get(id);
            return EventTranslation.EventToDto(events);
        }

        public EventDTO InsertEvent(EventDTO events)
        {
            _eventDbRepository.Insert(EventTranslation.DtoToEvent(events));
            return events;
        }

        public EventDTO EditEvent(EventDTO events)
        {
            _eventDbRepository.Edit(EventTranslation.DtoToEvent(events));
            return events;
        }

        public List<EventDTO> UpdateEventPending()
        {
            var events = _eventDbRepository.UpdatePending();
            return events.Select(EventTranslation.EventToDto).ToList();
        }

        public void RemoveEvent(EventDTO events)
        {
            _eventDbRepository.Remove(EventTranslation.DtoToEvent(events));
        }

        public void RemoveEventClosed()
        {
            _eventDbRepository.RemoveClosed();
        }

        public List<EventDTO> GetEventByName(string name)
        {
            var events = _eventDbRepository.GetByName(name);
            return events.Select(EventTranslation.EventToDto).ToList();
        }

        public List<EventDTO> GetEventByType(string name)
        {
            var events = _eventDbRepository.GetByType(name);
            return events.Select(EventTranslation.EventToDto).ToList();
        }

        public List<EventDTO> GetEventByStatus(string name)
        {
            var events = _eventDbRepository.GetByStatus(name);
            return events.Select(EventTranslation.EventToDto).ToList();
        }

        public List<EventDTO> GetEventByDate(DateTime date)
        {
            var events = _eventDbRepository.GetByDate(date);
            return events.Select(EventTranslation.EventToDto).ToList();
        }

        public List<EventDTO> GetEventBetweenDate(DateTime date1, DateTime date2)
        {
            var events = _eventDbRepository.GetBetweenDate(date1, date2);
            return events.Select(EventTranslation.EventToDto).ToList();
        }

        public List<TypeEventDTO> GetAllTypeEvent()
        {
            var typeEvent = _typeEventDbRepository.GetAll();
            return typeEvent.Select(TypeEventTranslation.TypeEventToDto).ToList();
        }

        public TypeEventDTO GetTypeEventByName(string name)
        {
            var typeEvent = _typeEventDbRepository.GetByName(name);
            return TypeEventTranslation.TypeEventToDto(typeEvent);
        }

        public TypeEventDTO GetTypeEvent(int id)
        {
            var typeEvent = _typeEventDbRepository.Get(id);
            return TypeEventTranslation.TypeEventToDto(typeEvent);
        }

        public TypeEventDTO InsertTypeEvent(TypeEventDTO typeEvent)
        {
            _typeEventDbRepository.Insert(TypeEventTranslation.DtoToTypeEvent(typeEvent));
            return typeEvent;
        }

        public List<StatusEventDTO> GetAllStatusEvent()
        {
            var statusEvents = _statusEventDbRepository.GetAll();
            return statusEvents.Select(StatusEventTranslation.StatusEventToDto).ToList();
        }

        public StatusEventDTO GetStatusEventByName(string name)
        {
            var statusEvents = _statusEventDbRepository.GetByName(name);
            return StatusEventTranslation.StatusEventToDto(statusEvents);
        }

        public StatusEventDTO GetStatusEvent(int id)
        {
            var statusEvents = _statusEventDbRepository.Get(id);
            return StatusEventTranslation.StatusEventToDto(statusEvents);
        }

        public StatusEventDTO InsertStatusEvent(StatusEventDTO statusEvents)
        {
            _statusEventDbRepository.Insert(StatusEventTranslation.DtoToStatusEvent(statusEvents));
            return statusEvents;
        }

        public PersonEventDTO InsertPersonEvent(PersonEventDTO personEvents)
        {
            _personEventDbRepository.Insert(PersonEventTranslation.DtoToPersonEvent(personEvents));
            return personEvents;
        }

        public List<PersonEventDTO> GetPersonEventByEvent(int id)
        {
            var personEvents = _personEventDbRepository.GetByEvent(id);
            return personEvents.Select(PersonEventTranslation.PersonEventToDto).ToList();
        }

        public List<ContributionDTO> GetAllContribution()
        {
            var contribution = _contributionDbRepository.GetAll();
            return contribution.Select(ContributionTranslation.ContributionToDto).ToList();
        }

        public List<ContributionDTO> GetContributionByEvent(int id)
        {
            var contribution = _contributionDbRepository.GetByEvent(id);
            return contribution.Select(ContributionTranslation.ContributionToDto).ToList();
        }

        public List<ContributionDTO> GetContributionByPerson(int id)
        {
            var contribution = _contributionDbRepository.GetByPerson(id);
            return contribution.Select(ContributionTranslation.ContributionToDto).ToList();
        }

        public ContributionDTO InsertContribution(ContributionDTO contribution)
        {
            _contributionDbRepository.Insert(ContributionTranslation.DtoToContribution(contribution));
            return contribution;
        }

        public void RemoveContributionByPerson(int id)
        {
            _contributionDbRepository.RemoveByPerson(id);
        }

        public List<TypeContributionDTO> GetAllTypeContribution()
        {
            var typeContribution = _typeContributionDbRepository.GetAll();
            return typeContribution.Select(TypeContributionTranslation.TypeContributionToDto).ToList();
        }

        public TypeContributionDTO GetTypeContribution(int id)
        {
            var typeContribution = _typeContributionDbRepository.Get(id);
            return TypeContributionTranslation.TypeContributionToDto(typeContribution);
        }

        public TypeContributionDTO InsertTypeContribution(TypeContributionDTO typeContribution)
        {
            _typeContributionDbRepository.Insert(TypeContributionTranslation.DtoToTypeContribution(typeContribution));
            return typeContribution;
        }

        public TypeContributionDTO GetTypeContributionByName(string name)
        {
            var typeContribution = _typeContributionDbRepository.GetByName(name);
            return TypeContributionTranslation.TypeContributionToDto(typeContribution);
        }
    }
}
