using Microsoft.Xna.Framework;
using SadConsole;
using SadConsole.Controls;
using System;
using System.Globalization;
using System.Linq;
using System.Windows;

namespace Throwback
{
    public class ScanConsole : ControlsConsole
    {
        private ProgressBar _progressBar;
        private const string SCANNER_TITLE = " MichaelSoft Surface Scan ";

        public ScanConsole(int width, int height) : base(width, height)
        {
            // Draw background.
            for (int i = 0; i < width; ++i)
            {
                for (int j = 1; j < height; j++)
                {
                    this.SetBackground(i, j, (j > 1 && j < 20) ? ColorAnsi.White : ColorAnsi.Blue);
                }
            }

            #region Gross Border Drawing

            // Draw Top Border
            for (int i = 1; i < width - 1; i++)
            {
                SetGlyph(i, 2, 196, ColorAnsi.WhiteBright);
            }

            // Draw Top Border Title
            Print((Width - SCANNER_TITLE.Length) / 2, 2, SCANNER_TITLE);

            // Draw Top Border Corners
            SetGlyph(0, 2, 218, ColorAnsi.WhiteBright);
            SetGlyph(Width - 1, 2, 191, ColorAnsi.WhiteBright);

            // Draw Border Edges
            for (int i = 3; i < 19; i++)
            {
                SetGlyph(0, i, 179, ColorAnsi.WhiteBright);
                SetGlyph(Width - 1, i, 179, ColorAnsi.WhiteBright);
            }

            // Draw Bottom Border
            for (int i = 1; i < width - 1; i++)
            {
                SetGlyph(i, 19, 196, ColorAnsi.WhiteBright);
            }

            SetGlyph(0, 19, 192, ColorAnsi.WhiteBright);
            SetGlyph(Width - 1, 19, 217, ColorAnsi.WhiteBright);

            // Draw Button Separator

            for (int i = 1; i < width - 1; i++)
            {
                SetGlyph(i, 17, 196, ColorAnsi.WhiteBright);
            }
            SetGlyph(0, 17, 195, ColorAnsi.WhiteBright);
            SetGlyph(Width - 1, 17, 180, ColorAnsi.WhiteBright);

            #endregion Gross Border Drawing

            // Draw bottom separator
            for (int i = 1; i < width - 1; i++)
            {
                SetGlyph(i, Height - 4, 196, ColorAnsi.White);
            }

            // Add Shop Button

            var shopButton = new SadConsole.Controls.Button(11)
            {
                Text = "Store",
                Position = new Point(10, Height - 7),
            };
            shopButton.Click += (s, e) =>
            {
                // This is so not right to do, I hate gamedev
                Program.SwitchScreen();
            };
            Add(shopButton);

            var infoButton = new Button(10)
            {
                Text = "AAAAH!",
                Position = new Point(23, Height - 7)
            };

            infoButton.Click += (s, e) =>
            {
                Window.Message(
                    "It's 1993 and the server hard drive has died!", "go on...", () =>
                    {
                        Window.Message("Using your wits, maybe you can save it before the company dies.", "go on...", () =>
                        {
                            Window.Message("Use the companies resources as well as your own to try and speed things up.", "go on...", () =>
                            {
                                Window.Message("But do it cheaply, or you might find yourself poor or even bankrupt.", "oh god.");
                            });
                        });
                    });
            };
            Add(infoButton);
            // Add progress bar at bottom.
            var progressBar =
                new ProgressBar(Width - 4 - 15, 1, HorizontalAlignment.Left) { Position = new Point(2 + 15, Height - 3) };
            progressBar.Theme = YellowProgressBarTheme.ThemeInstance;
            progressBar.Progress = 0.5f;
            Add(progressBar);
            _progressBar = progressBar;
        }

        public override void Update(TimeSpan time)
        {
            Print(1, 0, $"Company: {GameState.Instance.Company.Money.ToString("C", CultureInfo.CurrentCulture)} You: {GameState.Instance.Player.Money.ToString("C", CultureInfo.CurrentCulture)}");
            _progressBar.Progress = GameState.Instance.Progress;
            Print(2, this.Height - 3, $"{(int)Math.Floor(GameState.Instance.Progress * 100f)}% complete".PadLeft(13), ColorAnsi.CyanBright);

            // Messy but welcome to gamejam.
            // Draw block state to screen.
            int lineOffset = 3;
            int xOffset = 2;
            foreach (var (value, index) in GameState.Instance.Drive.Blocks.Select((value, index) => (value, index)))
            {
                int y = (int)Math.Floor(index / 55.0);
                int x = index % 55;

                int glyph = 177;

                if (value.HasData)
                {
                    glyph = 8;
                }
                if (value.Corrupted)
                {
                    glyph = 'D';
                }

                if (value.Complete)
                {
                    SetGlyph(x + xOffset, y + lineOffset, glyph, value.Corrupted ? ColorAnsi.RedBright : ColorAnsi.YellowBright, value.Corrupted ? ColorAnsi.Red : ColorAnsi.Black);
                }
                else if (value.Progress > 0.0f)
                {
                    SetGlyph(x + xOffset, y + lineOffset, glyph, value.Corrupted ? ColorAnsi.Red : ColorAnsi.GreenBright, value.Corrupted ? ColorAnsi.RedBright : ColorAnsi.Black);
                }
                else
                {
                    SetGlyph(x + xOffset, y + lineOffset, glyph, value.Corrupted ? ColorAnsi.RedBright : ColorAnsi.CyanBright, ColorAnsi.Black);
                }
            }

            base.Update(time);
        }
    }
}