using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClaseEntityFramework.Controllers
{
    public class ProductosController : Controller
    {
        ProductoRepository prodRepository = new ProductoRepository();
        MarcaRepository marcaRepository = new MarcaRepository();

        // GET: Productos
        public ActionResult Index()
        {
            List<Producto> productos = prodRepository.ObtenerTodos();
            return View(productos);
        }

        [HttpGet]
        public ActionResult Crear()
        {
            List<Marca> todasLasMarcas = marcaRepository.ObtenerTodos();
            ViewBag.TodasLasMarcas = todasLasMarcas;
            return View();
        }

        [HttpPost]
        public ActionResult Crear(Producto prod)
        {
            if (ModelState.IsValid)
            {
                prodRepository.Crear(prod);
                return RedirectToAction("Index");
            }
            else
            {
                return View(prod);
            }
        }

        [HttpGet]
        public ActionResult Modificar(int id)
        {
            Producto prod = prodRepository.ObtenerPorId(id);
            if (prod == null)
            {
                return RedirectToAction("Index");
            }
            return View(prod);
        }

        [HttpPost]
        public ActionResult Modificar(Producto prod)
        {
            prodRepository.Modificar(prod);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            prodRepository.Eliminar(id);
            
            return RedirectToAction("Index");
        }
    }
}