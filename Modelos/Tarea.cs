using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoTareas.Modelos
{
    internal class Tarea
    {
        public int TareaId { get; set; } // Cambiado a propiedad para que EF lo reconozca como clave primaria
        public String? Titulo { get; set; }
        public Boolean Completada { get; set; } = false;
        public DateTime FechaDeCreacion { get; set; } = DateTime.Now;

        public Tarea(String? titulo)
        {
            this.Titulo = titulo;
        }

        public Tarea() { }

        public void Completarse()
        {
            this.Completada = true;
        }

        public String? GetTitulo()
        {
            return Titulo;
        }
        public String GetEstado()
        {
            return Completada ? "Completada" : "Incompleta";
        }
    }
}
