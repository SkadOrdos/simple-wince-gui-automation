using System.Collections.Generic;
using NUnit.Framework;
using SimpleWinceGuiAutomation.Components;

namespace SimpleWinceGuiAutomation.Tests
{
    [TestFixture]
    public class ListBoxesTest : WinceTest
    {
        [Test]
        public void TestList()
        {
            List<WinceListBox> listBoxes = application.MainWindow.ListBoxes.All;
            Assert.AreEqual(2, listBoxes.Count);
        }

        [Test]
        public void TestSelect()
        {
            WinceListBox listBox = application.MainWindow.ListBoxes.All[0];
            List<string> items = listBox.Items;
            Assert.AreEqual(2, items.Count);
            Assert.AreEqual("First", items[0]);
            Assert.AreEqual("Second", items[1]);
            Assert.AreEqual(-1, listBox.SelectedItem);
            listBox.Select("First");
            Assert.AreEqual(0, listBox.SelectedItem);
        }
    }
}