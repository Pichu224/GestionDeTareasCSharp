using ProyectoTareas.Modelos;
using ProyectoTareas.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoTareas.UI
{
    internal class MenuConsola(TareaService servicio)
    {
        private readonly TareaService servicio = servicio;

        public void APP()
        {
            var salir = false;
            while(salir != true)
            {
                MostrarOpciones();
                var opcion = Console.ReadLine();
                switch (opcion)
                {
                    case "1":
                        this.AgregarTarea();
                        break;

                    case "2":
                        this.EliminarTarea();
                        break;

                    case "3":
                        this.MostrarTareas();
                        break;

                    case "4":
                        this.CompletarTarea();
                        break;

                    case "5":
                        salir = true;
                        break;

                    default:
                        Console.WriteLine("\nCaracter inválido, porfavor vuelva a elegir su opción.");
                        break;
                }
            }
            
        }

        public static void MostrarOpciones()
        {
            Console.WriteLine("\n--- MENÚ DE TAREAS ---");
            Console.WriteLine("1. Agregar Tarea");
            Console.WriteLine("2. Eliminar Tarea");
            Console.WriteLine("3. Mostrar Tareas");
            Console.WriteLine("4. Marcar Tarea Como Completada");
            Console.WriteLine("5. Salir");
        }

        public void AgregarTarea()
        {
            Console.WriteLine("\nInserte nombre de la tarea a agregar:");
            String? nombre = Console.ReadLine();

            Tarea? tarea = new(nombre);

            try
            {
                servicio.AgregarTarea(tarea);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public void EliminarTarea()
        {
            Console.WriteLine("\nInserte nombre de la tarea a eliminar:");
            String? nombre = Console.ReadLine();

            servicio.EliminarTarea(nombre);
        }

        public void MostrarTareas()
        {
            var tareas = servicio.ObtenerTareas();
            if (tareas.Count != 0)
            {
                Console.WriteLine("");
                for (int i = 0; i < tareas.Count; i++)
                {
                    Console.WriteLine($"{i}: {tareas[i].GetTitulo()}. Estado: {tareas[i].GetEstado()}");
                }
            }
            else
            {
                Console.WriteLine("\nTodavia no hay tareas en el repositorio.");
            }
        }

        public void CompletarTarea()
        {
            Console.WriteLine("\nInserte nombre de la tarea a completar:");
            String? nombre = Console.ReadLine();

            servicio.MarcarCompletaTarea(nombre);
        }
    }
}
