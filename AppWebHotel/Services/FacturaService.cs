using Newtonsoft.Json;
using System.Text;
using WebAppHotel.Models;

namespace WebAppHotel.Services
{
    public class FacturaService
    {
        private readonly HttpClient _httpClient;

        public FacturaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<Factura[]> GetFacturasAsync()
        {
            var response = await _httpClient.GetAsync("api/Factura/Lista");
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Factura[]>(responseContent);
        }
        public async Task<string> CrearFacturaAsync(Factura factura)
        {
            var content = new StringContent(JsonConvert.SerializeObject(factura), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("api/Factura/Nuevo", content);
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
