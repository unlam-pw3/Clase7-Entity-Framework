using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ProductoRepository
    {
        protected PracticaEFEntities ctx { get; set; }

        public ProductoRepository()
        {
            ctx = new PracticaEFEntities();
        }
        public Producto ObtenerPorId(int id)
        {
            return ctx.Producto.Find(id);
        }

        public List<Producto> ObtenerTodos()
        {
            return ctx.Producto.ToList();
        }

        public void Crear(Producto prod)
        {
            ctx.Producto.Add(prod);

            ctx.SaveChanges();
        }

        public void Eliminar(int id)
        {
            Producto prodAEliminar = ObtenerPorId(id);
            if (prodAEliminar != null)
            {
                ctx.Producto.Remove(prodAEliminar);
            }

            ctx.SaveChanges();
        }
    }
}
