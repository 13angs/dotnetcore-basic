namespace MsRabbitMQ.Common.Models
{
    public class CommentBase
    {
        public virtual int Id { get; set; }   
        public virtual string? CommentId { get; set; }
        public virtual string? Text { get; set; }
        public virtual string? ProductId { get; set; }
    }
}