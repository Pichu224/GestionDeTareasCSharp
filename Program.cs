using ProyectoTareas.Persistencia;
using ProyectoTareas.Repositorios;
using ProyectoTareas.Servicios;
using ProyectoTareas.UI;
using System;

var context = new TareasContext();
// 1. Crear la implementación del repositorio en memoria
var repositorio = new TareaRepositoryDB(context);

// 2. Crear el servicio de tareas, pasándole el repositorio
var tareaService = new TareaService(repositorio);

// 3. Crear el menú de consola, pasándole el servicio
var menu = new MenuConsola(tareaService);

// 4. Ejecutar el menú
menu.APP();
