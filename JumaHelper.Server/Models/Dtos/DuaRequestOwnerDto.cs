namespace JumaHelper.Server.Models.Dtos;

public class DuaRequestOwnerDto
{
    public int Id { get; set; }

    [MaxLength(100)]
    public required string Name { get; set; }

    [MaxLength(100)]
    public string? FatherName { get; set; }

    public List<DuaRequestDto> DuaRequests { get; set; } = [];
}