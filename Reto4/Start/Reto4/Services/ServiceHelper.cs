using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;

namespace Reto4.Services
{
    public class ServiceHelper
    {
        MobileServiceClient clienteServicio = new MobileServiceClient(@"http://xamarinchampions.azurewebsites.net");

        private IMobileServiceTable<TorneoItem> _TorneoItemTable;
    }
}
