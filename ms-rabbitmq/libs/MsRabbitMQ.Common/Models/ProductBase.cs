namespace MsRabbitMQ.Common.Models
{
    public class ProductBase
    {
        public virtual int Id { get; set; }
        public virtual string? ProductId { get; set; }
        public virtual string? Name { get; set; }
    }
}