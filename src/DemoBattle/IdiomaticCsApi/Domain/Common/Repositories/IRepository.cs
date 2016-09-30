using System.Collections.Generic;

namespace IdiomaticCsApi.Domain.Common.Repositories
{
    public interface IRepository<out T>
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetByIds(IEnumerable<int> ids);
    }
}
