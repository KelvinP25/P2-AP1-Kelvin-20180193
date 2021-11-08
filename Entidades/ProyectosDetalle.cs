using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2_KELVIN_20180193.Entidades
{
    public class ProyectosDetalle
    {
        [Key]
        public int Id { get; set; }
        public int ProyectoId { get; set; }
        public int TipoTareaId { get; set; }
        public string Requerimiento { get; set; }
        public int Tiempo { get; set; }

        [ForeignKey("TipoTareaId")]

        public TipoTareas TipoTareas { get; set; }
        public Proyectos Proyectos { get; set; }

        public ProyectosDetalle()
        {
            Id = 0;
            ProyectoId = 0;
            TipoTareaId = 0;
            Requerimiento = "";
            Tiempo = 0;
            TipoTareas = null;
            Proyectos = null;
        }
        public ProyectosDetalle(int proyectoid, int tipotareaid, string requerimiento, int tiempo, TipoTareas tipoTareas, Proyectos proyectos)
        {
            Id = 0;
            ProyectoId = proyectoid;
            TipoTareaId = tipotareaid;
            Requerimiento = requerimiento;
            Tiempo = tiempo;
            TipoTareas = tipoTareas;
            Proyectos = proyectos;
        }
    }
}
