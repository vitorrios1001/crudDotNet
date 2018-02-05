using System.Collections.Generic;

namespace CadastroCliente.Data.Interface
{
    public interface IRepository<T> where T : class
    {
        T GetById(int id);

        IEnumerable<T> GetAll(); 

        void Save(T obj); 

        void Delete(int id);

    }
}