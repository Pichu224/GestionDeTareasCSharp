using ProyectoTareas.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProyectoTareas.Repositorios
{
    internal class TareaRepositoryEnMemoria : ITareaRepository
    {
        private readonly List<Tarea> Tareas = [];
        public void AgregarTarea(Tarea tarea)
        {
            Tareas.Add(tarea);
            Console.WriteLine("\nSe agregó la tarea al repositorio.");
        }

        public void EliminarTarea(Tarea tarea)
        {
            Tareas.Remove(tarea);
            Console.WriteLine("\nSe eliminó la tarea del repositorio.");
        }

        public void MarcarTareaCompletada(String tarea)
        {
            Tareas.Find(t => t.Titulo!.Equals(tarea))?.Completarse();
            Console.WriteLine("\nSe marcó la tarea como completada en el repositorio.");
        }

        public Tarea? ObtenerTarea(string? nombre)
        {
            return Tareas.Find(t => t.Titulo!.Equals(nombre));
        }

        public List<Tarea> ObtenerTareas()
        {
            return [.. Tareas];
        }

        public Boolean EstaGuardado(Tarea tarea)
        {
            return Tareas.Contains(tarea);
        }
    }
}
 