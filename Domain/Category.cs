namespace Domain;

public class Category
{
    public Category()
    {
        Information = new List<Information>();
    }
    public int CategoryId { get; set; }
    public string? Name { get; set; }
    public ICollection<Information> Information { get; set; }
}