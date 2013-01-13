using System.Collections.Generic;
using NUnit.Framework;
using SimpleWinceGuiAutomation.Components;

namespace SimpleWinceGuiAutomation.Tests
{
    [TestFixture]
    public class RadiosTest : WinceTest
    {
        [Test]
        public void TestCheck()
        {
            WinceRadio firstRadio = application.MainWindow.Radios.WithText("First Radio");
            WinceRadio secondRadio = application.MainWindow.Radios.WithText("Second Radio");
            Assert.AreEqual("First Radio", firstRadio.Text);
            Assert.IsTrue(firstRadio.Checked);
            Assert.AreEqual("Second Radio", secondRadio.Text);
            Assert.IsFalse(secondRadio.Checked);
            secondRadio.Click();
            Assert.IsTrue(secondRadio.Checked);
            Assert.IsFalse(firstRadio.Checked);
        }

        [Test]
        public void TestReadAllRadios()
        {
            List<WinceRadio> radios = application.MainWindow.Radios.All;
            Assert.AreEqual(2, radios.Count);
            Assert.AreEqual("First Radio", radios[0].Text);
        }
    }
}