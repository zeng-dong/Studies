using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitors
{
    public class Person : IAsset
    {
        //public List<RealEstate> RealEstates = new();
        //public List<Loan> Loans = new();
        //public List<BankAccount> BankAccounts = new();

        public List<IAsset> Assets = new();

        public void Accept(IAssetProcessor processor)
        {
            foreach (var asset in Assets)
                asset.Accept(processor);
        }
    }

    public class RealEstate : IAsset
    {
        public int EstimatedValue { get; set; }
        public int MonthlyRent { get; set; }

        public void Accept(IAssetProcessor processor)
        {
            processor.Process(this);
        }
    }

    public class BankAccount : IAsset
    {
        public int Amount { get; set; }
        public double MonthlyInterest { get; set; }

        public void Accept(IAssetProcessor processor)
        {
            processor.Process(this);
        }
    }

    public class Loan : IAsset
    {
        public int Owed { get; set; }
        public int MonthlyPayment { get; set; }

        public void Accept(IAssetProcessor processor)
        {
            processor.Process(this);
        }
    }
}