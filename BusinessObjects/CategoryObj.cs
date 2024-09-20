using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObjects
{
    [Table("Categories")]
    public class CategoryObj
    {
        [Key]
        [Column("Id", TypeName = "int")]
        public int Id { get; set; }
        [Column("Name", TypeName ="varchar(250)")]
        public string? Name { get; set; }
        [Column("Description", TypeName = "nvarchar(250)")]
        public string? Description { get; set; }
        [Column("MinimumStock", TypeName = "decimal(18,2)")]
        public decimal MinimumStock { get; set; }
        [Column("MaximumStock", TypeName = "decimal(18,2)")]
        public decimal MaximumStock { get; set; }
        [Column("MinimumRate", TypeName = "decimal(18,2)")]
        public decimal MinimumRate { get; set; }
        [Column("MaximumRate", TypeName = "decimal(18,2)")]
        public decimal MaximumRate { get; set; }
    }
}
