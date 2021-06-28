using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PROAGRO.Modelos
{
    public class Usuarios
    {
        public Usuarios()
        {
            this.Id = Guid.NewGuid();
            this.FechaCreacion = DateTime.Now;
            this.Estatus = true;
            this.Contrasena = "abcde";
        }

        public Guid Id { get; set; }
        public string Contrasena { get; set; }
        [MaxLength(100)]
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public DateTime FechaCreacion { get; set; }
        public Nullable<DateTime> FechaModificacion { get; set; }
        [MaxLength(15)]
        public string RFC { get; set; }
        public bool Estatus { get; set; }
        public virtual ICollection<Permisos> Permisos { get; set; }

    }
}
