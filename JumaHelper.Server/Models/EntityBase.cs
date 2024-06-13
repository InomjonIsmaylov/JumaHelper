namespace JumaHelper.Server.Models;

public abstract class EntityBase
{
    [Key]
    public int Id { get; set; }
    
    public DateTime CreatedAt { get; set; }

    public DateTime? ModifiedAt { get; set; }
}