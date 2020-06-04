using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClaseEntityFramework.Controllers
{
    public class MarcasController : Controller
    {
        MarcaRepository marcaRepository;

        public MarcasController()
        {
            PracticaEFEntities ctx = new PracticaEFEntities();
            marcaRepository = new MarcaRepository(ctx);
        }
        // GET: Marcas
        public ActionResult Index()
        {
            return View(marcaRepository.ObtenerTodos());
        }

        public ActionResult Eliminar(int id)
        {
            Marca marca = marcaRepository.ObtenerPorId(id);
            if (marca != null && marca.Producto.Count > 1)
            {
                TempData["MensajeValidaciones"] = $"No se puede eliminar Marcas con mas de 1 producto ({string.Join(",", marca.Producto.Select(o=> o.Nombre))})";
            }
            else
            {
                marcaRepository.Eliminar(id);
            }

            return RedirectToAction("Index");
        }
    }
}