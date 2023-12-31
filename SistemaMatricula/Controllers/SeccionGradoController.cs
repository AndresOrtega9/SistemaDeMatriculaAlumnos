﻿using SistemaMatricula.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaMatricula.Controllers
{
    public class SeccionGradoController : Controller
    {
        // GET: SeccionGrado
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ListarSeccionGrado()
        {
            ModeloDeDatosDataContext db = new ModeloDeDatosDataContext();
            var lista = (from gsec in db.GradoSeccion
                         join sec in db.Seccion
                         on gsec.IIDSECCION equals sec.IIDSECCION
                         join grad in db.Grado
                         on gsec.IIDGRADO equals grad.IIDGRADO
                         where gsec.BHABILITADO.Equals(1)
                         select new
                         {
                             gsec.IID,
                             NOMBRESECCION = sec.NOMBRE,
                             NOMBREGRADO = grad.NOMBRE,
                         }).ToList();

            return Json(lista, JsonRequestBehavior.AllowGet);
        }

        public JsonResult RecuperarInformacion(int id)
        {
            ModeloDeDatosDataContext db = new ModeloDeDatosDataContext();
            var gs = db.GradoSeccion.Where(g => g.IID.Equals(id))
                .Select(g => new
                {
                    g.IID,
                    g.IIDGRADO,
                    g.IIDSECCION
                }).ToList();
            return Json(gs, JsonRequestBehavior.AllowGet);
        }

        public JsonResult listarSeccion()//DropDownList de seccion
        {
            ModeloDeDatosDataContext db = new ModeloDeDatosDataContext();
            var lista = db.Seccion.Where(s => s.BHABILITADO.Equals(1))
                .Select(s => new { s.IIDSECCION, s.NOMBRE }).ToList();
            return Json(lista, JsonRequestBehavior.AllowGet);
        }

        public JsonResult listarGrado()//DropDownList de grado
        {
            ModeloDeDatosDataContext db = new ModeloDeDatosDataContext();
            var lista = db.Grado.Where(g => g.BHABILITADO.Equals(1))
                .Select(g => new { g.IIDGRADO, g.NOMBRE }).ToList();
            return Json(lista, JsonRequestBehavior.AllowGet);
        }

        public int Guardar(GradoSeccion gradoSeccion)
        {
            ModeloDeDatosDataContext db = new ModeloDeDatosDataContext();
            var numeroDeRegistrosAfectados=0;

            try
            {
                if (gradoSeccion.IID==0)
                {
                    db.GradoSeccion.InsertOnSubmit(gradoSeccion);
                    db.SubmitChanges();
                    numeroDeRegistrosAfectados = 1;
                }
                else
                {
                    GradoSeccion seleccionado = db.GradoSeccion.Where(g => g.IID.Equals(gradoSeccion.IID)).First();
                    seleccionado.IIDGRADO = gradoSeccion.IIDGRADO;
                    seleccionado.IIDSECCION = gradoSeccion.IIDSECCION;
                    db.SubmitChanges();
                    numeroDeRegistrosAfectados = 1;
                }
            }catch(Exception ex)
            {
                numeroDeRegistrosAfectados = 0;
            }

            return numeroDeRegistrosAfectados;
        }

        public int Eliminar(GradoSeccion gradoSeccion)
        {
            ModeloDeDatosDataContext db = new ModeloDeDatosDataContext();
            var numeroDeRegistrosAfectados = 0;

            try
            {
                var seleccionado = db.GradoSeccion.Where(gs => gs.IID.Equals(gradoSeccion.IID)).First();
                seleccionado.BHABILITADO = gradoSeccion.BHABILITADO = 0;
                db.SubmitChanges();
                numeroDeRegistrosAfectados = 1;

            }catch(Exception ex)
            {
                numeroDeRegistrosAfectados = 0;
            }
            return numeroDeRegistrosAfectados;
        }
    }
}