# copilot-software-architecture-demo

Este repositorio contiene el proyecto de demostración de las características y funcionalidades de GitHub Copilot aplicadas al desarrollo de arquitectura de software. Utilizando la herramienta GitHub Copilot Chat, se construyen una serie de documentos y lineamientos que permiten desarrollar un sistema de software desde cero.

El objetivo de este práctico de demostración es mostrar cómo utilizar GitHub Copilot para generar diagramas de caso de uso, de secuencia y de clases, así como construir una estructura base empleando la arquitectura hexagonal. Estas herramientas y enfoques permiten visualizar y diseñar eficientemente el sistema de software, facilitando la comunicación y colaboración entre los miembros del equipo de desarrollo. Además, GitHub Copilot agiliza el proceso de escritura de código al proporcionar sugerencias y completar automáticamente fragmentos de código, lo que aumenta la productividad y reduce los errores. Este práctico está orientado a ingenieros de sistemas con experiencia en arquitectura de software.

## Contenido


## Paso 1. Definiendo el contexto. 

Para las tareas de arquitectura, es importante proporcionar el contexto de lo que necesitamos que copilot haga por nosotros, para ello es recomendable que se construyan prompts en donde indiquemos el tipo de usuario que hace uso de la herramienta, asi como una explicación detallada y el rol que tomara copilot para definir y contruir la arquitectura de la aplicacion que realizaremos.

Trabajaremos sobre los siguientes prompts base:

### Contexto base del usuario

Se define un contexto base, que le indique a GitHub Copilot el tipo de usuario que lo utiliza, su rol y una serie de tareas que se necesitan completar. De forma que GitHub Copilot ajuste el nivel de conocimiento, el area del conocimiento y los tipos de respuesta que seran devueltos.

> 💡 **Tip**
>
> Finalizar los prompts con una pregunta, es una buena practica para que el modelo de lenguaje natural permanezca abierto a nuevos prompts, de forma que se establece una interaccion humano-maquina mas fluida y precisa.

**Prompt 1.**
```
Hi.! My name is Pablo, i'm a Software Engineer and I have a role as a Software Architect in my team. I want you to help me with some tasks related with software architecture and software design. Are you capable of that?. I know that you can write code, so i was thinking that you can help me to create documentation of a project using markdown files and also creating diagramas using code with tools like Mermaid or PlantUML. Also i want to generate code structures with an architecture called "Hexagonal Architecture", i haven't defined which programming language we are gonna use but probabily will be a oriented programing language. The diagrams that i have in mind are use case diagrams, sequence diagrams, class diagrams and maybe a Entity Relationship diagram. Probably i'm gonna need a couple of UML diagrams more but i'm ok with the current ones. Could you help me with this? Can you help me with these tasks if I provide you a context?
```

_Respuesta de Copilot_

```
Yes, I can help you with these tasks. Please provide the context or specific requirements for the documentation, diagrams, or code structures you need assistance with.
```

Notese, que copilot queda abierto y disponible para completar solicitudes posteriores, esto es lo que se quiere lograr al proporcionar el contexto base.

### Contexto base de la problematica a resolver

Se define el contexto del software/modulo/sistema/aplicación que se requiera desarrollar, con el objetivo de proporcionar a Copilot la información necesaria para que nos ayude a generar la documentación correspondiente. En este punto es muy importante, tratar de proporcionar el mayor detalle posible, por lo que mientras mas caracteristicas, reglas de negocio y restricciones indiquemos, mas eficiente seran las sugerencias que nos responda el modelo de lenguaje natural sobre el que funciona GitHub Copilot.

**Prompt 2.**
```
Ok this is the Requirement:

A web application needs to be created with the purpose of enabling the creation of online events. An event is defined as a record where there is an online video conference room, a date indicating when the event will occur, a list of attendees, and a user who is the creator or organizer of the event. This application does not need to create a video conferencing system from scratch; simply, during the event registration, an automatic URL link to a Google Meet video chat room will be generated, so creating video conference rooms is not within the scope of this project. This application also needs to send email invitations for the event to each of the attendees. These emails will contain the event information and a web link to the application URL where they can accept or decline the invitation.

Business rules or restrictions:

- A user account must be created to use the application.
Registered users can create events and can be invited to events within the application.
- A user can be the organizer of multiple events and a user can be an attendee of multiple events.
- Users can only view events to which they have been invited.
An event can only be modified or deleted by the user who created it or by a system administrator.
- An event can have two states: active and finished. The active state indicates that the event has not yet occurred, and the finished state indicates that the event has already occurred and thus has ended.
- The system must be accessible from anywhere in the world.
- The administrator user can see all events within the application.
- The administrator user has complete control of the application.
- The administrator user can see a list of all users on the platform.
- The organizer user can see a list of all attendees of the event.
- The attendee user can only see the basic information of the event and cannot see the list of attendees.
- A user cannot delete their account if they are the organizer of active events. To delete the account, all events in which the user is an organizer must have already ended.

Web application modules:

- Content module: Allows listing the events that the user has organized and the events that the user has accepted to attend.
- Event module: Shows the event details. In the case of an organizer user, it will show all the event information and the list of attendees. In the case of an attendee user, it will only show the basic information of the event.
- Account module: Allows the user to manage their account information such as the associated email, username, full name, age, country of residence, phone number, and an option to delete the account.
- Administration module: Accessible only to application administrators. Allows viewing the total list of users, adding users, deleting users, modifying users, and deleting and modifying any event. There is a default administrator user named “admin” with the default password “admin123”. This user will be maintained for development speed; later, a module to manage administrator users will be added, but that is outside the scope of this application.

Now that you have the complete context, do not give me results yet. First, process all the information I have given you, because I will provide you with several subsequent prompts that will indicate the diagrams I need to generate and the documentation I need you to construct using markdown files.
```
Al proporcionar todo el contexto de lo que el negocio nos ha indicado, Github Copilot nos debe responder algo como lo siguiente, indicando que tiene completo contexto de lo proporcionado.

_Respuesta de GitHub Copilot:_
```
Understood. I have processed the information you provided. The requirements and business rules are clear, and I understand the different modules that need to be implemented in the web application. Please proceed with your subsequent prompts, and I will assist you accordingly with generating the necessary diagrams and documentation.
```