using JumaHelper.Server.Models.DbSets;

namespace JumaHelper.Server.Models.Dtos;

public class DuaRequestDto
{
    public int Id { get; set; }

    public DuaRequestTypeDto? RequestType { get; set; }

    public DuaRequestOwnerDto? Owner { get; set; }

    public DuaRequestTo RequestTo { get; set; } = new();

    [MaxLength(3000)]
    public string? Description { get; set; }
}