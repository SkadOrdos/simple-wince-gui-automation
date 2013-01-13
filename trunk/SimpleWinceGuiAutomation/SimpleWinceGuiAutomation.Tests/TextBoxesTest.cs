using System.Collections.Generic;
using NUnit.Framework;

namespace SimpleWinceGuiAutomation.Tests
{
    [TestFixture]
    public class TextBoxesTest : WinceTest
    {
        [Test]
        public void TestClick()
        {
            WinceTextBox button = application.MainWindow.TextBoxes.WithText("Premier");
            Assert.AreEqual("Premier", button.Text);
            button.Text = "Other";
            Assert.AreEqual("Other", button.Text);
        }

        [Test]
        public void TestReadAllTextBoxes()
        {
            List<WinceTextBox> textBoxes = application.MainWindow.TextBoxes.All;
            Assert.AreEqual(2, textBoxes.Count);
            Assert.AreEqual("Premier", textBoxes[0].Text);
            Assert.AreEqual("Second", textBoxes[1].Text);
        }
    }
}