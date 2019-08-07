using System;
using System.Linq;

namespace Ninja.Tmp1
{
    public interface IRepository
    {
        T LoadAsync<T>(Guid id);

        IQueryable<T> Query<T>();
    }
}