using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Throwback
{
    public class Player
    {
        public double Money = 25000.00;

        public double Salary { get; private set; } = 125000.00;

        public void Update(GameTime time)
        {
            Money += Salary / 365.0 / 24.0 / 24.0 / 60.0 * time.ElapsedGameTime.TotalSeconds;
        }
    }
}