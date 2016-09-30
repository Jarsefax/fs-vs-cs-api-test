using System.Collections.Generic;
using IdiomaticCsApi.Domain.Common.Model;
using IdiomaticCsApi.Domain.Common.Model.Mapping;
using IdiomaticCsApi.Domain.Common.Repositories;
using IdiomaticCsApi.Domain.Villains.Model;
using IdiomaticCsApi.DTOs;

namespace IdiomaticCsApi.Domain.Villains
{
    public class GetVillainsHandler
    {
        private readonly IRepository<Villain> _repository;
        private readonly IModelMapper<Fighter, FighterRepresentation> _mapper;

        public GetVillainsHandler(IModelMapper<Fighter, FighterRepresentation> mapper, IRepository<Villain> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public IEnumerable<FighterRepresentation> Get() =>
            _mapper.Map(_repository.GetAll());
    }
}