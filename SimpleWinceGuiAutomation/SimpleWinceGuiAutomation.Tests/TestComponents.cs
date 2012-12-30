using NUnit.Framework;
using SimpleWinceGuiAutomation.AppTest;

namespace SimpleWinceGuiAutomation.Tests
{
    [TestFixture]
    public class TestComponents : WinceTest
    {

        [Test]
        public void TestReadAllButtons()
        {
            var buttons = application.MainWindow.Buttons.All;
            Assert.AreEqual(2, buttons.Count);
            Assert.AreEqual("Bouton1", buttons[0].Text);
            Assert.AreEqual("OtherButton", buttons[1].Text);
        }

        [Test]
        public void TestReadAllTextBoxes()
        {
            var textBoxes = application.MainWindow.TextBoxes.All;
            Assert.AreEqual(2, textBoxes.Count);
            Assert.AreEqual("Premier", textBoxes[0].Text);
            Assert.AreEqual("Second", textBoxes[1].Text);
        }

        [Test]
        public void TestReadAllCheckBoxes()
        {
            var checkBoxes = application.MainWindow.CheckBoxes.All;
            Assert.AreEqual(2, checkBoxes.Count);
            Assert.IsFalse(checkBoxes[0].Checked);
            Assert.AreEqual("My checkbox", checkBoxes[0].Text);
            Assert.IsTrue(checkBoxes[1].Checked);
            Assert.AreEqual("My checkbox checked", checkBoxes[1].Text);
        }

        [Test]
        public void TestReadAllComboBoxes()
        {
            var comboBoxes = application.MainWindow.ComboBoxes.All;
            Assert.AreEqual(2, comboBoxes.Count);
        }
    }
}
