using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using SynchronicWorldClass.DTO;

namespace SynchronicWorldWCF
{
    [ServiceContract]
    public interface IService1
    {
        /** Person **/
        [OperationContract]
        List<PersonDTO> GetAllPerson();
        [OperationContract]
        PersonDTO GetPerson(int id);
        [OperationContract]
        PersonDTO InsertPerson(PersonDTO person);
        [OperationContract]
        PersonDTO EditPerson(PersonDTO person);
        [OperationContract]
        void RemovePerson(PersonDTO person);

        /** Event **/
        [OperationContract]
        List<EventDTO> GetAllEvent();
        [OperationContract]
        EventDTO GetEvent(int id);
        [OperationContract]
        EventDTO InsertEvent(EventDTO events);
        [OperationContract]
        EventDTO EditEvent(EventDTO events);
        [OperationContract]
        List<EventDTO> UpdateEventPending();
        [OperationContract]
        void RemoveEvent(EventDTO events);
        [OperationContract]
        void RemoveEventClosed();
        [OperationContract]
        List<EventDTO> GetEventByName(string name);
        [OperationContract]
        List<EventDTO> GetEventByType(string name);
        [OperationContract]
        List<EventDTO> GetEventByStatus(string name);
        [OperationContract]
        List<EventDTO> GetEventByDate(DateTime date);
        [OperationContract]
        List<EventDTO> GetEventBetweenDate(DateTime date1, DateTime date2);

        /** Type Event **/
        [OperationContract]
        List<TypeEventDTO> GetAllTypeEvent();
        [OperationContract]
        TypeEventDTO GetTypeEventByName(string name);
        [OperationContract]
        TypeEventDTO GetTypeEvent(int id);
        [OperationContract]
        TypeEventDTO InsertTypeEvent(TypeEventDTO typeEvent);

        /** Status Event **/
        [OperationContract]
        List<StatusEventDTO> GetAllStatusEvent();
        [OperationContract]
        StatusEventDTO GetStatusEventByName(string name);
        [OperationContract]
        StatusEventDTO GetStatusEvent(int id);
        [OperationContract]
        StatusEventDTO InsertStatusEvent(StatusEventDTO statusEvent);

        /** Person Event **/
        [OperationContract]
        PersonEventDTO InsertPersonEvent(PersonEventDTO personEvent);
        [OperationContract]
        List<PersonEventDTO> GetPersonEventByEvent(int id);

        /** Contribution **/
        [OperationContract]
        List<ContributionDTO> GetAllContribution();
        [OperationContract]
        List<ContributionDTO> GetContributionByEvent(int id);
        [OperationContract]
        List<ContributionDTO> GetContributionByPerson(int id);
        [OperationContract]
        ContributionDTO InsertContribution(ContributionDTO contribution);
        [OperationContract]
        void RemoveContributionByPerson(int id);

        /** Type Contribution **/
        [OperationContract]
        List<TypeContributionDTO> GetAllTypeContribution();
        [OperationContract]
        TypeContributionDTO GetTypeContribution(int id);
        [OperationContract]
        TypeContributionDTO InsertTypeContribution(TypeContributionDTO typeContribution);
        [OperationContract]
        TypeContributionDTO GetTypeContributionByName(string name);
    }
}
