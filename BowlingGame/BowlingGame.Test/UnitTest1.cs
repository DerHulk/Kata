using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingGame.Test
{
    [TestClass]
    public class BowlingGameTest
    {
        public Game g { get; set; }

        [TestInitialize]
        public void SetupEvery()
        {
            g = new Game();
        }

        [TestMethod]
        public void TestMethod1()
        {
                for (int i=0; i<20; i++)
                    g.roll(0);

                Assert.AreEqual(0, g.score());
        }

        [TestMethod]
        public void testAllOnes()
        {
            // Act
            for (int i = 0; i < 20; i++)
            {
                g.roll(1);
            }
            // Assert
            Assert.AreEqual(20, g.score());
           
        }
    }
}
