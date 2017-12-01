using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Throwback
{
    public class Company
    {
        public double Money { get; private set; } = 10000000.00;

        public double LossRate = 1.0;
        public double Loss = 10000.0;

        public void Update(GameTime time)
        {
            Money -= Loss * time.ElapsedGameTime.TotalSeconds * LossRate;
        }

        public void Spend(float amount)
        {
            Money -= amount;
        }
    }
}