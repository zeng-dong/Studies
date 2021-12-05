using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitors
{
    public class Person
    {
        public List<RealEstate> RealEstates = new();
        public List<Loan> Loans = new();
        public List<BankAccount> BankAccounts = new();
    }

    public class RealEstate
    {
        public int EstimatedValue { get; set; }
        public int MonthlyRent { get; set; }
    }

    public class BankAccount
    {
        public int Amount { get; set; }
        public double MonthlyInterest { get; set; }
    }

    public class Loan
    {
        public int Owed { get; set; }
        public int MonthlyPayment { get; set; }
    }
}