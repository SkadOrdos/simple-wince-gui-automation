using NUnit.Framework;
using SimpleWinceGuiAutomation.AppTest;

namespace SimpleWinceGuiAutomation.Tests
{
    [TestFixture]
    public class RadiosTest : WinceTest
    {
        [Test]
        public void TestCheck()
        {
            var firstRadio = application.MainWindow.Radios.WithText("First Radio");
            var secondRadio = application.MainWindow.Radios.WithText("Second Radio");
            Assert.AreEqual("First Radio", firstRadio.Text);
            Assert.IsTrue(firstRadio.Checked);
            Assert.AreEqual("Second Radio", secondRadio.Text);
            Assert.IsFalse(secondRadio.Checked);
            secondRadio.Click();
            Assert.IsTrue(secondRadio.Checked);
            Assert.IsFalse(firstRadio.Checked);
        }
    }
}
