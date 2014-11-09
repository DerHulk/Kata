using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGame
{
    public class Game
    {
        private int Score { get; set; }
        private int[] Rolls { get; set; }
        private int CurrentRoll { get; set; }

        public Game(){
            this.Score = 0;
            this.CurrentRoll = 0;
            this.Rolls = new int[21];
        }

        public void roll(int p)
        {
            this.Rolls[this.CurrentRoll] += p;
            this.CurrentRoll++;
        }

        public int score()
        {
            var result = 0;
            var i = 0;
            for (int frame = 0; frame < 10; frame++)
            {
                var frameResult = this.Rolls[i] + this.Rolls[i + 1];

                if (frameResult == 10) //spare
                {
                    result += frameResult + this.Rolls[i + 2];
                }
                else
                    result += frameResult;

                i += 2;
            }

            return result;
        }
    }
}
