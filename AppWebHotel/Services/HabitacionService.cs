using AppWebHotel.Pages;
using Newtonsoft.Json;
using System.Text;
using WebAppHotel.Models;
using WebAppHotel.Services;

namespace AppWebHotel.Services
{
    public class HabitacionService
    {
        private readonly HttpClient _httpClient;

        public HabitacionService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<Habitacion[]> GetHabitacionesLibres(DateTime fechaEntrada, DateTime fechaSalida)
        {
            if (fechaEntrada == default || fechaSalida == default)
            {
                throw new ArgumentException("Las fechas de entrada y salida son obligatorias.");
            }

            var queryString = $"?fechaEntrada={fechaEntrada:yyyy-MM-dd 00:00}&fechaSalida={fechaSalida:yyyy-MM-dd 00:00}";

            var response = await _httpClient.GetAsync($"api/Habitacion/ListaLibres{queryString}");
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Habitacion[]>(responseContent);
        }
        public async Task<Habitacion[]> GetHabitaciones()
        {
            var response = await _httpClient.GetAsync($"api/Habitacion/Lista");
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Habitacion[]>(responseContent);
        }
        public async Task<Habitacion> GetHabitacionesById(int id)
        {
            var response = await _httpClient.GetAsync($"api/Habitacion/ObtenerPorId{id}");
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Habitacion>(responseContent);
        }
        public async Task<string> CrearNuevaHabitacion(Habitacion habitacion)
        {
            var content = new StringContent(JsonConvert.SerializeObject(habitacion), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("api/Habitacion/Nuevo", content);
            // Verifica si la solicitud fue exitosa (código de estado 200 OK)
            if (response.IsSuccessStatusCode)
            {
                // La reserva se creó exitosamente, puedes leer el código de reserva del contenido de la respuesta
                var codigoReserva = await response.Content.ReadAsStringAsync();
                // Devuelve el código de reserva como una cadena
                return codigoReserva;
            }
            else
            {
                return null; // O devuelve algún valor predeterminado o lanza una excepción, según sea necesario
            }
        }

    }
}
