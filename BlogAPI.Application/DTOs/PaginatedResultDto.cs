namespace BlogAPI.Application.DTOs
{
    public class PaginatedResultDto<T>  // ← Generic yap
    {
        public required IEnumerable<T> Data { get; set; }  // ← IEnumerable<T>
        public required int TotalCount { get; set; }
        public required int TotalPages { get; set; }
        public required int CurrentPage { get; set; }
        public required bool HasNext { get; set; }
        public required bool HasPrevious { get; set; }
    }
}