using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UmzugsApp.Tests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        [Description("Prüft das die Zeit 16:30 nicht überschritten werden darf.")]
        public void IsValidTime01()
        {
            //arrange
            var toLate = DateTime.ParseExact("16:31", "HH:mm", CultureInfo.InvariantCulture);

            //act
            var result = Program.IsValidTime(toLate);

            //assert
            Assert.IsFalse(result);

        }

        [TestMethod]
        [Description("Prüft das die Zeit 16:29 nicht unterschritten werden darf.")]
        public void IsValidTime02()
        {
            //arrange
            var toLate = DateTime.ParseExact("08:59", "HH:mm", CultureInfo.InvariantCulture);

            //act
            var result = Program.IsValidTime(toLate);

            //assert
            Assert.IsFalse(result);

        }

        [TestMethod]
        [Description("Prüft ab 9:00 eine gültige zeit ist.")]
        public void IsValidTime03()
        {
            //arrange
            var toLate = DateTime.ParseExact("09:00", "HH:mm", CultureInfo.InvariantCulture);

            //act
            var result = Program.IsValidTime(toLate);

            //assert
            Assert.IsTrue(result);

        }

        [TestMethod]
        [Description("Prüft bis 16:30 eine gültige zeit ist.")]
        public void IsValidTime04()
        {
            //arrange
            var toLate = DateTime.ParseExact("16:30", "HH:mm", CultureInfo.InvariantCulture);

            //act
            var result = Program.IsValidTime(toLate);

            //assert
            Assert.IsTrue(result);

        }

    }
}
