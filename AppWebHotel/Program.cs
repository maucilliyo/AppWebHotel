using AppWebHotel;
using AppWebHotel.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using WebAppHotel.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//esto es para registrar los sercicios
builder.Services.AddScoped<FacturaService>();
builder.Services.AddScoped<ReservacionService>();
builder.Services.AddScoped<HabitacionService>();
builder.Services.AddScoped<UsuarioService>();

builder.Services.AddMudServices();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5078/") });

await builder.Build().RunAsync();
