using System.Collections.Generic;
using IdiomaticCsApi.Domain.Common.Model;
using IdiomaticCsApi.Domain.Common.Model.Mapping;
using IdiomaticCsApi.Domain.Heroes.Repositories;

namespace IdiomaticCsApi.Domain.Heroes
{
    public class GetHeroesHandler
    {
        private readonly FighterMapper _mapper;
        private readonly HeroRepository _repository;

        public GetHeroesHandler(FighterMapper mapper, HeroRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public IEnumerable<FighterRepresentation> Get() =>
           _mapper.Map(_repository.GetAll());
    }
}