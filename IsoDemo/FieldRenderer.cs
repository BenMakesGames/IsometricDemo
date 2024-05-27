using BenMakesGames.MonoGame.Palettes;
using BenMakesGames.PlayPlayMini.Attributes.DI;
using BenMakesGames.PlayPlayMini.Services;
using IsoDemo.Model;
using Microsoft.Xna.Framework;

namespace IsoDemo;

[AutoRegister]
public sealed class FieldRenderer
{
    private GraphicsManager Graphics { get; }

    private Field? Field { get; set; }

    public FieldRenderer(GraphicsManager graphics)
    {
        Graphics = graphics;
    }

    public void SetField(Field? field) => Field = field;

    public void Render(int xOffset, int yOffset)
    {
        if (Field is null) return;

        foreach (var (c, tile) in Field.Tiles)
        {
            var pixelX = c.X * 18 - c.Y * 18 + xOffset;
            var pixelY = c.Y * 9 + c.X * 9 - tile.Height * 5 + yOffset;

            Graphics.DrawSprite("TileTops", pixelX, pixelY, tile.SurfaceSpriteIndex);

            Graphics.DrawSprite("TileSides", pixelX, pixelY + 10, tile.LeftSpriteIndex);
            Graphics.DrawSprite("TileSides", pixelX + 18, pixelY + 10, tile.RightSpriteIndex);

            Graphics.DrawPicture("Grid", pixelX, pixelY, DawnBringers16.DarkGray);

            if (Field.FighterLocations.TryGetValue(c, out var fighter))
                Graphics.DrawSprite("Warrior", pixelX, pixelY - 60 + 19, 0, Color.White);
        }
    }
}
