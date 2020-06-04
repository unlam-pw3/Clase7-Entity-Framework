using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClaseEntityFramework.Controllers
{
    public class LocalesController : Controller
    {
        ProductoRepository prodRepository;
        LocalRepository localRepository;
        public LocalesController()
        {
            PracticaEFEntities ctx = new PracticaEFEntities();
            prodRepository = new ProductoRepository(ctx);
            localRepository = new LocalRepository(ctx);
        }

        // GET: Locales
        public ActionResult Index()
        {
            return View(localRepository.ObtenerTodos());
        }

        public ActionResult Crear()
        {
            ViewBag.Productos = prodRepository.ObtenerTodos();
            return View();
        }

        [HttpPost]
        public ActionResult Crear(Local local, int[] IdProductos)
        {
            ViewBag.Productos = prodRepository.ObtenerTodos();
            List<Producto> prodSeleccionados = prodRepository.ObtenerPorId(IdProductos);

            foreach (Producto p in prodSeleccionados)
            {
                p.Local.Add(local);
            }
            localRepository.Crear(local);

            return RedirectToAction("Index");
        }

        public ActionResult Eliminar(int id)
        {
            localRepository.Eliminar(id);
            return RedirectToAction("Index");
        }

    }
}