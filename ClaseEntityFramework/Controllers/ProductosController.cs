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
        // GET: Productos
        public ActionResult Index()
        {
            ProductoRepository prodRepository = new ProductoRepository();
            List<Producto> productos = prodRepository.ObtenerTodos();
            return View(productos);
        }
    }
}