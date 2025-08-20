namespace BlogAPI.Application.DTOs
{
    public class CreateCommentDto
    {
        public required string Content { get; set; }
        public required int PostId { get; set; }
        public required int UserId { get; set; }
        
    }
}