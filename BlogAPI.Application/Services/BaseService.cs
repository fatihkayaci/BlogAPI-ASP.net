using BlogAPI.Application.Interfaces;
using AutoMapper;
namespace BlogAPI.Application.Services
{
    public abstract class BaseService<TEntity, TDto, TCreateDto, TUpdateDto> : IGenericService<TDto, TCreateDto, TUpdateDto>
    where TEntity : class
    where TDto : class
    where TCreateDto:class
    where TUpdateDto:class
    {
        protected readonly IGenericRepository<TEntity> _repository;
        protected readonly IMapper _mapper;

        protected BaseService(IGenericRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // Basit olanları generic yap
        public virtual async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _repository.DeleteAsync(id);
        }

        public virtual async Task<IEnumerable<TDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<TDto>>(entities);
        }

        public virtual async Task<TDto?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity == null ? null : _mapper.Map<TDto>(entity);
        }
        public virtual async Task<TDto> CreateAsync(TCreateDto dto, CancellationToken cancellationToken = default)
        {
            var entity = _mapper.Map<TEntity>(dto);
            var createdComment = await _repository.CreateAsync(entity);
            return _mapper.Map<TDto>(createdComment);
        }

        // Karmaşık olanları abstract yap - alt sınıflar kendileri yazsın
        public abstract Task<bool> UpdateAsync(int id, TUpdateDto dto, CancellationToken cancellationToken = default);

    }
}