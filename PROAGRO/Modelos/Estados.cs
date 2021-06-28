using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PROAGRO.Modelos
{
    public class Estados
    {
        public Estados()
        {
            this.Id = Guid.NewGuid();
            this.FechaCreacion = DateTime.Now;
            this.Estatus = true;
        }

        public Guid Id { get; set; }
        [MaxLength(50)]
        public string NombreLargo { get; set; }
        [MaxLength(10)]
        public string NombreCorto { get; set; }
        public DateTime FechaCreacion { get; set; }
        public Nullable<DateTime> FechaModificacion { get; set; }
        public bool Estatus { get; set; }

        public virtual ICollection<Permisos> Permisos { get; set; }
        public virtual ICollection<Georeferencias> GeoReferencias { get; set; }
    }
}
