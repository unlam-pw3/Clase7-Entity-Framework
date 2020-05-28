using System.Collections.Generic;

namespace DAL
{
    public interface IRepository<T>
    {
        T ObtenerPorId(int id);
        List<T> ObtenerTodos();
        void Crear(T entity);
        //void Modificar(T entity);
        void Eliminar(int id);

    }
}