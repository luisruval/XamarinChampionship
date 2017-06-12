using System;
using Android.App;
using Android.Widget;
using Android.OS;
using RegistroXamarinChampionship.Services;
using Android;

namespace FinalXamarinChampionship
{
    [Activity(Label = "Registro Final Xamarin Championship", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        // Inicio de egistro al Hackathon de Xamarin Championship
        string Nombre = ""; // Ingresa tu nombre
        string Apellido = ""; // Ingresa tus Apellidos
        string Email = ""; // Ingresa tu e-mail donde recibirás la confirmación de registro
        string CodigoInvitacion = ""; // Ingresa el código que recibiste en tu correo de invitación
        int Participacion = 0; // 0 -> Remoto , 1 -> Presencial
        string Estacionamiento = ""; // Ingresa tus placas si requieres utilizar estacionamiento, deja este espacio en blanco si no utilizaras este servicio
        // Fin de registro

        Button btnRegistrar;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            btnRegistrar = FindViewById<Button>(Resource.Id.btnRegistro);
            btnRegistrar.Enabled = true;
            btnRegistrar.Click += btnRegistrar_Click;

        }

        private async void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                ServiceHelper serviceHelper = new ServiceHelper();
                string AndroidId = Android.Provider.Settings.Secure.GetString(ContentResolver, Android.Provider.Settings.Secure.AndroidId);
                btnRegistrar.Enabled = false;

                if (string.IsNullOrEmpty(Email) )
                {
                    Toast.MakeText(this, "Recuerda modificar el código fuente para ingresar tu e-mail", ToastLength.Short).Show();
                }
                else
                {
                    Toast.MakeText(this, "Enviando tu registro", ToastLength.Short).Show();
                    await serviceHelper.InsertarEntidad(Nombre, Apellido, Email, CodigoInvitacion, Participacion, Estacionamiento, AndroidId);
                    Toast.MakeText(this, "Gracias por registrarte a la Final", ToastLength.Long).Show();                    
                }
            }
            catch (Exception exc)
            {
                Toast.MakeText(this, exc.Message, ToastLength.Long).Show();
            }          
        }
    }
}