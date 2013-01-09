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

        [Test]
        public void TestReadAllContainers()
        {
            var pictureBoxes = application.MainWindow.Containers.All;
            Assert.AreEqual(2, pictureBoxes.Count);
        }

        [Test]
        public void TestReadAllLabels()
        {
            var labels = application.MainWindow.Labels.All;
            Assert.AreEqual(1, labels.Count);
            Assert.AreEqual("A label", labels[0].Text);
        }

        [Test]
        public void TestReadAllRadios()
        {
            var radios = application.MainWindow.Radios.All;
            Assert.AreEqual(2, radios.Count);
            Assert.AreEqual("A label", radios[0].Text);
        }
    }
}
