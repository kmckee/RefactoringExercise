using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactoringExercise
{
    public class FrequentRenterPoints
    {
        private int frequentRenterPoints;

        public void Add(Rental rental)
        {
            this.frequentRenterPoints += CalculateFrequentRenterPoints(rental);
        }

        public int Get()
        {
            return frequentRenterPoints;
        }

        private int CalculateFrequentRenterPoints(Rental each)
        {
            // add frequent renter points
            int frequentRenterPoints = 1;
            // add bonus for a two day new release rental
            if ((each.Movie.PriceCode == Movie.NEW_RELEASE) && each.DaysRented > 1)
            {
                frequentRenterPoints++;
            }
            return frequentRenterPoints;
        }

    }

}
