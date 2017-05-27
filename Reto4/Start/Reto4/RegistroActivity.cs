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
using Reto4.Services;

namespace Reto4
{
    [Activity(Label = "Registrar datos")]
    public class RegistroActivity : Activity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Registro);
            FindViewById<Button>(Resource.Id.btnConsulta).Click += OnBtnConsultaClick;
        }
    
        async void OnBtnConsultaClick(object sender, EventArgs e)
        {
            try
            {
                ServiceHelper serviceHelper = new ServiceHelper();
                // Retrieve the values the user entered into the UI
                string AndroidId = Android.Provider.Settings.Secure.GetString(ContentResolver, Android.Provider.Settings.Secure.AndroidId);


                SetResult(Result.Ok, Intent);

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