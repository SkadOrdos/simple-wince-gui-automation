using NUnit.Framework;
using SimpleWinceGuiAutomation.AppTest;

namespace SimpleWinceGuiAutomation.Tests
{
    [TestFixture]
    public class CheckBoxesTest : WinceTest
    {
        [Test]
        public void TestCheck()
        {
            var checkBox = application.MainWindow.CheckBoxes.WithText("My checkbox");
            Assert.AreEqual("My checkbox", checkBox.Text);
            Assert.IsFalse(checkBox.Checked);
            checkBox.Checked = true;
            Assert.IsTrue(checkBox.Checked);
        }
    }
}
