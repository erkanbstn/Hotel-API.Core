using ApiConsume.DataAccessLayer.Abstract;
using ApiConsume.DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ApiConsume.DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        private readonly Context _context;
        DbSet<T> _object;

        public GenericRepository(Context context)
        {
            _context = context;
            _object = _context.Set<T>();

        }

        public void Delete(T t)
        {
            _object.Remove(t);
            _context.SaveChanges();
        }

        public T GetById(int id)
        {
            return _object.Find(id);
        }

        public List<T> GetList()
        {
            return  _object.ToList();
        }

        public void Insert(T t)
        {
            _object.Add(t);
            _context.SaveChanges();
        }

        public void Update(T t)
        {
            _object.Update(t);
            _context.SaveChanges();
        }
    }
}
