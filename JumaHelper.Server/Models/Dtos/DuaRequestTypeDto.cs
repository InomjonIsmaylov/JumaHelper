namespace JumaHelper.Server.Models.Dtos;

public class DuaRequestTypeDto
{
    public int Id { get; set; }

    [MaxLength(800)]
    public required string Name { get; set; }

    public List<DuaRequestDto> DuaRequests { get; set; } = [];
}