using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitors
{
    public interface IAssetProcessor
    {
        void Process(RealEstate realEstate);

        void Process(Loan loan);

        void Process(BankAccount bankAccount);
    }

    public class NetWorthProcessor : IAssetProcessor
    {
        public int Total { get; set; }

        public void Process(RealEstate realEstate)
        {
            Total += realEstate.EstimatedValue;
        }

        public void Process(Loan loan)
        {
            Total -= loan.Owed;
        }

        public void Process(BankAccount bankAccount)
        {
            Total += bankAccount.Amount;
        }
    }

    public interface IAsset
    {
        void Accept(IAssetProcessor processor);
    }

    internal class PersonProgram
    {
        internal static void Run()
        {
            var person = new Person();
            person.Assets.Add(new BankAccount { Amount = 1000, MonthlyInterest = 0.01 });
            person.Assets.Add(new BankAccount { Amount = 2000, MonthlyInterest = 0.02 });

            person.Assets.Add(new RealEstate { EstimatedValue = 79000, MonthlyRent = 500 });

            person.Assets.Add(new Loan { Owed = 40000, MonthlyPayment = 40 });

            //int netWorth = 0;
            //foreach (var bankAccount in person.BankAccounts)
            //    netWorth += bankAccount.Amount;
            //
            //foreach (var realEstate in person.RealEstates)
            //    netWorth += realEstate.EstimatedValue;
            //
            //foreach (var loan in person.Loans)
            //    netWorth -= loan.Owed;

            var netWorthVisitor = new NetWorthProcessor();
            person.Accept(netWorthVisitor);

            Console.WriteLine(netWorthVisitor.Total);
            Console.ReadLine();
        }
    }
}