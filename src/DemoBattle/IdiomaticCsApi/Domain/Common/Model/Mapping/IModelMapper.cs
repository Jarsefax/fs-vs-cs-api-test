using System.Collections.Generic;

namespace IdiomaticCsApi.Domain.Common.Model.Mapping
{
    public interface IModelMapper<in TSource, out TResult>
    {
        TResult Map(TSource source);
        IEnumerable<TResult> Map(IEnumerable<TSource> source);
    }
}
