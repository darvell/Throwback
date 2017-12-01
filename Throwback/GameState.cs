using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Throwback
{
    public class GameState
    {
        public static GameState Instance;
        public Random Random { get; private set; } = new Random();

        private int totalSeconds = 0;

        private const float SPEED_MULTIPLIER = 1.0f;

        public Drive Drive { get; private set; }
        public float Progress => (float)Drive.Blocks.Count(x => x.Complete) / (float)Drive.Blocks.Count;

        public Company Company { get; private set; } = new Company();
        public Player Player { get; private set; } = new Player();

        public List<StoreItem> StoreItems { get; private set; } = new List<StoreItem>();

        public void Init()
        {
            Drive = new Drive(770);
        }

        public void Update(GameTime time)
        {
            // Update company losses
            Company.Update(time);
            Player.Update(time);

            // Determine how many seconds have passed. Update state per second.
            int secondsPassed = 0;
            int flooredSeconds = (int)Math.Floor(time.TotalGameTime.TotalSeconds);
            if (flooredSeconds > totalSeconds)
            {
                secondsPassed = flooredSeconds - totalSeconds;
            }

            for (int i = 0; i < secondsPassed * SPEED_MULTIPLIER; i++)
            {
                Drive.Blocks.FirstOrDefault(x => !x.Complete)?.Update();
            }

            totalSeconds = flooredSeconds;
        }
    }
}