using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tarea_01__Listado_Estudiantes_.Models;

namespace Tarea_01__Listado_Estudiantes_.Controllers
{
    public class ProfesoresController : Controller
    {
        public static List<Profesores> List_Profesores = new List<Profesores>();
        Profesores Prof = new Profesores(); 
        public IActionResult Index(string nom)
        {
            try
            {
                if (nom != null)
                {

                    return View(List_Profesores.Where(s => s.Nombre.Contains(nom)));
                }
                else
                {
                    return View(List_Profesores);
                }

            }
            catch
            {
                return View();
            }
        }

        public IActionResult Agregar_Profesor()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Prof.Cedula = Request.Form["Cedula"];
                    Prof.Nombre = Request.Form["Nombre"];
                    Prof.Apellido = Request.Form["Apellido"];
                    Prof.Genero = Request.Form["Genero"];
                    Prof.Asignatura = Request.Form["Asignatura"];

                    List_Profesores.Add(Prof);
                    return View(Prof);
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

        public IActionResult Eliminar_Profesor (string cedu)
            {
                try
                {
                    var pro = List_Profesores.Where(p => p.Cedula == cedu).FirstOrDefault();
                    List_Profesores.Remove(pro);
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
    }
}