using System;
using Android.App;
using Android.Widget;
using Android.OS;
using Reto5.Services;
using Android;
using Android.Content;
using Android.Runtime;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.Sync;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using System.IO;
using System.Threading.Tasks;

namespace Reto5
{
    [Activity(Label = "Reto 5 - Xamarin Championship", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        //Mobile Service Client reference
        private MobileServiceClient client;

        //Mobile Service sync table used to access data
        private IMobileServiceSyncTable<TorneoItem> torneoItemTable;

        const string applicationURL = @"http://xamarinchampions.azurewebsites.net";
        const string localDbFilename = "localstore.db";
        const string emailParticipante = "";
        const string pais = "mx"; // Consulta el código de país en http://www.worldstandards.eu/other/tlds/
        Button btnRegistro;

        protected async override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            // Create the Mobile Service Client instance, using the provided
            // Mobile Service URL
            client = new MobileServiceClient(applicationURL);

            // Get the Mobile Service sync table instance to use
            torneoItemTable = client.GetSyncTable<TorneoItem>();

            // Obtener una referencia al botón Siguiente
            btnRegistro = FindViewById<Button>(Resource.Id.BtnRegistro);
            // Registrar el manejador de evento click del botón Siguiente
            btnRegistro.Click += BtnSiguienteClick;  
                    
        }

        private async void BtnSiguienteClick(object sender, EventArgs e)
        {
            string AndroidId = Android.Provider.Settings.Secure.GetString(ContentResolver,Android.Provider.Settings.Secure.AndroidId);

            await torneoItemTable.InsertAsync(new TorneoItem
            {
                Email = emailParticipante,
                DeviceId = AndroidId,
                Reto = "Reto5@" + pais
            });   
                            
        }
    }
} 

