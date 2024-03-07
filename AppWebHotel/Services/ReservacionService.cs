using AppWebHotel.Services;
using Newtonsoft.Json;
using System.Text;
using WebAppHotel.Models;
using static MudBlazor.Colors;

namespace WebAppHotel.Services
{
    public class ReservacionService
    {
        private readonly HttpClient _httpClient;
        private readonly HabitacionService _habitacionService;
        public ReservacionService(HttpClient httpClient, HabitacionService habitacionService)
        {
            _httpClient = httpClient;
            _habitacionService = habitacionService;
        }
        public async Task<List<Reserva>> GetReservacionesAsync()
        {
            List<Reserva> reservaLista = [];

            var response = await _httpClient.GetAsync("api/Reserva/Lista");
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();

            var reservas = JsonConvert.DeserializeObject<Reserva[]>(responseContent);

            foreach (var reserva in reservas)
            {
                var habitacion = await _habitacionService.GetHabitacionesById(reserva.IdHabitacion);

                reserva.Habitacion = habitacion;
                reservaLista.Add(reserva);
            }

            return reservaLista;
        }

        public async Task<string> CrearReservacionAsync(Reserva nuevaReserva)
        {
            var content = new StringContent(JsonConvert.SerializeObject(nuevaReserva), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("api/Reserva/Nuevo", content);
            // Verifica si la solicitud fue exitosa (código de estado 200 OK)
            if (response.IsSuccessStatusCode)
            {
                // La reserva se creó exitosamente, puedes leer el código de reserva del contenido de la respuesta
                var codigoReserva = await response.Content.ReadAsStringAsync();
                Console.WriteLine("La reserva se creó exitosamente. Código de reserva: " + codigoReserva);

                // Devuelve el código de reserva como una cadena
                return codigoReserva;
            }
            else
            {
                // La solicitud no fue exitosa, puedes manejar el error aquí
                Console.WriteLine("Error al crear la reserva. Código de estado: " + response.StatusCode);
                return null; // O devuelve algún valor predeterminado o lanza una excepción, según sea necesario
            }
        }

        public async Task<string> ModificarReservacionAsync(Reserva Reserva)
        {
            var content = new StringContent(JsonConvert.SerializeObject(Reserva), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync("api/Reserva/Actualizar", content);
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
                // La solicitud no fue exitosa, puedes manejar el error aquí
                return null; // O devuelve algún valor predeterminado o lanza una excepción, según sea necesario
            }
        }

        public async Task<Reserva> GetReservacionByCodigoAsync(string codigo)
        {
            // Construir la URL con el código de reserva
            string url = $"api/Reserva/ObtenerPorCodigo{codigo}";

            // Realizar una solicitud GET a la API con el código de reserva
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();

            // Leer el contenido de la respuesta
            var responseContent = await response.Content.ReadAsStringAsync();

            // Deserializar el contenido de la respuesta en un objeto Reserva
            return JsonConvert.DeserializeObject<Reserva>(responseContent);
        }

    }
}
