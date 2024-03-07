using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppHotel.Models
{
    public class Reserva
    {
        public int IdReserva { get; set; }
        public string CodigoReserva { get; set; }
        public string NombreCliente { get; set; }
        public int IdHabitacion { get; set; }
        public int IdUsuario { get; set; }
        public DateTime FechaEntrada { get; set; }
        public DateTime FechaSalida { get; set; }
        public bool EstadoReservacion { get; set; }
        public Habitacion Habitacion { get; set; }
    }
}
