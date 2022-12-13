using GeoPetWebApi.Services.output;
using projetoFinal.Controllers;

namespace projetoFinal.Services
{
    public class AddressService {
        private readonly HttpClient _client;
        public AddressService(HttpClient client) {
            _client = client;
        }

        public async Task<AddressOutput> getAddressByLat(double lat, double lon){
            var response = await _client.GetAsync($"https://nominatim.openstreetmap.org/reverse?format=json&lat={lat}&lon={lon}");
            var result = await response.Content.ReadFromJsonAsync<AddressOutput>();
            return result;            
        }

        

    }
};
