﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace SimpleWinceGuiAutomation.Tests
{
    [TestFixture]
    public class ContainersTest : WinceTest
    {
        [Test]
        public void TestReadAllContainers()
        {
            var pictureBoxes = application.MainWindow.Containers.All;
            Assert.AreEqual(2, pictureBoxes.Count);
        }
    }
}
