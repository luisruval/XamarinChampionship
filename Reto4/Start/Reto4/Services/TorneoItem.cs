using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;

namespace Reto4.Services
{
    public class TorneoItem
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

        public string Reto { get; set; }
        public string DeviceId { get; set; }

        [Version]
        public string Version { get; set; }

    }
}
