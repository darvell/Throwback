using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Throwback
{
    public class Drive
    {
        public List<Block> Blocks { get; private set; } = new List<Block>();

        public Drive(int blocks)
        {
            for (int i = 0; i < blocks; i++)
            {
                Blocks.Add(new Block());
            }
        }
    }
}