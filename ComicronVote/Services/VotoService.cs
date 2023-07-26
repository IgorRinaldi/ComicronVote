using AutoMapper;
using ComicronVote.DTOs;
using ComicronVote.Models;
using ComicronVote.Repository;

namespace ComicronVote.Services
{
    public class VotoService : IVotoService
    {
        private readonly IVotoRepository _repository;
        private readonly IFilmRepository _filmRepository;
        private readonly IMapper _mapper;

        public VotoService(IVotoRepository repository, IMapper mapper, IFilmRepository filmRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _filmRepository = filmRepository;
        }

        public async Task<IEnumerable<VotoDTO>> GetAllAsync()
        {
            IEnumerable<Voto> list = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<VotoDTO>>(list);
        }

        public Task<IEnumerable<VotoDTO>> GetAllByFilmIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<VotoDTO> GetByIdAsync(Guid id)
        {
            Voto voto = await _repository.GetByIdAsync(id);
            return _mapper.Map<VotoDTO>(voto);
        }

        public async Task InsertAsync(VotoDTO votoDTO)
        {
            Film film = await _filmRepository.GetByCodiceAsync(votoDTO.Codice);

            Voto voto = new Voto();
            voto.FilmId = film.Id;
            voto.voto = 1;

            await _repository.InsertAsync(voto);   
        }

        public async Task<int> SommaVotiByCodiceFilmAsync(string codice)
        {
            return await _repository.SommaVotiByFilmId(codice);
        }
    }
}
