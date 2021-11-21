# transaction types
## each belong to a Series (or root heading)
1, "Inventory", SeriesRoot.Assets
2, "A/R", SeriesRoot.Assets
3, "A/P", SeriesRoot.Liabilities
4, "A/P Suspense", SeriesRoot.Liabilities
5, "Sales", SeriesRoot.Income
6, "Sales Return", SeriesRoot.Income
7, "COGS", SeriesRoot.CostOfGoodsSold
8, "Physical Inventory (Adjustment)", SeriesRoot.CostOfGoodsSold
9, "A/R Discount", SeriesRoot.Income
10, "A/P Discount", SeriesRoot.CostOfGoodsSold
11, "Retained Earnings", SeriesRoot.Equity
12, "Sales Tax", SeriesRoot.Liabilities
13, "Foreign Exchange P&L", SeriesRoot.OtherIncomeExpenses
14, "Wrong postings", SeriesRoot.WrongPostings
15, "Undeposited Funds", SeriesRoot.Assets


# series
## are basically root headings
## grouping headings
## they are:
	1, "Assets"
	2, "Liabilities"
	3, "Equity"
	4, "Income"
	5, "Cost of Goods Sold"
	6, "Expenses"
	7, "TBD"
	8, "Other Income/Expenses"
	9, "Wrong Postings"
## each series contains Transaction Types
	1, "Assets"
		1, "Inventory"
		2, "A/R"
		15, "Undeposited Funds"		
	2, "Liabilities"
		3, "A/P"
		4, "A/P Suspense"
		12, "Sales Tax"
	3, "Equity"
		11, "Retained Earnings"
	4, "Income"
		5, "Sales"
		6, "Sales Return"
		9, "A/R Discount"
	5, "Cost of Goods Sold"
		7, "COGS"
		8, "Physical Inventory (Adjustment)"
		10, "A/P Discount"
	6, "Expenses"
	7, "TBD"
	8, "Other Income/Expenses"
		13, "Foreign Exchange P&L"
	9, "Wrong Postings"
		14, "Wrong postings"

# posting account type
## each Posting Account Type belongs to a Series
1, "Accounts Receivable (A/R)", SeriesRoot.Assets);
2, "Other Current Assets", SeriesRoot.Assets);
3, "Bank", SeriesRoot.Assets);
4, "Fixed Assets", SeriesRoot.Assets);
5, "Other Assets", SeriesRoot.Assets);
6, "Accounts Payable (A/P)", SeriesRoot.Liabilities);
7, "Credit Card", SeriesRoot.Liabilities);
8, "Other Current Liabilities", SeriesRoot.Liabilities);
9, "Equity", SeriesRoot.Equity);
10, "Income", SeriesRoot.Income);
11, "Cost of Goods Sold", SeriesRoot.CostOfGoodsSold);
12, "Expenses", SeriesRoot.Expenses);
13, "Misc Expenses", SeriesRoot.TBD);
14, "Misc Income", SeriesRoot.TBD);
15, "Other Expense", SeriesRoot.OtherIncomeExpenses);
16, "Wrong Postings", SeriesRoot.WrongPostings);
