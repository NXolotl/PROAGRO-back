using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PROAGRO.Modelos
{
    public class Permisos
    {
        public Guid IdUsuario { get; set; }
        public Guid IdEstado { get; set; }
        public virtual Usuarios Usuario { get; set; }
        public virtual Estados Estado { get; set; }
    }
}
