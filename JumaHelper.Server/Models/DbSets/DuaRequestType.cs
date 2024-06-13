using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JumaHelper.Server.Models.DbSets;

public class DuaRequestType : EntityBase
{
    [MaxLength(800)]
    public required string Name { get; set; }

    public List<DuaRequest> DuaRequests { get; set; } = [];
}

public class DuaRequestTypeConfiguration : IEntityTypeConfiguration<DuaRequestType>
{
    public void Configure(EntityTypeBuilder<DuaRequestType> builder)
    {
        builder.HasIndex(x => x.Name);

        builder.HasData(
            new DuaRequestType
            {
                Id = 1,
                Name = "Kesellikke shıpa",
                CreatedAt = DateTime.Now
            },
            new DuaRequestType
            {
                Id = 2,
                Name = "Ata-anası haqqına jaqsılıq",
                CreatedAt = DateTime.Now
            },
            new DuaRequestType
            {
                Id = 3,
                Name = "Jumisının' júrisiwin",
                CreatedAt = DateTime.Now
            },
            new DuaRequestType
            {
                Id = 4,
                Name = "Qarızınan qutılıw",
                CreatedAt = DateTime.Now
            },
            new DuaRequestType
            {
                Id = 5,
                Name = "Perzent sorap",
                CreatedAt = DateTime.Now
            },
            new DuaRequestType
            {
                Id = 6,
                Name = "Basqa sebeb benen",
                CreatedAt = DateTime.Now
            }
        );
    }
}