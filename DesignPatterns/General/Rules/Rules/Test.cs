﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rules.Rules
{
    internal class Test
    {
        internal class Language
        {
            public string name;
            public string popular;
        }

        private class Book
        {
            public string title;
            public string author;
            public Language Attribute { get; set; }

            public int count = 3;
        }

        public static void test()
        {
            var language = new Language
            {
                name = "English"
            };

            var book = new Book { title = "Joker", author = "gaur", Attribute = language };

            //c# pattern matching https://docs.microsoft.com/en-us/archive/msdn-magazine/2019/may/csharp-8-0-pattern-matching-in-csharp-8-0
            var action = "withdraw";
            book.count = 0;
            var check = (book, action) switch
            {
                ({ Attribute: { name: "English" }, count: 0 }, "withdraw") => "All books are checked out",
                ({ Attribute: { name: "English" } }, "withdraw") => "found",
                _ => "not found"
            };

            Console.WriteLine($"result - {check}");
        }
    }
}