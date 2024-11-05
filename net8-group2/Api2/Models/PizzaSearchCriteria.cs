namespace Api2.Models;

public class PizzaSearchCriteria
{
    public string? Query { get; set; }
    public decimal? MinPrice { get; set; }
    public decimal? MaxPrice { get; set; }
}
