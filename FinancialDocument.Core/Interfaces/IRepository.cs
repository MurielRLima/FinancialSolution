using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinancialDocument.Core.Interfaces
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(Guid id);
        Task Add(T item);
        Task Add(IEnumerable<T> items);
        Task Edit(T item);
        Task Delete(Guid id);
        Task<Boolean> Exist(Guid id);
    }
}
