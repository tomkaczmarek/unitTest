using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace LogAn.UnitTests
{
    [TestFixture]
    public class MemCalculatorTests
    {

        [Test]
        public void Sum_ByDefault_ReturnZero()
        {
            MemCalculator calc = MakeCalculator();

            int sum = calc.Sum();

            Assert.AreEqual(0, sum);
        }

        [Test]
        public void Add_WhenCalled_ChangeSum()
        {
            MemCalculator calc = MakeCalculator();

            calc.Add(1);

            Assert.AreEqual(1, calc.Sum());
        }
        
        private MemCalculator MakeCalculator()
        {
            return new MemCalculator();
        }
    }

}
