using ProyectoTareas.Modelos;
using ProyectoTareas.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoTareas.Repositorios
{
    internal class TareaRepositoryDB(TareasContext context) : ITareaRepository
    {
        private readonly TareasContext tareasContext = context;

        public void AgregarTarea(Tarea tarea)
        {
            tareasContext.Tareas.Add(tarea);
            tareasContext.SaveChanges();
        }

        public void EliminarTarea(Tarea tarea)
        {
            tareasContext.Tareas.Remove(tarea);
            tareasContext.SaveChanges();
        }

        public bool EstaGuardado(Tarea tarea)
        {
            return tareasContext.Tareas.Contains(tarea) || tareasContext.Tareas.Any(t => t.Titulo == tarea.Titulo);
        }

        public void MarcarTareaCompletada(string tarea)
        {
            var aCompletar = this.ObtenerTarea(tarea)!;
            aCompletar.Completarse();
            tareasContext.SaveChanges();
        }

        public Tarea? ObtenerTarea(string? nombre)
        {
            return tareasContext.Tareas.FirstOrDefault(t => t.Titulo == nombre);
        }

        public List<Tarea> ObtenerTareas()
        {
            return [.. tareasContext.Tareas];
        }
    }
}
