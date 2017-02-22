using System;
using Android.App;
using Android.Widget;
using Android.OS;
using RegistroXamarinChampionship.Services;
using Android;

namespace RegistroXamarinChampionship
{
    [Activity(Label = "Registro Xamarin Championship", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {

        string emailRegistro = ""; // Ingresa tu email
        string codigoReto = ""; // El codigo de reto para esta actividad es "registro"

        Button btnRegistrar;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            btnRegistrar = FindViewById<Button>(Resource.Id.btnReportar);
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

                if (string.IsNullOrEmpty(emailRegistro) || string.IsNullOrEmpty(codigoReto))
                {
                    Toast.MakeText(this, "Recuerda modificar el código fuente para ingresar tu e-mail y código de reto", ToastLength.Short).Show();
                }
                else
                {
                    Toast.MakeText(this, "Enviando tu registro", ToastLength.Short).Show();
                    await serviceHelper.InsertarEntidad(emailRegistro, codigoReto, AndroidId);
                    Toast.MakeText(this, "Gracias por registrarte", ToastLength.Long).Show();                    
                }
            }
            catch (Exception exc)
            {
                Toast.MakeText(this, exc.Message, ToastLength.Long).Show();
            }
            

        }
    }
}

