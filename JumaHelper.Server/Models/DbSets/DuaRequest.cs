using System.ComponentModel.DataAnnotations.Schema;

namespace JumaHelper.Server.Models.DbSets;

public class DuaRequest : EntityBase
{
    public DuaRequestType? RequestType { get; set; }

    public DuaRequestOwner? Owner { get; set; }

    public DuaRequestTo RequestTo { get; set; } = new();

    [MaxLength(3000)]
    public string? Description { get; set; }



    [ForeignKey(nameof(Owner))]
    public int? DuaRequestOwnerId { get; set; }

    [ForeignKey(nameof(RequestType))]
    public int DuaRequestTypeId { get; set; }
}