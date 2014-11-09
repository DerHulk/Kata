using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingGame.Test
{
    [TestClass]
    public class BowlingGameTest
    {
        [TestMethod]
        public void TestMethod1()
        {
              Game g = new Game();
                for (int i=0; i<20; i++)
                    g.roll(0);

                Assert.AreEqual(0, g.score());

        }
    }
}
