using System.Collections.Generic;

namespace CadastroCliente.Data.Interface
{
    public class IRepository<T>
    {
        T GetById(int id);

        IEnumerable<T> GetAll(); 

        void Save(T obj); 

        void Delete(int id);

    }
}