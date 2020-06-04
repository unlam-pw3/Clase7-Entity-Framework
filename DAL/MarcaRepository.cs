using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MarcaRepository : BaseRepository<Marca>
    {
        public MarcaRepository(PracticaEFEntities context) : base(context)
        {
        }

        /// <summary>
        /// Elimina la Marca, elimina todos los Productos de la Marca y también los remueve de los Locales
        /// </summary>
        /// <param name="id">id de la marca a eliminar</param>
        public override void Eliminar(int id)
        {
            //obtengo los productos de la marca a eliminar
            var productosDeMarca = ctx.Producto.Where(o => o.IdMarca == id);
            foreach (Producto prod in productosDeMarca)
            {
                //remuevo estos productos de cada local que lo referencia
                prod.Local.Clear();
                //elimino el producto
                ctx.Producto.Remove(prod);
            }

            //elimino la marca
            base.Eliminar(id);
        }
    }
}
