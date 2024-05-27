using BenMakesGames.MonoGame.Palettes;
using BenMakesGames.PlayPlayMini;
using BenMakesGames.PlayPlayMini.Services;
using IsoDemo.Model;
using Microsoft.Xna.Framework;

namespace IsoDemo.GameStates;

// sealed classes execute faster than non-sealed, so always seal your game states!
public sealed class Playing: GameState
{
    private GraphicsManager Graphics { get; }
    private GameStateManager GSM { get; }
    private MouseManager Mouse { get; }
    private FieldRenderer FieldRenderer { get; }

    public Playing(GraphicsManager graphics, GameStateManager gsm, MouseManager mouse, FieldRenderer fieldRenderer)
    {
        Graphics = graphics;
        GSM = gsm;
        Mouse = mouse;
        FieldRenderer = fieldRenderer;

        FieldRenderer.SetField(Field.Generate());
    }

    public override void Input(GameTime gameTime)
    {
        // TODO: get input from keyboard, mouse, or gamepad (refer to PlayPlayMini documentation for more info)
    }

    public override void Update(GameTime gameTime)
    {
        // TODO: update game objects based on user input, AI logic, etc
    }

    public override void Draw(GameTime gameTime)
    {
        Graphics.Clear(DawnBringers16.LightBlue);

        FieldRenderer.Render(200, 50);

        // only draw the mouse cursor once
        if(GSM.CurrentState == this)
            Mouse.Draw(gameTime);
    }
}
