using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WilsonGomez_P2_AP1.Entidades
{
    public class Proyectos
    {
        [Key]
        public int ProyectoId { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }

        [ForeignKey("ProyectoId")]
        public List<ProyectosDetalle> DetalleProyecto { get; set; }

        public Proyectos()
        {
            ProyectoId = 0;
            Fecha = DateTime.Now;
            Descripcion = "";
            DetalleProyecto = new List<ProyectosDetalle>();
        }

        public Proyectos(int proyectoId, DateTime fecha, string descripcion, List<ProyectosDetalle> detalleProyecto)
        {
            ProyectoId = proyectoId;
            Fecha = fecha;
            Descripcion = descripcion;
            DetalleProyecto = new List<ProyectosDetalle>();
        }
    }
}
