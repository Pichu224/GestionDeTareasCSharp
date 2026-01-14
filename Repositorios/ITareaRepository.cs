using ProyectoTareas.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoTareas.Repositorios
{
    internal interface ITareaRepository
    {
        public List<Tarea> ObtenerTareas();

        public void AgregarTarea(Tarea tarea);

        public void MarcarTareaCompletada(String Tarea);

        public void EliminarTarea(Tarea tarea);

        public Boolean EstaGuardado(Tarea tarea);

        public Tarea? ObtenerTarea(String? nombre); 
    }
}
