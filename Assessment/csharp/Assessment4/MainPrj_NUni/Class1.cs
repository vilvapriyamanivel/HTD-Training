using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Assessment4;
using NUnit.Framework.Legacy;
using Unity;

namespace nunittest

{       [TestFixture]
        public class DistanceTest
        {
            Distance d1;
            Distance d2;
            IUnityContainer container;

            [SetUp]
            public void ArrangeObjects()
            {
                // Unity container creation
                container = new UnityContainer();

                // Register Distance class
                container.RegisterType<Distance>();

                // Resolve Distance objects
                d1 = container.Resolve<Distance>();
                d2 = container.Resolve<Distance>();

                d1.Kilometer = 20;
                d2.Kilometer = 30;
            }

            [Test]
            public void Add_TwoDistanceObjects_ReturnsCorrectSum()
            {
                // Act
                Distance d3 = Distance.Add(d1, d2);

                // Assert
                ClassicAssert.AreEqual(50, d3.Kilometer);

                // Display
                TestContext.WriteLine(d3.Display());
            }

            [TestCase(10, 40, 50)]
            [TestCase(25, 25, 50)]
            [TestCase(15, 35, 50)]
            public void Add_Distance_WithParameters(int km1, int km2, int expected)
            {
                Distance d1 = container.Resolve<Distance>();
                Distance d2 = container.Resolve<Distance>();

                d1.Kilometer = km1;
                d2.Kilometer = km2;

                Distance d3 = Distance.Add(d1, d2);

                ClassicAssert.AreEqual(expected, d3.Kilometer);
            }
        }
    }




