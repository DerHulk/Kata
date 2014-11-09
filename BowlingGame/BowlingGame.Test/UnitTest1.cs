using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingGame.Test
{
    [TestClass]
    /// <summary>
    /// Sample Game for Bowling Kata
    /// https://www.google.de/url?sa=t&rct=j&q=&esrc=s&source=web&cd=1&cad=rja&uact=8&ved=0CCQQFjAA&url=http%3A%2F%2Fbutunclebob.com%2Ffiles%2Fdownloads%2FBowling%2520Game%2520Kata.ppt&ei=VIhfVOj3EtLQ7AaWx4HYBQ&usg=AFQjCNFHxYawc054GuRAyXzmcYUfaJ1Z6g&bvm=bv.79189006,d.d2s
    /// </summary>
    public class BowlingGameTest
    {
        public Game g { get; set; }

        [TestInitialize]
        public void SetupEvery()
        {
            g = new Game();
        }

        private void rollMany(int n, int pins){
            for(int i= 0; i < n; i++)
                g.roll(pins);
        }

        [TestMethod]
        public void testGutterGame()
        {
            // Act
            this.rollMany(20, 0);

            // Assert
            Assert.AreEqual(0, g.score());
        }

        [TestMethod]
        public void testAllOnes()
        {
            // Act
            this.rollMany(20, 1);

            // Assert
            Assert.AreEqual(20, g.score());  
        }

        [TestMethod]
        public void testOneSpare()
        {
            // Act
            rollSpare();
            g.roll(3);
            this.rollMany(17, 0);

            // Assert
            Assert.AreEqual(16, g.score(), "Invalid score for spare");
        }

        [TestMethod]
        public void testOneStrike()
        {
            // Act
            rollStrike(); // Strike
            g.roll(3);
            g.roll(4);
            rollMany(16, 0);

            // Assert
            Assert.AreEqual(24, g.score());
        }

        [TestMethod]
        public void testPerfection()
        {
            // Act
            rollMany(12, 10);

            // Assert
            Assert.AreEqual(300, g.score());
        }

        private void rollStrike()
        {
            g.roll(10);
        }

        private void rollSpare()
        {
            g.roll(5);
            g.roll(5); // Spare
        }
    }
}
