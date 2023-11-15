using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DinnerBooking.Infrastructure.Abstraction;

internal sealed class Repository : IRepository
{
    public Task<long> CountAsync<T>()
    {
        throw new NotImplementedException();
    }

    public Task<long> CountAsync<T>(Expression<Func<T, bool>> dataFilters)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync<T>(Expression<Func<T, bool>> dataFilters)
    {
        throw new NotImplementedException();
    }

    public Task<T> GetItemAsync<T>(Expression<Func<T, bool>> dataFilters)
    {
        throw new NotImplementedException();
    }

    public Task<IQueryable<T>> GetItemsAsync<T>(Expression<Func<T, bool>> dataFilters)
    {
        throw new NotImplementedException();
    }

   

    public Task SaveAsync<T>(T data)
    {
        throw new NotImplementedException();
    }

    public void UpdateAsync<T>(Expression<Func<T, bool>> dataFilters, T data)
    {
        throw new NotImplementedException();
    }

    Task<IQueryable<T>> IRepository.GetItemsAsync<T>()
    {
        throw new NotImplementedException();
    }
}
