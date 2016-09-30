using System.Collections.Generic;
using IdiomaticCsApi.Domain.Common.Model;
using IdiomaticCsApi.Domain.Common.Model.Mapping;
using IdiomaticCsApi.Domain.Common.Repositories;
using IdiomaticCsApi.Domain.Heroes.Model;
using IdiomaticCsApi.DTOs;

namespace IdiomaticCsApi.Domain.Heroes
{
    public class GetHeroesHandler
    {
        private readonly IModelMapper<Fighter, FighterRepresentation> _mapper;
        private readonly IRepository<Hero> _repository;

        public GetHeroesHandler(IModelMapper<Fighter, FighterRepresentation> mapper, IRepository<Hero> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public IEnumerable<FighterRepresentation> Get() =>
           _mapper.Map(_repository.GetAll());
    }
}