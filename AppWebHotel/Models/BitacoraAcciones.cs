using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebAppHotel.Models
{
    public class BitacoraAcciones
    {
        public ObjectId Id { get; set; } // Identificador único de la entrada en la bitácora (ObjectId si estás utilizando MongoDB)
        public string Usuario { get; set; } // Usuario que realizó la acción
        public string Accion { get; set; } // Descripción de la acción realizada (por ejemplo, "insert", "update", "delete")
        public string Tabla { get; set; } // Nombre de la tabla en la que se realizó la acción
        public DateTime Fecha { get; set; } // Fecha y hora en que se realizó la acción
                                            // Otras propiedades opcionales, como detalles adicionales de la acción, dirección IP del usuario, etc.
    }
}
