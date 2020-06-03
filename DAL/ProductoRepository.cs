using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ProductoRepository : BaseRepository<Producto>
    {
        public ProductoRepository(PracticaEFEntities context) : base(context)
        {
        }

        public void Modificar(Producto prod)
        {
            Producto prodEnDB = ObtenerPorId(prod.IdProducto);
            if (prodEnDB != null)
            {
                prodEnDB.Precio = prod.Precio;
                prodEnDB.Nombre = prod.Nombre;

                if (prod.Marca != null)
                    prodEnDB.Marca = prod.Marca;
                else
                    prodEnDB.IdMarca = prod.IdMarca;

                ctx.SaveChanges();
            }
        }

        public List<Producto> ObtenerPorMarca(int idMarca)
        {
            //Otra forma a traves de Marca
            //Marca m = ctx.Marca.FirstOrDefault(o => o.IdMarca == idMarca);
            //if (m == null)
            //    return new List<Producto>();
            //return m.Producto.ToList();

            return ctx.Producto.Where(o => o.IdMarca == idMarca).ToList();
        }

    }
}
