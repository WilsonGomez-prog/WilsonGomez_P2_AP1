using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WilsonGomez_P2_AP1.Entidades
{
    public class TiposTarea
    {
        [Key]
        public int TipoId { get; set; }
        public string Descripcion { get; set; }
        

        public TiposTarea()
        {
            TipoId = 0;
            Descripcion = "";
        }

        public TiposTarea(int id, string descripcion)
        {
            TipoId = id;
            Descripcion = descripcion;
        }
    }
}
