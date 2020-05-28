using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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

            try
            {
                ctx.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }

        public void Modificar(Producto prod)
        {
            Producto prodEnDB = ObtenerPorId(prod.IdProducto);
            if (prodEnDB != null)
            {
                prodEnDB.Precio = prod.Precio;
                prodEnDB.Nombre = prod.Nombre;

                ctx.SaveChanges();
            }
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
