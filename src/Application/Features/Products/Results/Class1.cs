

namespace Application.Features.Products.Results;

public class ProductResult
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public double RegularPrice { get; set; }
    public double SalePrice { get; set; }
}
