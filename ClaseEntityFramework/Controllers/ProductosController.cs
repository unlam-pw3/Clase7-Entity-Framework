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
        ProductoRepository prodRepository;
        MarcaRepository marcaRepository;
        public ProductosController()
        {
            PracticaEFEntities ctx = new PracticaEFEntities();
            prodRepository = new ProductoRepository(ctx);
            marcaRepository = new MarcaRepository(ctx);
        }
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
                if (!string.IsNullOrEmpty(Request["OtraMarca"]))
                {
                    Marca marcaNueva = new Marca();
                    marcaNueva.Nombre = Request["OtraMarca"];
                    marcaRepository.Crear(marcaNueva);
                    prod.Marca = marcaNueva;
                }
                prodRepository.Crear(prod);
                return RedirectToAction("Index");
            }
            else
            {
                List<Marca> todasLasMarcas = marcaRepository.ObtenerTodos();
                ViewBag.TodasLasMarcas = todasLasMarcas;
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

            List<Marca> todasLasMarcas = marcaRepository.ObtenerTodos();
            ViewBag.TodasLasMarcas = todasLasMarcas;

            return View(prod);
        }

        [HttpPost]
        public ActionResult Modificar(Producto prod)
        {
            if (!string.IsNullOrEmpty(Request["OtraMarca"]))
            {
                Marca marcaNueva = new Marca();
                marcaNueva.Nombre = Request["OtraMarca"];
                marcaRepository.Crear(marcaNueva);
                prod.Marca = marcaNueva;
            }

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