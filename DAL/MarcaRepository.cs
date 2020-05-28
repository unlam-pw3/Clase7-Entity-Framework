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
    }
}
