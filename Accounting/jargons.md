# transaction types


1, "Inventory", SeriesRoot.Assets);
2, "A/R", SeriesRoot.Assets);
3, "A/P", SeriesRoot.Liabilities);
4, "A/P Suspense", SeriesRoot.Liabilities);
5, "Sales", SeriesRoot.Income)
6, "Sales Return", SeriesRoot.Income);
7, "COGS", SeriesRoot.CostOfGoodsSold);
8, "Physical Inventory (Adjustment)", SeriesRoot.CostOfGoodsSold);
9, "A/R Discount", SeriesRoot.Income);
10, "A/P Discount", SeriesRoot.CostOfGoodsSold);
11, "Retained Earnings", SeriesRoot.Equity);
12, "Sales Tax", SeriesRoot.Liabilities);
13, "Foreign Exchange P&L", SeriesRoot.OtherIncomeExpenses);
14, "Wrong postings", SeriesRoot.WrongPostings);
15, "Undeposited Funds", SeriesRoot.Assets);


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