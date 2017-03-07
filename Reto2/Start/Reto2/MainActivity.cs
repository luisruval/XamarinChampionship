using System;
using Android.App;
using Android.Widget;
using Android.OS;
using Reto2.Services;
using Android;
using Android.Content;
using Android.Runtime;

namespace Reto2
{
    [Activity(Label = "Reto 2 - Xamarin Championship", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        Button btnSiguiente;
        TextView textViewPrivacidad;
        TextView textViewURLPrivacidad;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            // Obtener una referencia al botón Siguiente
            btnSiguiente = FindViewById<Button>(Resource.Id.btnSiguiente);
            // Registrar el manejador de evento click del botón Siguiente
            btnSiguiente.Click += BtnSiguienteClick;
        }

        private void BtnSiguienteClick(object sender, EventArgs e)
        {

        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            // El siguiente código se ejecutará si el registro de la actividad fue exitoso y si la actividad RegistroActivity fue iniciada desde la actividad principal de esta aplicación (código 1)
            if (requestCode == 1 && resultCode == Result.Ok)
            {
                btnSiguiente.Visibility = Android.Views.ViewStates.Invisible;
                textViewURLPrivacidad.Text = string.Empty;
                textViewPrivacidad.Text = "Haz concluido la actividad. Espera más noticias sobre el próximo reto";
            }
        }
    }
} 

