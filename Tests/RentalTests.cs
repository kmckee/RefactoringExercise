using NUnit.Framework;
using RefactoringExercise;

namespace Tests
{
    [TestFixture]
    public class RentalTests
    {
        private static readonly Movie ARBITRARY_MOVIE = new Movie("Movie Title", Movie.REGULAR);
        private const int ARBITRARY_DAYS = 1;

        [Test]
        public void Rental_DaysRented()
        {
            var expectedDaysRented = 3;

            var rental = new Rental(ARBITRARY_MOVIE, expectedDaysRented);

            Assert.That(rental.DaysRented, Is.EqualTo(expectedDaysRented));
        }

        [Test]
        public void Rental_Movie()
        {
            var expectedMovie = new Movie("Under Siege", Movie.REGULAR);

            var rental = new Rental(expectedMovie, ARBITRARY_DAYS);

            Assert.That(rental.Movie, Is.EqualTo(expectedMovie));
        }
    }
}
