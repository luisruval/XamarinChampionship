# Xamarin Championship

## Reto N

El "Reto N" consiste en habiltiar Notificaciones en un proyecto Xamarin.Android. Los objetivos de este reto son los siguientes:

- Configurar una aplicación Xamarin.Android para recibir Push Notifications
- Registrar tu actividad en la base de datos del campeonato


## Instrucciones

1. Descarga la solución de inicio RetoN\Start\RetoN-Start.sln

2. Compila la solución, esta aplicación carga los items disponibles en una tabla de un Mobile App

    ![Figura 1. Pantalla inicial de la aplicación](https://lruval.blob.core.windows.net/dxdev/xamarinchampionship/reton/img1.png)      
    <br/>

3. Sigue las instrucciones disponibles en la sección **Configure the client project for push notifications** del siguiente [link](https://docs.microsoft.com/en-us/azure/app-service-mobile/app-service-mobile-xamarin-android-get-started-push) https://docs.microsoft.com/en-us/azure/app-service-mobile/app-service-mobile-xamarin-android-get-started-push. En este reto sólo configuremos la aplicación cliente de Xamarin.Android, la configuración del canal de Push Notifications en Azure y el Mobile App Backend ya están listos para ser consumidos

4. En el paso número 4 "Replace the existing ToDoBroadcastReceiver class definition with the following:" se hace referencia a un <PROJECT_NUMBER>, en este caso utiliza el número 511600433704

5. Prueba la aplicación para validar que configuraste correctamente las notificaciones, escribe tu nombre y presiona el butón agregar, deberías de recibir una notificación donde se muestra un ID y tu Nombre.

6. Deberás modificar la plantilla para mostrar notificaciones para que recibas los mensajes de la siguiente manera:

    - Título del mensaje: Championship - Reto N

        ![Figura 2. Pantalla final  de la aplicación mostrando notification Hubs](https://lruval.blob.core.windows.net/dxdev/xamarinchampionship/reton/img2.png)      
    <br/>

7. Ahora que estás utilizando una nueva plantilla, deberás escribir tu correo electrónico y presionar el botón de agregar. Anota muy bien el ID que se muestra en la nueva notificación para que puedas reportar la actividad.

8. En preparación para el último reto de Xamarin Championship, deberás de publicar este proyecto en tu GitHub Personal, te sugerimos utilices como nombre de proyecto "Xamarin Championship Reto N"

9. Inserta un elemento en la base de datos del campeonato (puedes utilizar la aplicación de Registro al Campeonato - Reto 1) con el siguiente formato como código de Reto: "RetoN + ID + URL de GitHub donde se encuentra tu proyecto de Reto N", por ejemplo en este caso reportaríamos esta actividad como:

    - RetoN + 9fcd3 + https://github.com/lruval/XamarinChampionship/tree/master/RetoN/

10. Revisaremos los primeros registros que lleguen a la base de datos del campeonato cuya solución de GitHub compile correctamente y que su ID de registro sea válido en el backend donde está habilitado Push Notifications, los ganadores del Reto N serán anunciados antes de empezar con el Gran Hackathon.

- Nota: Debido a que todos los participantes utilizarán el mismo backend, es posible que recibas múltiples notificaciones cuando los demás Devs completen esta actividad.

Te recomendamos que revises los sigueintes links pues pueden ser de utilidad durante la última actividad:

- https://developer.xamarin.com/guides/xamarin-forms/cloud-services/push-notifications/azure/
- https://docs.microsoft.com/en-us/azure/app-service-mobile/app-service-mobile-xamarin-forms-get-started-push