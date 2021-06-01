using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace TablePerHierarchy.ConcreteBaseClass
{
    public class AccountApp
    {
        private static ExplicitDerivedTypesDbContext _context = new ExplicitDerivedTypesDbContext();

        public static void Run()
        {
            AddHeadingAccount();
            ListAccounts();
            ListPostingAccounts();

            AddPostingAccount();
            ListAccounts();
            ListPostingAccounts();

            AddAccounts();
            ListAccounts();
            ListPostingAccounts();
        }

        private static void AddHeadingAccount()
        {
            var account = new Account("Heading 1");
            _context.Accounts.Add(account);
            _context.SaveChanges();
        }

        private static void AddPostingAccount()
        {
            var account = new PostingAccount("Posting 1", 123);
            _context.PostingAccounts.Add(account);
            _context.SaveChanges();
        }

        private static void AddAccounts()
        {
            var headingAccount = new Account("Heading 2");
            _context.Accounts.Add(headingAccount);

            var account = new PostingAccount("Posting 2", 321);
            _context.Accounts.Add(account);
            _context.SaveChanges();
        }

        private static void ListAccounts()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("Accounts:");
            var accounts = _context.Accounts
                .TagWith("Explicit GetAccounts()")
                .ToList();

            foreach (var account in accounts)
            {
                Console.WriteLine(account.Name + ", " + account.IsPosting);
            }
            Console.ResetColor();
        }

        private static void ListPostingAccounts()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            var accounts = _context.PostingAccounts
                .TagWith("Explicit GetPostingAccounts()")
                .ToList();

            foreach (var account in accounts)
            {
                Console.WriteLine(account.Name + ", " + account.IsPosting + ", " + account.Amount);
            }

            Console.ResetColor();
        }


    }
}
