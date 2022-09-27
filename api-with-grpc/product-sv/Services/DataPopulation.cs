using product_sv.Models;
using System.Text.Json;

namespace product_sv.Services
{
    public static class DataPopulation
    {
        public static void PopulateProduct(IApplicationBuilder app)
        {
            using(var scope = app.ApplicationServices.CreateScope())
            {
                ProductContext context = scope.ServiceProvider.GetRequiredService<ProductContext>();

                if(!context.Products.Any())
                {
                    Console.WriteLine("Seeding new Products...");
                    int[] nums = {1, 2, 3, 4};
                    IList<Product> products = new List<Product>();
                    foreach(int num in nums)
                    {
                        Product product = new Product{ProductId=num, ProductName=$"Product {num}"};
                        if(num % 2 == 0)
                        {
                            product.GroupId = 2;
                        }else{
                            product.GroupId = 1;
                        }
                        products.Add(product);
                    }
                    context.Products.AddRange(products);
                    int result = context.SaveChanges();
                    if(result > 0)
                    {
                        Console.WriteLine($"Finish seeding Products!");
                        Console.WriteLine(JsonSerializer.Serialize<IEnumerable<Product>>(context.Products));
                    }else{
                        Console.WriteLine($"Error seeding Products!");
                    }

                }
            }
        }
    }
}