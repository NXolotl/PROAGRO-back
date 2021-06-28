using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROAGRO.Modelos.FrontModels
{
    public class NewUser
    {
        public string Nombre { get; set; }
        public string RFC { get; set; }
        public string Contrasena { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }
}
