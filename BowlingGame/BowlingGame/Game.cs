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
            var frameIndex = 0;
            for (int frame = 0; frame < 10; frame++)
            {
                var frameResult = this.Rolls[frameIndex] + this.Rolls[frameIndex + 1];
                if (this.Rolls[frameIndex] == 10) // Strike
                {
                    result += 10 + this.Rolls[frameIndex + 1] + this.Rolls[frameIndex + 2];
                    frameIndex++;
                }
                else if (isSpare(frameResult))
                {
                    result += frameResult + this.Rolls[frameIndex + 2];
                    frameIndex += 2;
                }
                else
                {
                    result += frameResult;
                    frameIndex += 2;
                }

            }

            return result;
        }

        private bool isSpare(int frameResult)
        {
            return frameResult == 10;
        }
    }
}
