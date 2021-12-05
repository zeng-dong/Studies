﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitors
{
    public interface IVisitor
    {
        void Visit(RealEstate realEstate);

        void Visit(Loan loan);

        void Visit(BankAccount bankAccount);
    }

    public interface IAsset
    {
        void Accept(IVisitor visitor);
    }

    internal class PersonProgram
    {
        internal static void Run()
        {
            var person = new Person();
            person.BankAccounts.Add(new BankAccount { Amount = 1000, MonthlyInterest = 0.01 });
            person.BankAccounts.Add(new BankAccount { Amount = 2000, MonthlyInterest = 0.02 });

            person.RealEstates.Add(new RealEstate { EstimatedValue = 79000, MonthlyRent = 500 });

            person.Loans.Add(new Loan { Owed = 40000, MonthlyPayment = 40 });

            int netWorth = 0;
            foreach (var bankAccount in person.BankAccounts)
                netWorth += bankAccount.Amount;

            foreach (var realEstate in person.RealEstates)
                netWorth += realEstate.EstimatedValue;

            foreach (var loan in person.Loans)
                netWorth -= loan.Owed;

            Console.WriteLine(netWorth);
            Console.ReadLine();
        }
    }
}