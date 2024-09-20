using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObjects
{
    [Table("Users")]
    public class UserLoginObj
    {
        [Key]
        [Column("Id", TypeName = "int")]
        public int Id { get; set; }
        [Column("UserName", TypeName = "nvarchar(250)")]
        public string? UserName { get; set; }
        [Column("Password", TypeName = "nvarchar(250)")]
        public string? Password { get; set; }
    }
}
