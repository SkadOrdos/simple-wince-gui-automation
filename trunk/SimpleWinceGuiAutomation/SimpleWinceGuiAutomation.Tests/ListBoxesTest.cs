using NUnit.Framework;
using SimpleWinceGuiAutomation.AppTest;

namespace SimpleWinceGuiAutomation.Tests
{
    [TestFixture]
    public class ListBoxesTest : WinceTest
    {
        [Test]
        public void TestList()
        {
            var listBoxes = application.MainWindow.ListBoxes.All;
            Assert.AreEqual(2, listBoxes.Count);
        }

        [Test]
        public void TestSelect()
        {
            var listBox = application.MainWindow.ListBoxes.All[0];
            Assert.AreEqual("", listBox.Text);
            listBox.Select("First");
            Assert.AreEqual("First", listBox.Text);
            listBox.Select("Non existing");
            Assert.AreEqual("", listBox.Text);
        }
    }
}
