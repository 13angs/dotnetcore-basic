
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ef_core.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; set; }
        public virtual string Name { get; set; } = string.Empty;
        // public virtual int UserId {get; set;}
    }

    public class UserModel
    {
        public virtual string Name { get; set; } = string.Empty;   
    }
}