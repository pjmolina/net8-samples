namespace Api2.Dto;

public class PizzaDto: PizzaUpdateDto
{
    public int Id { get; set; }

}

public class PizzaUpdateDto
{   
    public string Name { get; set; } = "";
    public string? Description { get; set; }
    public decimal Price { get; set; }

}

