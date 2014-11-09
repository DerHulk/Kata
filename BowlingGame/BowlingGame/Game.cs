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
               
                if (this.isStrike(frameIndex)) 
                {
                    result += 10 + this.strikeBonus(frameIndex);
                    frameIndex++;
                }
                else if (isSpare(frameIndex))
                {
                    result += 10 + this.spareBonus(frameIndex);
                    frameIndex += 2;
                }
                else
                {
                    result +=  sumOfBallsInFrame(frameIndex);;
                    frameIndex += 2;
                }

            }

            return result;
        }

        private int sumOfBallsInFrame(int frameIndex)
        {
            return this.Rolls[frameIndex] + this.Rolls[frameIndex + 1];
        }

        private int spareBonus(int frameIndex)
        {
            return  this.Rolls[frameIndex + 2];
        }

        private int strikeBonus(int frameIndex)
        {
            return this.Rolls[frameIndex + 1] + this.Rolls[frameIndex + 2];
        }

        private bool isStrike(int frameIndex)
        {
            return this.Rolls[frameIndex] == 10;
        }

        private bool isSpare(int frameIndex)
        {
            return this.Rolls[frameIndex] + this.Rolls[frameIndex +1] == 10;
        }
    }
}
