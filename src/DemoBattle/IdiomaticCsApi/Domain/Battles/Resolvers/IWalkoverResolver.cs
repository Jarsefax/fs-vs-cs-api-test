using System.Collections.Generic;

namespace IdiomaticCsApi.Domain.Battles.Resolvers
{
    public interface IWalkoverResolver<in T, out TResult>
    {
        TResult GetWalkoverResultOrDefault(IEnumerable<T> heroes, IEnumerable<T> villains);
    }
}