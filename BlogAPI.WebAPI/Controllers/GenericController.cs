using BlogAPI.Application.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace BlogAPI.WebAPI.Controllers
{
    [ApiController]
    public abstract class GenericController<TDto, TCreateDto, TUpdateDto>: ControllerBase
    where TDto : class
    where TCreateDto : class
    where TUpdateDto : class
    {
        protected readonly IGenericService<TDto, TCreateDto, TUpdateDto> _service;
        protected readonly IValidator<TCreateDto> _createValidator;
        protected readonly IValidator<TUpdateDto> _updateValidator;
        public GenericController
        (
            IGenericService<TDto, TCreateDto, TUpdateDto> service,
            IValidator<TCreateDto> createValidator,
            IValidator<TUpdateDto> updateValidator
        )
        {
            _service = service;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }
        
        [HttpGet]
        public virtual async Task<ActionResult<IEnumerable<TDto>>> GetAllAsync()
        {
            var entity = await _service.GetAllAsync();
            return Ok(entity);
        }

        [HttpGet("{id}")]
        public virtual async Task<ActionResult<TDto?>> GetByIdAsync(int id)
        {
            var user = await _service.GetByIdAsync(id);
            if (user == null) return NotFound();
            return Ok(user);
        }
        [HttpPost]
        public virtual async Task<ActionResult<TDto>> CreateAsync(TCreateDto entity)
        {
            var validationResult = await _createValidator.ValidateAsync(entity);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            var item = await _service.CreateAsync(entity);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = GetItemId(item) }, item);
        }
        [HttpDelete("{id}")]
        public virtual async Task<ActionResult<bool>> DeleteAsync(int id)
        {
            var result = await _service.DeleteAsync(id);
            if (!result) return NotFound();
            return Ok(result);
        }

        [HttpPut("{id}")]
        public virtual async Task<ActionResult<bool>> UpdateAsync(int id, TUpdateDto entity)
        {
            var validationResult = await _updateValidator.ValidateAsync(entity);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            var result = await _service.UpdateAsync(id, entity);
            if (!result) return NotFound();
            return Ok(result);
        }

        protected abstract object GetItemId(TDto item);
    }
}