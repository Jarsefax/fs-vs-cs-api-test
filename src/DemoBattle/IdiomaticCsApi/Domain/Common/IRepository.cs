using System.Collections.Generic;

namespace IdiomaticCsApi.Domain.Common
{
    public interface IRepository<out T>
    {
        IEnumerable<T> GetAll();
    }
}
