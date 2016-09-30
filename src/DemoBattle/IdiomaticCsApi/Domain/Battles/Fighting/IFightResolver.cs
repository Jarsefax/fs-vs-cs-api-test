using System.Collections.Generic;

namespace IdiomaticCsApi.Domain.Battles.Fighting
{
    public interface IFightResolver<T>
    {
        void Resolve(List<T> aFaction, List<T> bFaction);
    }
}
