using IsoDemo.Model.FieldTemplates;

namespace IsoDemo.Model;

public sealed class Field
{
    public List<Fighter> Fighters { get; set; } = new();
    public SortedDictionary<Coordinate, Fighter> FighterLocations { get; private set; }

    public SortedDictionary<Coordinate, Tile> Tiles { get; set; } = new();

    public Field()
    {
        FighterLocations = [];
    }

    public static Field Generate()
    {
        var field = new Field();

        field.AddFighter(new Fighter() { Location = new(5, 4) });

        // for demonstration purposes, just pull the "Hill", which we know
        // is 10x10. for a real game, you might fractal-generate terrain, or
        // randomly assemble pieces, or load from a file, or who knows what.
        for(int y = 0; y < 10; y++)
        {
            for(int x = 0; x < 10; x++)
            {
                var surface = TileSurface.Grass;
                var height = Hill.Field[y][x]; // annoying/confusing, x & y are swapped

                var tile = new Tile
                {
                    Surface = surface,
                    SurfaceSpriteIndex = Random.Shared.Next(2),
                    Height = height,
                    LeftSpriteIndex = GenerateLeftSpriteIndex(surface, height),
                    RightSpriteIndex = GenerateRightSpriteIndex(surface, height),
                };

                field.Tiles.Add(new Coordinate(x, y), tile);
            }
        }

        return field;
    }

    public void AddFighter(Fighter fighter)
    {
        Fighters.Add(fighter);
        FighterLocations.Add(fighter.Location, fighter);
    }

    public void AddFighters(IEnumerable<Fighter> fighters)
    {
        foreach (var fighter in fighters)
            Fighters.Add(fighter);

        RecomputeFighterLocations();
    }

    public void RecomputeFighterLocations()
    {
        FighterLocations = ComputeFighterLocations();
    }

    private SortedDictionary<Coordinate, Fighter> ComputeFighterLocations()
    {
        return new(Fighters.ToDictionary(f => f.Location, f => f));
    }

    public static int GenerateLeftSpriteIndex(TileSurface surface, int height)
    {
        bool useVariation = Random.Shared.Next(4) == 0;
        return height * 2 + (useVariation ? 8 : 0);
    }

    public static int GenerateRightSpriteIndex(TileSurface surface, int height)
    {
        bool useVariation = Random.Shared.Next(4) == 0;
        return height * 2 + (useVariation ? 9 : 1);
    }
}

public sealed record Coordinate(int X, int Y) : IComparable<Coordinate>
{
    public int CompareTo(Coordinate? other)
    {
        if (ReferenceEquals(this, other)) return 0;
        if (ReferenceEquals(null, other)) return 1;
        var xComparison = X.CompareTo(other.X);
        if (xComparison != 0) return xComparison;
        return Y.CompareTo(other.Y);
    }
}

public sealed class Tile
{
    public const int TileWidth = 36;
    public const int TileHeight = 18; // note: sprite is 19 pixels high; there's one pixel of overlap between tiles

    public required TileSurface Surface { get; set; }
    public required int SurfaceSpriteIndex { get; set; }
    public required int Height { get; set; }
    public required int LeftSpriteIndex { get; set; }
    public required int RightSpriteIndex { get; set; }
}

public enum TileSurface
{
    Grass,
}
