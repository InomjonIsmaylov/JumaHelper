namespace JumaHelper.Server.Models.DbSets;

public class DuaRequestOwner : EntityBase
{
    [MaxLength(100)]
    public required string Name { get; set; }

    [MaxLength(100)]
    public string? FatherName { get; set; }

    public List<DuaRequest> DuaRequests { get; set; } = [];
}