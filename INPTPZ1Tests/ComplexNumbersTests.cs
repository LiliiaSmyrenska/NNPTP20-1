using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace INPTPZ1.Mathematics.Tests
{
    [TestClass()]
    public class ComplexNumberTests
    {

        [TestMethod()]
        public void AddTest()
        {
            ComplexNumberCalculate a = new ComplexNumberCalculate()
            {
                RealPart = 10,
                ImaginaryPart = 20
            };
            ComplexNumberCalculate b = new ComplexNumberCalculate()
            {
                RealPart = 1,
                ImaginaryPart = 2
            };

            ComplexNumberCalculate actual = a.Add(b);
            ComplexNumberCalculate shouldBe = new ComplexNumberCalculate()
            {
                RealPart = 11,
                ImaginaryPart = 22
            };

            Assert.AreEqual(shouldBe, actual);
        }
    }
}


