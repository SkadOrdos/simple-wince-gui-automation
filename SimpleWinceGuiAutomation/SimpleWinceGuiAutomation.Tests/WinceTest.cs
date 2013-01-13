using NUnit.Framework;
using SimpleWinceGuiAutomation.AppTest;

namespace SimpleWinceGuiAutomation.Tests
{
    public class WinceTest
    {
        protected WinceApplication application;

        [SetUp]
        public void Init()
        {
            application = WinceApplicationFactory.StartFromTypeInApplication<Form1>();
        }

        [TearDown]
        public void KillApp()
        {
            application.Kill();
        }
    }
}