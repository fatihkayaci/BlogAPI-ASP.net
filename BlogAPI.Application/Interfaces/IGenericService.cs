namespace BlogAPI.Application.Interfaces
{
    public interface IGenericService<TDto, TCreateDto, TUpdateDto> where TDto : class
    {
        Task<TDto?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<IEnumerable<TDto>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<TDto> CreateAsync(TCreateDto dto, CancellationToken cancellationToken = default);
        Task<bool> UpdateAsync(int id, TUpdateDto dto, CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);
    }
}