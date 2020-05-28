using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAL
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class
    {
        protected PracticaEFEntities ctx { get; set; }
        protected DbSet<T> dbSet;

        public BaseRepository(PracticaEFEntities context)
        {
            ctx = context;
            dbSet = ctx.Set<T>();
        }
        public void Crear(T entity)
        {
            dbSet.Add(entity);
            ctx.SaveChanges();
        }

        public void Eliminar(int id)
        {
            T entidadAEliminar = ObtenerPorId(id);
            if (entidadAEliminar != null)
            {
                dbSet.Remove(entidadAEliminar);
                ctx.SaveChanges();
            }
        }

        //public abstract void Modificar(T entity);

        public T ObtenerPorId(int id)
        {
            return dbSet.Find(id);
        }

        public List<T> ObtenerTodos()
        {
            return dbSet.ToList();
        }
    }
}