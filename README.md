10/03/2026 17:12

Este fue el proyecto realizado para la compañia Henniges Automotive en el año 2023-24.
Algunos archivos fueron modificiados para evitar mostrar información sensible perteneciente
a la empresa.

22/03/2026

Honestamente olvidé por completo redactar las funciones del código, asi que es lo que haré el dia de hoy.
<img width="277" height="206" alt="image" src="https://github.com/user-attachments/assets/799050fe-7b64-4f0e-be44-153d6cb6991b" />

Pantalla de inicio de sesión en donde se selecciona la planta y solo el departamento de sistemas puede iniciar sesión.

<img width="277" height="206" alt="image" src="https://github.com/user-attachments/assets/659f19fc-86fa-4de4-a1b7-90aea81d35b4" />

Excepción controlada al fallar la validación de credenciales.

<img width="662" height="378" alt="image" src="https://github.com/user-attachments/assets/4456ca18-ec5f-441c-a615-cf123ec7a46e" />

Esta es la interface principal donde se aprecia lo siguiente:
- Pestaña de archivo.
- Pestaña "Acerca De".
- Pestaña de asignación de equipo.
- Pestaña de devolución de equipo.
- Pestaña de reportes.
- Barra de busqueda de usuario.
- Tabla que muestra los equipos asignados al usuario.
- Barra de busqueda de equipo.
- Tabla que muestra los usuarios que poseen el equipo.
- Botón de asignar y firmar.

<img width="662" height="378" alt="image" src="https://github.com/user-attachments/assets/6414d820-241f-467b-a5e6-84528cd4529e" />

Ejemplo de la consulta de un usuario y un equipo.

<img width="231" height="263" alt="image" src="https://github.com/user-attachments/assets/f797314d-d367-41be-ae5e-a9a8c9e4ab26" />

Ejemplo de la interfaz de firma con ambos campos llenos (firma virtual).

<img width="559" height="723" alt="image" src="https://github.com/user-attachments/assets/11ee60dc-88b6-48e0-88e7-16471fb541df" />

Ejemplo de la responsiva creada con la info buscada en las bases de datos y las firmas digitales.

Este documento se abre en Word (de forma externa) junto a un dialogo donde se confirma que los datos sean correctos para ser insertados en la base de datos.

Hasta aquí explico la función principal, ya que el sistema tiene más funciones pero no quisiera explicar toda una wiki sobre el mismo... 
Con las otras pestañas del programa uno se puede dar a la idea del resto.
Naturalmente, el programa tambien tiene atrapado de excepciones tanto internas como externas (especificamente en cuanto a las bases de datos y conexiones se refiere).
