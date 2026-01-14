using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProyectoTareas.Modelos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ProyectoTareas.Persistencia
{
    internal class TareasContext : DbContext
    {
        // retorna la lista de tareas almacenada en persistencia (base de datos).
        public DbSet<Tarea> Tareas { get; set; }

        // Este método se ejecuta para configurar la conexión
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Leemos el appsettings.json para obtener la cadena de conexión
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) // directorio donde está Program.cs
                .AddJsonFile("appsettings.json")             // archivo JSON con la cadena
                .Build();

            string connectionString = config.GetConnectionString("DefaultConnection")!;

            // Configuramos EF Core para usar SQL Server con esa cadena
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}