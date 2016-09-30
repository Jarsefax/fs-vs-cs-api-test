using System.Collections.Generic;
using System.Threading.Tasks;

namespace IdiomaticCsApi.Domain.Battles.Fighting
{
    public interface IFightHandler<T>
    {
        Task Resolve(int shortestCount, List<T> aFaction, List<T> bFaction);
    }
}
