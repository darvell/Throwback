using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using SadConsole;

namespace Throwback
{
    public class ShopConsole : ControlsConsole
    {
        public ShopConsole(int width, int height) : base(width, height)
        {
            var listbox = new SadConsole.Controls.ListBox(40, Height - 2);
            listbox.Position = new Point(1, 1);
            listbox.Items.Add("item 1");
            listbox.Items.Add("item 2");
            listbox.Items.Add("item 3");
            listbox.Items.Add("item 4");
            listbox.Items.Add("item 5");
            listbox.Items.Add("item 6");
            listbox.Items.Add("item 7");
            listbox.Items.Add("item 8");
            Add(listbox);
        }
    }
}