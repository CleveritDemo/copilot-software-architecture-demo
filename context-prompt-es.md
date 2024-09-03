# Aplicacion de registro de eventos

**Requerimiento**

Se necesita crear una aplicacion web con la finalidad de poder crear eventos en linea. Un evento se define como un registro en donde existe una sala de videoconferencia en linea, una fecha la cual indica cuando ocurrira el evento, un listado de asistentes y un usuario creador u organizador del evento. Esta aplicacion no necesita crear un sistema de videoconferencias desde cero, simplemente en el registro del evento se genera un enlace URL automatico hacia una sala de videochat de la plataforma de Google Meet, por lo que crear salas de videoconferencia no esta dentro del alcance de este proyecto. Se necesita tambien que esta aplicación, envie correos electronicos con las invitaciones del evento a cada uno de los asistentes. Estos correos contendran la informacion del evento y un enlace web hacia la URL de aplicacion en donde podran aceptar o rechazar la invitacion.

**Reglas y restricciones del negocio**

1. Se requiere de la creacion de una cuenta de usuario para poder utilizar la aplicacion.
2. Los usuarios registrados pueden crear eventos y pueden ser invitados a eventos dentro de la aplicacion.
3. Un usuario puede ser organizador de multiples eventos y un usuario puede ser asistente de multiples eventos.
4. Los usuarios solo podran visualizar aquellos eventos a los que fueron invitados.
5. Un evento podra ser modificado o eliminado solamente por el usuario organizador que lo creo, o bien por un usuario administrador del sistema.
6. Un evento puede tener dos estados activo y finalizado, el estado activo indica que el evento aun no ha ocurrido y el estado finalizado indica que el evento ya ocurrio y por ende ha finalizado.
7. El sistema debe ser accedido desde cualquier parte del mundo.
8. El usuario administrador puede ver todos los eventos dentro de la aplicacion.
9. El usuario administrador tiene completo control de la aplicacion.
10. El usuario administrador puede ver un listado de todos los usuarios de la plataforma.
11. El usuario organizador puede ver un listado de todos los asistentes del evento.
12. El usuario asistente solo podra ver la informacion basica del evento, no podra ver el listado de asistentes del evento.
13. Un usuario no puede eliminar su cuenta si es organizador de eventos activos. Para eliminar la cuenta todos los eventos en los que el usuario sea un organizador ya deben haber terminado.

**Modulos de la aplicacion web**

1. Modulo de contenido: El cual es un modulo que permite listar los eventos que el usuario ha organizado y los enventos que el usuario ha aceptado ser asistente.
2. Modulo de evento: Es el modulo que muestra el detalle del evento, en el caso de un usuario organizador, mostrara toda la informacion del evento y el listado de asistentes. En el caso de un usuario asistente solo mostrara la informacion basica del evento.
3. Modulo de cuenta: Es un modulo en donde el usuario puede administrar informacion de su cuenta como, el correo electronico asociado, su nombre de usuario, Nombre completo, Edad, pais de residencia, numero de telefono y una opcion de poder eliminar la cuenta.
4. Modulo de administracion: Es un modulo al que solamente acceden los administradores de la aplicacion, en este modulo los adminstradores pueden realizar operaciones como ver el listado total de los usuarios, agregar usuarios, eliminar usuarios, modificar usuarios, eliminar y modificar cualquier evento. Existe un usuario administrador por defecto llamado admin, con la contraseña por defecto admin123. Y se mantendra este usuario mientras tanto por velocidad de desarrollo, posteriormente se agregara un modulo que permita gestionar usuarios administradores pero eso esta fuera del alcance de esta aplicacion.

**Pregunta abierta para GitHub Copilot**

Ahora que tienes el contexto completo, no me des resultados aun, primero procesa toda esta informacion que te he dado, porque te voy a proporcionar varios prompts posteriores que son los que te indicaran los diagramas que requiero generar y la documentacion que requiero que construyas mediante archivos markdown.

