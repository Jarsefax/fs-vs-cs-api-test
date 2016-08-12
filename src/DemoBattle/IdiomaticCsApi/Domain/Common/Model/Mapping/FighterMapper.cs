using System.Collections.Generic;
using System.Linq;

namespace IdiomaticCsApi.Domain.Common.Model.Mapping
{
    public class FighterMapper : IModelMapper<Fighter, FighterRepresentation>
    {
        public IEnumerable<FighterRepresentation> Map(IEnumerable<Fighter> source) =>
            source.Select(Map);

        public FighterRepresentation Map(Fighter source) =>
            new FighterRepresentation
            {
                Class = source.Class,
                Id = source.Id,
                Name = source.Name
            };
    }
}