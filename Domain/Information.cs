namespace Domain;

public class Information
{
    public int InformationId { get; set; }
    public string? Text { get; set; }
    public int CategoryId { get; set; }
    public Category? Category { get; set; }
}