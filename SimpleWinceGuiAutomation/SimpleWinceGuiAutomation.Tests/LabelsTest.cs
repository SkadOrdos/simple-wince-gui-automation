using NUnit.Framework;
using SimpleWinceGuiAutomation.AppTest;

namespace SimpleWinceGuiAutomation.Tests
{
    [TestFixture]
    public class LabelsTest : WinceTest
    {
        [Test]
        public void TestClick()
        {
            var label = application.MainWindow.Labels.WithText("A label");
            Assert.AreEqual("A label", label.Text);
            label.Text = "New Label Text";
            Assert.AreEqual("New Label Text", label.Text);
        }

        [Test]
        public void TestReadAllLabels()
        {
            var labels = application.MainWindow.Labels.All;
            Assert.AreEqual(1, labels.Count);
            Assert.AreEqual("A label", labels[0].Text);
        }
    }
}
