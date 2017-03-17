using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Reto3.Services;

namespace Reto3
{
    [Activity(Label = "Registrar datos")]
    public class RegistroActivity : Activity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Registro);
            FindViewById<Button>(Resource.Id.btnRegistro).Click += OnRegistroClick;
        }
    
        async void OnRegistroClick(object sender, EventArgs e)
        {
            try
            {
                ServiceHelper serviceHelper = new ServiceHelper();
                // Retrieve the values the user entered into the UI
                string email = FindViewById<EditText>(Resource.Id.editTextEmail).Text;
                string reto = Intent.GetStringExtra("Reto");
                string AndroidId = Android.Provider.Settings.Secure.GetString(ContentResolver, Android.Provider.Settings.Secure.AndroidId);

                if (string.IsNullOrEmpty(reto))
                {
                    Toast.MakeText(this, "Por favor introduce un correo electrónico válido", ToastLength.Short).Show();
                }
                else
                {
                    Toast.MakeText(this, "Enviando tu registro", ToastLength.Short).Show();
                    await serviceHelper.InsertarEntidad(email, reto, AndroidId);
                    Toast.MakeText(this, "Gracias por registrarte", ToastLength.Long).Show();
                    SetResult(Result.Ok, Intent);
                }                

            }
            catch (Exception exc)
            {
                Toast.MakeText(this, exc.Message, ToastLength.Long).Show();
                SetResult(Result.Canceled, Intent);
            }            
            Finish();
        }
    }
}