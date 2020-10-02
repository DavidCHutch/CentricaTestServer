using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CentricaTestServer.DataAccess.DataAccessObjects.Interfaces
{ 
    public interface IDataAccessObject<T, K>
    {
        Task<IEnumerable<T>> GetAll();

        Task<T> Get(K id);

        Task<T> Create(T entity);

        Task<T> Update(K id, T entity);

        Task<bool> Delete(K id); 
    }
}
