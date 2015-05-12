using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using RefactoringExercise;

namespace Tests
{
    [TestFixture]
    public class CustomerTests
    {
        [Test]
        public void CreateStatement_Includes_FrequentRenterPoints()
        {
            var customer = new Customer("Ralph");
            customer.AddRental(new Rental(new Movie("Kung Fu Panda", Movie.CHILDRENS), daysRented: 6));

            var statement = customer.CreateStatement();

            Assert.That(statement, Is.StringContaining("You earned 1 frequent renter points"));
        }
    }
}
