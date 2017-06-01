using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.WindowsAzure.MobileServices.Sync;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using System.IO;

namespace Reto5.Services
{
    public class ServiceHelper
    {
       //Mobile Service Client reference
        MobileServiceClient client;

        private IMobileServiceSyncTable<TorneoItem> _TorneoItemTable;

        //Mobile Service sync table used to access data
        private IMobileServiceSyncTable<TorneoItem> toDoTable;

        const string localDbFilename = "localstore.db";

        public ServiceHelper()
        {
            CurrentPlatform.Init();
            client = new MobileServiceClient(@"ghttp://xamarinchampions.azurewebsites.net");
            InitLocalStoreAsync().Wait();
            _TorneoItemTable = client.GetSyncTable<TorneoItem>();
        }

        private async Task InitLocalStoreAsync()
        {
            // new code to initialize the SQLite store
            string path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), localDbFilename);

            if (!File.Exists(path))
            {
                File.Create(path).Dispose();
            }

            var store = new MobileServiceSQLiteStore(path);
            store.DefineTable<TorneoItem>();
            await client.SyncContext.InitializeAsync(store);
        }

        public async Task<List<TorneoItem>> BuscarRegistros(string Correo)
        {            
            List<TorneoItem> items = await _TorneoItemTable.Where(
                torneoItem => torneoItem.Email == Correo).ToListAsync();
            return items;
        }

        public async Task InsertarEntidad(string direccionCorreo, string reto, string AndroidId)
        {
            _TorneoItemTable = client.GetSyncTable<TorneoItem>();


            await _TorneoItemTable.InsertAsync(new TorneoItem
            {
                Email = direccionCorreo,
                Reto = reto,
                DeviceId = AndroidId
            });
        }
    }
}
