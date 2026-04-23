using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assessment4;

namespace MStoUnitTest
{
    [TestClass]
    public class DistanceTest
    {
        Distance d1;
        Distance d2;

        [TestInitialize]
        public void ArrangeObjects()
        {
            d1 = new Distance { Kilometer = 20 };
            d2 = new Distance { Kilometer = 30 };
        }

        [TestMethod]
        public void Add_TwoDistanceObjects_ReturnsCorrectSum()
        {
            Distance d3 = Distance.Add(d1, d2);

            Assert.AreEqual(50, d3.Kilometer);
            TestContext.WriteLine(d3.Display());
        }

        [DataTestMethod]
        [DataRow(10, 40, 50)]
        [DataRow(25, 25, 50)]
        [DataRow(15, 35, 50)]
        public void Add_Distance_WithParameters(int km1, int km2, int expected)
        {
            Distance d1 = new Distance { Kilometer = km1 };
            Distance d2 = new Distance { Kilometer = km2 };

            Distance d3 = Distance.Add(d1, d2);

            Assert.AreEqual(expected, d3.Kilometer);
        }

        public TestContext TestContext { get; set; }
    }
}