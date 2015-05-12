using System;
using System.Collections.Generic;
using System.Text;

namespace RefactoringExercise
{
    public class Customer
    {
        private readonly List<Rental> _rentals = new List<Rental>();
        private int _frequentRenterPoints;

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
            StringBuilder statement = new StringBuilder("Rental Record for " + Name + "\n");
            double totalAmount = GetCostForAllRentalsAndCreateStatement(statement);
            AppendFooterLines(statement, totalAmount, _frequentRenterPoints);
            return statement.ToString();
        }

        private double GetCostForAllRentalsAndCreateStatement(StringBuilder statementStringBuilder)
        {
            double totalAmount = 0;
            foreach (var rental in _rentals)
            {
                totalAmount += OnRental(statementStringBuilder, rental);
            }

            return totalAmount;
        }

        private double OnRental(StringBuilder statement, Rental rental)
        {
            double thisAmount = DetermineAmountsForEachLine(rental);
            AddFrequentRenterPoints(rental);
            ShowFiguresForThisRental(statement, rental, thisAmount);
            return thisAmount;
        }

        private void AppendFooterLines(StringBuilder statement, double totalAmount, int frequentRenterPoints)
        {
            // add footer lines
            statement.Append("Amount owed is " + totalAmount + "\n");
            statement.Append("You earned " + frequentRenterPoints + " frequent renter points");
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

        private void AddFrequentRenterPoints(Rental rental)
        {
            _frequentRenterPoints += CalculateFrequentRenterPoints(rental);
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
