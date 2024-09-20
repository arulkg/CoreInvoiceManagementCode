using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Category
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public float MinimumStock { get; set; }
        public float MaximumStock { get; set; }
        public float MinimumRate { get; set; }
        public float MaximumRate { get; set; }
    }
}
