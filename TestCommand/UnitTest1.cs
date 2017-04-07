using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DbAddSave;

namespace TestCommand
{
    [TestClass]
    public class TestCommand
    {
        [TestMethod]
        public void TestAdd()
        {
            AppViewModel xx = new AppViewModel();
            var xxx = xx.AddCommand;
            Console.WriteLine(xxx);
        }
    }
}
