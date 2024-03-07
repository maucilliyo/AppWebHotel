using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppHotel.Models
{
    public class Factura
    {
        public int IdFactura { get; set; }
        public int IdReserva { get; set; }
        public string CodigoReserva { get; set; }
        public int CantidadPersonas { get; set; }
        public float PrecioTotal { get; set; }
        public DateTime FechaFactura { get; set; }
        public string Detalle { get; set; }
    }
}
