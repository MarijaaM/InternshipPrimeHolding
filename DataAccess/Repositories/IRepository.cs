using InternshipPrimeHolding.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IRepository<T>
    {
        Task<List<T>> GetAll();
        Task<T?> Get(long id);
        Task <bool> Add(T task);
        Task<bool> Update(long id,T entity);
        Task<bool> Delete(long id);
    }
}
