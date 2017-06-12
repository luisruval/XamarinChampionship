using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;

namespace RegistroXamarinChampionship.Services
{
    public class ServiceHelper
    {
        MobileServiceClient clienteServicio = new MobileServiceClient(@"http://registrofinalxamarinchampions.azurewebsites.net");

        private IMobileServiceTable<DevItem> _DevItemTable;

        public async Task InsertarEntidad(
            string Nombre, string Apellido, string Email, string Invitacion, 
            int Participacion, string Estacionamiento, string AndroidId)
        {
            _DevItemTable = clienteServicio.GetTable<DevItem>();

            string RegistroParticipacion = "Remoto";

            if(Participacion == 1)
            {
                RegistroParticipacion = "Presencial";
            }

            try
            {
                await _DevItemTable.InsertAsync(new DevItem
                {
                    Nombre = Nombre,
                    Apellido = Apellido,
                    Email = Email,
                    Invitacion = Invitacion,
                    Participacion = RegistroParticipacion,
                    Estacionamiento = Estacionamiento,
                    Text = AndroidId
                });
            }
            catch (System.Exception exc)
            {
                string msg = exc.Message;
            }
          
        }
    }
}
