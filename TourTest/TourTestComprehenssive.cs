using Springertour.Model;

namespace TourTest
{
    public class TourTestComprehenssive
    {
        [Theory]
        [ClassData(typeof(CounterTestData))]
        public void AllFieldsTest(int value1, int value2)
        {


            Tour tour = new Tour(value1, value2);
            tour.StartTour();

            Assert.True(tour.GetCounter() == 64);


        }
    }
}