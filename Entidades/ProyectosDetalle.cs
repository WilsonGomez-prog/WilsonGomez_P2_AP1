using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WilsonGomez_P2_AP1.Entidades
{
    public class ProyectosDetalle
    {
        [Key]
        public int DetalleId { get; set; }
        public int ProyectoId { get; set; }
        public int TipoTareaId { get; set; }
        public string Requerimiento { get; set; }
        public int Tiempo { get; set; }

        public ProyectosDetalle()
        {
            DetalleId = 0;
            ProyectoId = 0;
            TipoTareaId = 0;
            Requerimiento = "";
            Tiempo = 0;
        }

        public ProyectosDetalle(int detalleId, int proyectoId, int tipoTareaId, string requerimiento, int tiempo)
        {
            DetalleId = detalleId;
            ProyectoId = proyectoId;
            TipoTareaId = tipoTareaId;
            Requerimiento = requerimiento;
            Tiempo = tiempo;
        }
    }
}
