

using NUnit.Framework;
using Assessment4;
using NUnit.Framework.Legacy;

namespace TestAccounts
{
    [TestFixture]
    public class DistanceTest
    {
        Distance d1;
        Distance d2;

        [SetUp]
        public void ArrangeObjects()
        {
            d1 = new Distance { Kilometer = 20 };
            d2 = new Distance { Kilometer = 30 };
        }

        [Test]
        public void Add_TwoDistanceObjects_ReturnsCorrectSum()
        {
            // Act
            Distance d3 = Distance.Add(d1, d2);

            // Assert
            ClassicAssert.AreEqual(50, d3.Kilometer);

            // Output
            TestContext.WriteLine(d3.Display());
        }

        [TestCase(10, 40, 50)]
        [TestCase(25, 25, 50)]
        [TestCase(15, 35, 50)]
        public void Add_Distance_WithParameters(int km1, int km2, int expected)
        {
            Distance d1 = new Distance { Kilometer = km1 };
            Distance d2 = new Distance { Kilometer = km2 };

            Distance d3 = Distance.Add(d1, d2);

            ClassicAssert.AreEqual(expected, d3.Kilometer);
        }
    }
}
