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
    }
}
