using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;

namespace RegistroXamarinChampionship.Services
{
    public class DevItem
    {
        private string _id;
        private string _email;

        [JsonProperty(PropertyName = "id")]
        public string Id
        {
            get { return _id; }
            set
            {
                _id = value;
            }
        }

        [JsonProperty(PropertyName = "Email")]
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
            }
        }
        public string Text { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Invitacion { get; set; }  //Ejemplo dev001
        public string Participacion { get; set; } //Presencial | Remoto
        public string Estacionamiento { get; set; } //Ingresar placas si quieres utilizar el estacionamiento
        public bool Complete { get; set; }

        [Version]
        public string Version { get; set; }


    }
}
