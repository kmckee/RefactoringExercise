using NUnit.Framework;
using RefactoringExercise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestFixture]
    public class MovieTests
    {
        private const int ARBITRARY_PRICE_CODE = Movie.REGULAR;
        private const string ARBITRARY_TITLE = "Under Siege";

        [Test]
        public void Movie_PriceCode()
        {
            var expectedPriceCode = Movie.CHILDRENS;

            var movie = new Movie(ARBITRARY_TITLE, expectedPriceCode);

            Assert.That(movie.PriceCode, Is.EqualTo(expectedPriceCode));
        }

        [Test]
        public void Movie_Title()
        {
            var expectedTitle = "How to Train Your Dragon 2";

            var movie = new Movie(expectedTitle, ARBITRARY_PRICE_CODE);

            Assert.That(movie.Title, Is.EqualTo(expectedTitle));
        }
    }
}
