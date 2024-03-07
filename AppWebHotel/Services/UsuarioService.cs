using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Net.Http;
using System;
using System.Text;
using WebAppHotel.Models;
using static System.Net.WebRequestMethods;

namespace AppWebHotel.Services
{
    public class UsuarioService
    {
        private readonly HttpClient _httpClient;
        public UsuarioService(HttpClient httpClient)
        {
                _httpClient = httpClient;
        }
        public async Task<Usuario> IniciarSesion(string usuario, string password)
        {
            AuthenticationRequest authenticationRequest = new()
            { 
               Usuario = usuario,
                Password = password
            };

            HttpResponseMessage response = await _httpClient.PostAsJsonAsync("api/Usuario/Autentificar", authenticationRequest);

            if (response.IsSuccessStatusCode)
            {
                // Lee el contenido de la respuesta
                var user = await response.Content.ReadFromJsonAsync<Usuario>();
                return user;
            }
            else
            {
                Console.WriteLine("Error al llamar a la API: " + response.ReasonPhrase);
            }
            return null;
        }
    }
}
