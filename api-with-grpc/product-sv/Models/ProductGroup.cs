namespace product_sv.Models
{
    public class ProductGroup
    {
        public ProductGroup()
        {
            Products = new List<Product>();   
        }
        public int GroupId { get; set; }
        public string? GroupName { get; set; }
        public List<Product> Products { get; set; }
    }
}