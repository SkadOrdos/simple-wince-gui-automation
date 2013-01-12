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
            //var comboBox = application.MainWindow.ComboBoxes.All[0];
            //Assert.AreEqual("", comboBox.Text);
            //comboBox.Select("First");
            //Assert.AreEqual("First", comboBox.Text);
            //comboBox.Select("Non existing");
            //Assert.AreEqual("", comboBox.Text);
        }
    }
}
