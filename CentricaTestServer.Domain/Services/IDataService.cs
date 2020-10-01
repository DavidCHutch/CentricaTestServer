using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CentricaTestServer.Domain.Services
{
    public interface IDataService<T>
    {
        Task<IEnumerable<T>> GetAll();

        Task<T> Get(string id);

        Task<T> Create(T entity);

        Task<T> Update(string id, T entity);

        Task<bool> Delete(string id); 
    }
}
