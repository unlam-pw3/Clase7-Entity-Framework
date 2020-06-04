using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class LocalRepository : BaseRepository<Local>
    {
        public LocalRepository(PracticaEFEntities context) : base(context)
        {
            
        }
        public override void Eliminar(int id)
        {
            //Obtengo el local a eliminar
            Local localAEliminar = ObtenerPorId(id);
            //Remuevo los productos relacionados a ese local
            localAEliminar.Producto.Clear();
            //Elimino el local
            ctx.Local.Remove(localAEliminar);
            ctx.SaveChanges();
        }
    }
}
