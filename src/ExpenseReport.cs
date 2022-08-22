namespace ExpenseReports
{

    public class ExpenseReport
    {
        public void PrintReport(List<Expense> expenses)
        {
            PrintReport(expenses, DateTime.Now);
        }

        public void PrintReport(List<Expense> expenses, DateTime dateTime)
        {
            int total = 0;
            int mealExpenses = 0;

            Console.WriteLine("Expenses " + dateTime);

            foreach (Expense expense in expenses)
            {
                if (expense.IsMeal)
                {
                    mealExpenses += expense.Amount;
                }

                Console.WriteLine(ToExpenseReportLine(expense));

                total += expense.Amount;
            }

            Console.WriteLine("Meal expenses: " + mealExpenses);
            Console.WriteLine("Total expenses: " + total);
        }

        public string ToExpenseReportLine(Expense expense) =>
             expense.ToExpenseName() + "\t" + expense.Amount + "\t" +
            GetIsOverLimitDisplay(expense);

        private string GetIsOverLimitDisplay(Expense expense) =>
            expense.IsOverLimit 
            ? "X"
            : " ";
    }
}
