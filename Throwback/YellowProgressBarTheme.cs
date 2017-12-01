using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using SadConsole;
using SadConsole.Themes;

namespace Throwback
{
    public class YellowProgressBarTheme
    {
        public static ProgressBarTheme ThemeInstance;

        static YellowProgressBarTheme()
        {
            ThemeInstance = new ProgressBarTheme
            {
                Background = new ThemePartBase
                {
                    Normal = new Cell(Color.LightYellow, Color.Transparent, 176),
                    Focused = new Cell(Color.LightYellow, Color.Transparent, 176),
                    Disabled = new Cell(Color.LightYellow, Color.Transparent, 176),
                    MouseOver = new Cell(Color.LightYellow, Color.Transparent, 176)
                },
                Foreground = new ThemePartBase
                {
                    Normal = new Cell(Color.Yellow, Color.Transparent, 219),
                    Focused = new Cell(Color.Yellow, Color.Transparent, 219),
                    Disabled = new Cell(Color.Gray, Color.Transparent, 219),
                    MouseOver = new Cell(Color.Yellow, Color.Transparent, 219)
                }
            };
        }
    }
}