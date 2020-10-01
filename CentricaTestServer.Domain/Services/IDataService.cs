using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CentricaTestServer.Domain.Services
{
    public interface IDataService<T, K>
    {
        Task<IEnumerable<T>> GetAll();

        Task<T> Get(K id);

        Task<T> Create(T entity);

        Task<T> Update(K id, T entity);

        Task<bool> Delete(K id); 
    }
}
