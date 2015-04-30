using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactoringExercise
{
    public class Customer
    {
        private List<Rental> _rentals = new List<Rental>();

        public Customer(string name)
        {
            Name = name;
        }

        public String Name { get; private set; }

        public void AddRental(Rental arg)
        {
            _rentals.Add(arg);
        }

        public String CreateStatement()
        {
            FrequentRenterPoints frequentRenterPoints = new FrequentRenterPoints();
            StringBuilder result = new StringBuilder("Rental Record for " + Name + "\n");
            double totalAmount = AllRentals(frequentRenterPoints, _rentals, result);
            GetFooterLines(result, totalAmount, frequentRenterPoints.Get());
            return result.ToString();
        }

        private double AllRentals(FrequentRenterPoints frequentRenterPoints, IEnumerable<Rental> rentals, StringBuilder result)
        {
            double totalAmount = 0;
            foreach (var rental in _rentals)
            {
                totalAmount += OnRental(frequentRenterPoints, result, rental);
            }

            return totalAmount;
        }

        private double OnRental(FrequentRenterPoints frequentRenterPoints, StringBuilder result, Rental rental)
        {
            double thisAmount = DetermineAmountsForEachLine(rental);
            frequentRenterPoints.Add(rental);
            ShowFiguresForThisRental(result, rental, thisAmount);
            return thisAmount;
        }

        private void GetFooterLines(StringBuilder result, double totalAmount, int frequentRenterPoints)
        {
            // add footer lines
            result.Append("Amount owed is " + totalAmount + "\n");
            result.Append("You earned " + frequentRenterPoints + " frequent renter points");
        }

        private void ShowFiguresForThisRental(StringBuilder result, Rental each, double thisAmount)
        {
            result.Append("\t" + each.Movie.Title + "\t" + thisAmount + "\n");
        }

        private double DetermineAmountsForEachLine(Rental each)
        {
            double thisAmount = 0;
            switch (each.Movie.PriceCode)
            {
                case Movie.REGULAR:
                    thisAmount += 2;
                    if (each.DaysRented > 2)
                    {
                        thisAmount += (each.DaysRented - 2) * 1.5;
                    }
                    break;
                case Movie.NEW_RELEASE:
                    thisAmount += each.DaysRented * 3;
                    break;
                case Movie.CHILDRENS:
                    thisAmount += 1.5;
                    if (each.DaysRented > 3)
                    {
                        thisAmount += (each.DaysRented - 3) * 1.5;
                    }
                    break;
            }
            return thisAmount;
        }
    }

}
