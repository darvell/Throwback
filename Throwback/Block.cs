using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Throwback
{
    public class Block
    {
        private float _progress = 0.0f;
        private Chance _corruption = new Chance(0.05f);

        public bool Corrupted { get; private set; }

        public float Progress
        {
            get { return _progress; }
        }

        public bool Complete
        {
            get { return _progress > 1.0f; }
        }

        public bool HasData { get; private set; }

        private Chance _corruptionChance = new Chance(0.1f);

        public Block()
        {
            Chance chance = new Chance(75.0f);
            HasData = chance.Roll();
            Corrupted = new Chance(1f).Roll();
        }

        public void Update()
        {
            if (Corrupted)
            {
                _progress += 0.05f;
            }
            else
            {
                Corrupted = _corruptionChance.Roll();
                _progress += 0.15f;
            }
        }
    }
}