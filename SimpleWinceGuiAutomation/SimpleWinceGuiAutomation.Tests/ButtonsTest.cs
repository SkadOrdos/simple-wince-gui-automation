using System.Collections.Generic;
using NUnit.Framework;

namespace SimpleWinceGuiAutomation.Tests
{
    [TestFixture]
    public class ButtonsTest : WinceTest
    {
        [Test]
        public void TestClick()
        {
            WinceButton button = application.MainWindow.Buttons.WithText("OtherButton");
            Assert.AreEqual("OtherButton", button.Text);
            button.Click();
            Assert.AreEqual("Clicked", button.Text);
        }

        [Test]
        public void TestReadAllButtons()
        {
            List<WinceButton> buttons = application.MainWindow.Buttons.All;
            Assert.AreEqual(2, buttons.Count);
            Assert.AreEqual("Bouton1", buttons[0].Text);
            Assert.AreEqual("OtherButton", buttons[1].Text);
            Assert.AreEqual(20, buttons[0].Size.Height);
        }
    }
}