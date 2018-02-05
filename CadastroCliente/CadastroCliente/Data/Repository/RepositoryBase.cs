using System.Collections.Generic;
using System.Linq;
using CadastroCliente.Data.Interface;

namespace CadastroCliente.Data.Repository
{
    public class RepositoryBase<T> : IRepository<T> where T : class
    {
        protected readonly AppDbContext db;
        public T GetById(int id)
        {
            var query = db.Set<T>().Find(id);
            return query;
        }

        public void Save(T obj)
        {
            var query = db.Set<T>().Find(obj);    
            
            if(query == null)
            {
                db.Add(obj);
                db.SaveChanges();                    
            }
            else
            {
                db.Update(obj);
                db.SaveChanges();
            }

            
        }

        public IEnumerable<T> GetAll()
        {
            var query = db.Set<T>().ToList();

            if(query.Any())
                return query;

            return new List<T>();
        }

        public void Delete(int id)
        {
            var obj = db.Set<T>().Find(id);

            if(obj != null)
            {
                db.Remove(obj);
                db.SaveChanges();    
            }
        }
    }
}