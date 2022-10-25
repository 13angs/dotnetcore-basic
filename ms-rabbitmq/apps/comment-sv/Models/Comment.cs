using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MsRabbitMQ.Common.Models;

namespace comment_sv.Models
{
    public class Comment : CommentBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override string? CommentId { get; set; }
    }
}