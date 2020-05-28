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

    }
}
