using System.Collections.Generic;

namespace IdiomaticCsApi.Domain.Battles.Ordering
{
    public interface IOrderer<T>
    {
        IEnumerable<T> OrderDescending(IEnumerable<T> items);
    }
}
