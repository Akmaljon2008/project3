namespace Domain.Models;

public class Tranzaction
{
    public int Id { get; set; }
    public int SenderId { get; set; }
    public int TakerId { get; set; }
    public decimal Sum { get; set; }
}