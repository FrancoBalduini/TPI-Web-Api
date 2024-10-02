using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly ApplicationContext _context;
        private readonly  DbSet<T> _dbset;
        public BaseRepository(ApplicationContext context)
        {
            _context = context;
            _dbset = _context.Set<T>();
        }
        public T Add(T entity) 
        {
            _dbset.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Delete(T entity) 
        {
            _dbset.Remove(entity);
            _context.SaveChanges();
        }
        public List<T> GetAll() 
        {
            return _dbset.ToList();
        }
        public T? GetById(int id) 
        {
            
            return _dbset.Find(id);
            
        }

        public void Update(T entity) 
        {
            _dbset.Update(entity);
            _context.SaveChanges();
        }

        public void SaveChanges() 
        {
            _context.SaveChanges();
        }
    }
}
