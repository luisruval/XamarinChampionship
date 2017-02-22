using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;

namespace RegistroXamarinChampionship.Services
{
    public class ServiceHelper
    {
        MobileServiceClient clienteServicio = new MobileServiceClient(@"http://xamarinchampions.azurewebsites.net");

        private IMobileServiceTable<TorneoItem> _TorneoItemTable;

        public async Task InsertarEntidad(string direccionCorreo, string reto, string AndroidId)
        {
            _TorneoItemTable = clienteServicio.GetTable<TorneoItem>();

          
            await _TorneoItemTable.InsertAsync(new TorneoItem
            {
                Email = direccionCorreo, 
                Reto = reto,
                DeviceId = AndroidId                
            });
        }
    }
}
