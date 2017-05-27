using System;
using Android.App;
using Android.Widget;
using Android.OS;
using Reto4.Services;
using Android;
using Android.Content;
using Android.Runtime;

namespace Reto4
{
    [Activity(Label = "Reto 4 - Xamarin Championship", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {

        Button btnSiguiente;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            // Obtener una referencia al botón Siguiente
            btnSiguiente = FindViewById<Button>(Resource.Id.btnSiguiente);
            // Registrar el manejador de evento click del botón Siguiente
            btnSiguiente.Click += BtnSiguienteClick;

            Plugin.Connectivity.CrossConnectivity.Current.ConnectivityChanged += Current_ConnectivityChanged;
        }

        private void Current_ConnectivityChanged(object sender, Plugin.Connectivity.Abstractions.ConnectivityChangedEventArgs e)
        {
            if(Plugin.Connectivity.CrossConnectivity.Current.IsConnected)
            {
                Toast.MakeText(this, "Conectado a Internet", ToastLength.Long).Show();
            }
            else
            {
                Toast.MakeText(this, "No hay una conexión disponible", ToastLength.Long).Show();
            }
        }

        private void BtnSiguienteClick(object sender, EventArgs e)
        {

            if(Plugin.Connectivity.CrossConnectivity.Current.IsConnected)
            {
                Toast.MakeText(this, "Conectado a Internet", ToastLength.Long).Show();
                var intent = new Intent(this, typeof(RegistroActivity));
                intent.PutExtra("Reto", "reto4");
                StartActivityForResult(intent, 1);
            }
            else
            {
                Toast.MakeText(this, "Actualmente no estás conectado a Internet", ToastLength.Long).Show();
            }
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        { 
            // El siguiente código se ejecutará si el registro de la actividad fue exitoso y si la actividad RegistroActivity fue iniciada desde la actividad principal de esta aplicación (código 1)
            if(requestCode == 1 && resultCode == Result.Ok)
            {
                btnSiguiente.Visibility = Android.Views.ViewStates.Invisible;
                //Toast.MakeText(this, "Felicidades! Reto 4 completado.", ToastLength.Long).Show();
            }
        }
    }
} 

