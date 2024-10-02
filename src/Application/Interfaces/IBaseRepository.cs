using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        T? GetById(int id);
        List<T> GetAll();
        T Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void SaveChanges ();
    }
}
