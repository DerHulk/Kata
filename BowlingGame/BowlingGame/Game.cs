using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGame
{
    public class Game
    {
        public Game(){
            this.Score = 0;
        }
        private int Score { get; set; }
        public void roll(int p)
        {
            this.Score += p;
        }

        public int score()
        {
            return this.Score;
        }
    }
}
