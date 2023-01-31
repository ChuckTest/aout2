using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chapter2.LogAn;
using NUnit.Framework;

namespace LogAn.UnitTests
{
    [TestFixture]
    public class MemCalculatorTests
    {
        [Test]
        public void Sum_ByDefault_ReturnsZero()
        {
            MemCalculator calculator = MakeCalc();
            int lastSum = calculator.Sum();
            Assert.AreEqual(0, lastSum);
        }

        [Test]
        public void Add_WhenCalled_ChangeSum()
        {
            MemCalculator calculator = MakeCalc();
            calculator.Add(1);
            calculator.Add(2);
            calculator.Add(3);
            calculator.Add(4);
            calculator.Add(5);

            int sum = calculator.Sum();
            Assert.AreEqual(15,sum);
        }

        private static MemCalculator MakeCalc()
        {
            return new MemCalculator();
        }
    }
}
