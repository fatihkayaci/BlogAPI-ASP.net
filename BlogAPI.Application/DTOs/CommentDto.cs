namespace BlogAPI.Application.DTOs
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string? Content { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }
        public string? Username { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}