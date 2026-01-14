using ProyectoTareas.Modelos;
using ProyectoTareas.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProyectoTareas.Servicios
{
    internal class TareaService(ITareaRepository repository)
    {
        private readonly ITareaRepository repository = repository;

        public List<Tarea> ObtenerTareas()
        {
            return this.repository.ObtenerTareas();
        }

        public void MarcarCompletaTarea(String? nombreaTarea)
        {
            Tarea? Tarea = this.repository.ObtenerTarea(nombreaTarea);
            if (Tarea != null && nombreaTarea != null &&  this.repository.EstaGuardado(Tarea))
            {
                this.repository.MarcarTareaCompletada(nombreaTarea);
            }
            else
            {
                Console.WriteLine("No existe la tarea con el nombre solicitado en el repositorio.");
            }
        }


        public void EliminarTarea(String? nombreTarea)
        {
            Tarea? Tarea = this.repository.ObtenerTarea(nombreTarea);
            if(Tarea != null && this.repository.EstaGuardado(Tarea))
            {
                this.repository.EliminarTarea(Tarea);
            }
            else
            {
                Console.WriteLine("\nNo existe en el repositorio la tarea solicitada para eliminar.");
            }
        }

        public void AgregarTarea(Tarea tarea) 
        { 
            this.ValidarTarea(tarea);
            this.repository.AgregarTarea(tarea);
        }

        protected void ValidarTarea(Tarea tarea)
        {
           if(this.CondicionDeExcepcion(tarea))
           {
                throw new ArgumentException(" La tarea no cumple con las condiciones necesarias para ser agregada.");
           }
        }

        protected Boolean CondicionDeExcepcion(Tarea tarea)
        {
            return tarea == null || repository.EstaGuardado(tarea) || tarea.Titulo!.Equals(null) || tarea.Titulo!.Equals("");
        }
    }
}
