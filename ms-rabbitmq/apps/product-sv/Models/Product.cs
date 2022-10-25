using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MsRabbitMQ.Common.Models;

namespace product_sv.Models
{
    public class Product : ProductBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override string? ProductId { get; set; }
    }
}