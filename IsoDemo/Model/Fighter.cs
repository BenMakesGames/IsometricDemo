namespace IsoDemo.Model;

public sealed class Fighter
{
    public required Coordinate Location { get; set; }

    public string SpriteSheet => "Warrior";
    public int SpriteIndex => 0;
}
