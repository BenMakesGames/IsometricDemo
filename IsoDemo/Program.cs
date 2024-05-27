using BenMakesGames.PlayPlayMini;
using BenMakesGames.PlayPlayMini.Model;
using IsoDemo.GameStates;

// TODO: any pre-req setup, ex:
/*
 * var appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
 * var appDataGameDirectory = @$"{appData}{Path.DirectorySeparatorChar}IsoDemo";
 *
 * Directory.CreateDirectory(appDataGameDirectory);
 */

var gsmBuilder = new GameStateManagerBuilder();

gsmBuilder
    .SetWindowSize(1920 / 4, 1080 / 4, 2)
    .SetInitialGameState<Startup>()
    .SetLostFocusGameState<LostFocus>()

    // TODO: set a better window title
    .SetWindowTitle("IsoDemo")

    // TODO: add any resources needed (refer to PlayPlayMini documentation for more info)
    .AddAssets(new IAsset[]
    {
        new FontMeta("Font", "Graphics/Font", 6, 8) { HorizontalSpacing = 0 },
        new PictureMeta("Cursor", "Graphics/Cursor", true),

        new SpriteSheetMeta("TileTops", "Graphics/TileTops", 36, 19),
        new SpriteSheetMeta("TileSides", "Graphics/TileSides", 18, 30),
        new PictureMeta("Grid", "Graphics/Grid"),
        new SpriteSheetMeta("Warrior", "Graphics/Warrior", 36, 60),
    })

    // TODO: any additional service registration (refer to PlayPlayMini and/or Autofac documentation for more info)
    .AddServices((s, c) => {

    })
;

gsmBuilder.Run();
