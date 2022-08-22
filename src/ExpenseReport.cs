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

                string expenseName = expense.ToExpenseName();

                String mealOverExpensesMarker = expense.IsOverLimit
                        ? "X"
                        : " ";

                Console.WriteLine(expenseName + "\t" + expense.Amount + "\t" + mealOverExpensesMarker);

                total += expense.Amount;
            }

            Console.WriteLine("Meal expenses: " + mealExpenses);
            Console.WriteLine("Total expenses: " + total);
        }

        
    }
}
