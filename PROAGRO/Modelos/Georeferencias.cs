using System;
using System.ComponentModel.DataAnnotations;

namespace PROAGRO.Modelos
{
    public class Georeferencias
    {
        public Georeferencias()
        {
            this.Id = Guid.NewGuid();
            this.FechaCreacion = DateTime.Now;
            this.Estatus = true;
        }

        public Guid Id { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }
        public Guid IdEstado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public Nullable<DateTime> FechaModificacion { get; set; }
        public bool Estatus { get; set; }

        public virtual Estados Estado { get; set; }
    }
}
