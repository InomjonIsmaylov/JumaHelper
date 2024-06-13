namespace JumaHelper.Server.Models.DbSets;

[Owned]
public class DuaRequestTo
{
    [MaxLength(250)]
    public string? Name { get; set; }

    public Affiliation Affiliation { get; set; } = Affiliation.Other;
}

public enum Affiliation
{
    Father = 10,
    Mother = 20,
    Parents = 30,
    Children = 40,
    Brother = 50,
    Sister = 60,
    Siblings = 70,
    Relative = 80,
    Friend = 90,
    Teacher = 100,
    Other = 500
}