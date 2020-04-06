using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tarea_01__Listado_Estudiantes_.Models;

namespace Tarea_01__Listado_Estudiantes_.Controllers
{
    public class EstudiantesController : Controller
    {
        public static List<Estudiantes> List_Estudiantes = new List<Estudiantes>();
        Estudiantes Est = new Estudiantes();

        public IActionResult Index(string nom)
        {
           // return View(List_Estudiantes);

            try
            {
                if (nom != null)
                {

                    return View(List_Estudiantes.Where(s => s.Nombre.Contains(nom)));
                }
                else
                {
                    return View(List_Estudiantes);
                }

            }
            catch
            {
                return View();
            }
        }

        
        public IActionResult Agregar_Estudiante()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Est.Matricula = Request.Form["Matricula"];
                    Est.Nombre = Request.Form["Nombre"];
                    Est.Apellido = Request.Form["Apellido"];
                    Est.Genero = Request.Form["Genero"];

                    List_Estudiantes.Add(Est);
                    return View(Est);
                }
                else
                {
                    return View();
                }

            }
            catch
            {
                return View();
            }
        }
    }
}