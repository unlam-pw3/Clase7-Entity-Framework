using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
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
            SaveChanges(ctx);
        }

        public virtual void Eliminar(int id)
        {
            T entidadAEliminar = ObtenerPorId(id);
            if (entidadAEliminar != null)
            {
                dbSet.Remove(entidadAEliminar);
                SaveChanges(ctx);
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

        protected void SaveChanges(PracticaEFEntities ctx)
        {
            try
            {
                ctx.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                System.Diagnostics.Debug.WriteLine("");
                System.Diagnostics.Debug.WriteLine("");
                System.Diagnostics.Debug.WriteLine("**** ENTITY FRAMEWORK DETALLE DE EXCEPCION****");

                foreach (var eve in e.EntityValidationErrors)
                {
                    System.Diagnostics.Debug.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        System.Diagnostics.Debug.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }
    }
}