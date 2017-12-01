using System;
using SadConsole;
using Console = SadConsole.Console;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Throwback
{
    public class Program
    {
        public const int Width = 80;
        public const int Height = 25;

        private static ScanConsole mainConsole;
        private static ShopConsole shopConsole;

        private static void Main(string[] args)
        {
            SadConsole.Settings.ResizeMode = Settings.WindowResizeOptions.Scale;
            SadConsole.Global.RenderScale = new Vector2(2);
            SadConsole.Game.Create("IBM.font", Width, Height);

            SadConsole.Game.OnInitialize = Init;

            // Hook the update event that happens each frame so we can trap keys and respond.
            SadConsole.Game.OnUpdate = Update;

            // Start the game.
            SadConsole.Game.Instance.Run();

            //
            // Code here will not run until the game window closes.
            //

            SadConsole.Game.Instance.Dispose();
        }

        private static void Update(GameTime time)
        {
            GameState.Instance.Update(time);

            // As an example, we'll use the F5 key to make the game full screen
            if (SadConsole.Global.KeyboardState.IsKeyReleased(Microsoft.Xna.Framework.Input.Keys.F5))
            {
                SadConsole.Settings.ToggleFullScreen();
            }

            // Draw to screen with CRT
        }

        private static void Init()
        {
            // TODO: Save/Load
            GameState.Instance = new GameState();
            GameState.Instance.Init();

            mainConsole = new ScanConsole(Width, Height);
            shopConsole = new ShopConsole(Width, Height);

            SadConsole.Global.CurrentScreen = mainConsole;
        }

        // TODO: Shove in enum
        public static void SwitchScreen()
        {
            if (SadConsole.Global.CurrentScreen == mainConsole)
            {
                SadConsole.Global.CurrentScreen = shopConsole;
            }
            else
            {
                SadConsole.Global.CurrentScreen = mainConsole;
            }
        }
    }
}