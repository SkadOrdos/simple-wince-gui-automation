using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using SimpleWinceGuiAutomation.AppTest;

namespace SimpleWinceGuiAutomation.Tests
{
    [TestFixture]
    public class TestComponents
    {

        [Test]
        public void TestReadAllButtons()
        {
            var application = WinceApplicationFactory.StartFromTypeInApplication<Form1>();
            var buttons = application.MainWindow.Buttons.All;
            Assert.AreEqual(2, buttons.Count);
            Assert.AreEqual("Bouton1", buttons[0].Text);
            Assert.AreEqual("OtherButton", buttons[1].Text);
            application.Kill();
        }

        [Test]
        public void TestReadAllCheckBoxes()
        {
            var application = WinceApplicationFactory.StartFromTypeInApplication<Form1>();
            var checkBoxes = application.MainWindow.CheckBoxes.All;
            Assert.AreEqual(2, checkBoxes.Count);
            Assert.IsFalse(checkBoxes[0].Checked);
            Assert.AreEqual("My checkbox", checkBoxes[0].Text);
            Assert.IsTrue(checkBoxes[1].Checked);
            Assert.AreEqual("My checkbox checked", checkBoxes[1].Text);
            application.Kill();
        }

        //[Test]
        public void TestButton()
        {
            var application = WinceApplicationFactory.StartFromTypeInApplication<Form1>();
            var button = application.MainWindow.Buttons.WithText("OtherButton");
            Assert.AreEqual("OtherButton", button.Text);
            button.Click();
            Assert.AreEqual("Clicked", button.Text);
            application.Kill();
        }
    }
}
