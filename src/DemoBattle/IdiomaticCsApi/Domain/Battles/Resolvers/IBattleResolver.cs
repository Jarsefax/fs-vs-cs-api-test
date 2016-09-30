using System.Collections.Generic;

namespace IdiomaticCsApi.Domain.Battles.Resolvers
{
    public interface IBattleResolver<in T, out TResult>
    {
        TResult Resolve(IEnumerable<T> factionA, IEnumerable<T> factionB);
    }
}
