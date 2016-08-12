using System.Collections.Generic;
using IdiomaticCsApi.Domain.Common;
using IdiomaticCsApi.Domain.Common.Model;
using IdiomaticCsApi.Domain.Common.Model.Mapping;
using IdiomaticCsApi.Domain.Villains.Model;
using IdiomaticCsApi.Domain.Villains.Repositories;

namespace IdiomaticCsApi.Domain.Villains
{
    public class VillainGetter
    {
        private readonly IRepository<Villain> _repository;
        private readonly IModelMapper<Fighter, FighterRepresentation> _mapper;

        public VillainGetter(IModelMapper<Fighter, FighterRepresentation> mapper, IRepository<Villain> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public IEnumerable<FighterRepresentation> Get() =>
            _mapper.Map(_repository.GetAll());
    }
}