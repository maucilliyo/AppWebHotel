using Newtonsoft.Json;
using WebAppHotel.Models;

namespace AppWebHotel.Services
{
    public class TipoHabitacionService
    {
        private readonly HttpClient _httpClient;

        public TipoHabitacionService(HttpClient httpClient)
        {
             _httpClient = httpClient;
        }
        public async Task<TipoHabitacion[]> GetListaAsync()
        {
            var response = await _httpClient.GetAsync("api/TipoHabitacion/Lista");
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TipoHabitacion[]>(responseContent);
        }
    }
}
