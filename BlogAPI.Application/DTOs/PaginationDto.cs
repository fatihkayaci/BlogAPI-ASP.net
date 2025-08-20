namespace BlogAPI.Application.DTOs
{
    public class PaginationDto
    {
        public required int PageNumber { get; set; } = 1;
        public required int PageSize { get; set; } = 10;
    }
}