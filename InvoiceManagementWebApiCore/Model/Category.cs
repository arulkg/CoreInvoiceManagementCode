namespace InvoiceManagementWebApiCore.Model
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
