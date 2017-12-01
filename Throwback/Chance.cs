using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Throwback
{
    public class Chance
    {
        public float Percent { get; set; } = 0.0f;
        private Random _rnd;

        private Random Random
        {
            get => _rnd ?? GameState.Instance?.Random;
            set => _rnd = value;
        }

        public Chance(float percent, Random randomNumberGen = null)
        {
            if (randomNumberGen != null)
            {
                Random = randomNumberGen;
            }
            Percent = percent;
        }

        public bool Roll()
        {
            return Percent >= Random?.NextDouble() * 100.0f;
        }
    }
}