SynchronicWorldWCF
======

SynchronicWorldWCF is a web service WCF and a console application made with C#.

It is a Proof of Concept of an event management system.

Functionalities
------------

- CRUD operation for an event.
- CRUD operation for a person.

- Event :
  - Retrieve events by its name or a date.
  - Retrieve all events between two dates.
  - Retrieve all events by status or type.
  - Delete all closed events.
  - Update all events that have a pending status to open.
  
- Person :
  - Add a person to an open event.
  - Retrieve all the persons link to an open event.  
  
- Contribution :  
  - Retrieve all the contributions for an event
  - Retrieve all the contributions of a person for all events.
  - Delete all the contributions of a person for all open events.

Installation
------------

Download this project and open it in Visual Studio 2013.

In order to consume the web service WCF with the console application, you need to start a new instance of SynchronicWorldWCF first and then to start SynchronicWorldConsole.

------------
###### SUPINFO Project - 4NET - 04/2015
