using Springertour.Model;
using System.Diagnostics.Metrics;

namespace TourTest
{
    public class TourTestComprehenssive
    {
        [Theory]
        [ClassData(typeof(CounterTestData))]
        public void AllFieldsCounterTest(int value1, int value2)
        {
            Tour tour = new Tour(value1, value2);
            tour.StartTour();

            Assert.True(tour.GetCounter() == 64);
        }

        [Theory]
        [ClassData(typeof(CounterTestData))]
        public void AllFieldsAccesseOnlyOnceTest(int value1, int value2)
        {
            Tour tour = new Tour(value1, value2);
            tour.StartTour();

            List<int> fieldsVisited = new List<int>();
            foreach (int field in tour.GetFields())
            {
                if (fieldsVisited.Contains(field))
                {
                    throw new Exception("Field Accessed twice");
                }
                else
                {
                    fieldsVisited.Add(field);
                }
                

            }
            Assert.True(fieldsVisited.Count() == 64);
        }


    }
}