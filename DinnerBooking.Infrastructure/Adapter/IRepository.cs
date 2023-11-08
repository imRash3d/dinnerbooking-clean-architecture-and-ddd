using DinnerBooking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DinnerBooking.Infrastructure.Adapter
{
    public interface IRepository
    {
        Task DeleteAsync<T>(Expression<Func<T, bool>> dataFilters);
        Task<long> CountAsync<T>();
        Task<long> CountAsync<T>(Expression<Func<T, bool>> dataFilters);
        Task<T> GetItemAsync<T>(Expression<Func<T, bool>> dataFilters);
        Task<IQueryable<T>> GetItemsAsync<T>(Expression<Func<T, bool>> dataFilters);
        IQueryable<T> GetItemsAsync<T>();
        Task SaveAsync<T>(T data);
       
        void UpdateAsync<T>(Expression<Func<T, bool>> dataFilters, T data);
    }
}
