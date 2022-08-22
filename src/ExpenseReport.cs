﻿namespace ExpenseReports
{
    public enum ExpenseType
    {
        DINNER, BREAKFAST, CAR_RENTAL
    }

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
                if (IsMeal(expense))
                {
                    mealExpenses += expense.amount;
                }

                String expenseName = "";
                switch (expense.type)
                {
                    case ExpenseType.DINNER:
                        expenseName = "Dinner";
                        break;
                    case ExpenseType.BREAKFAST:
                        expenseName = "Breakfast";
                        break;
                    case ExpenseType.CAR_RENTAL:
                        expenseName = "Car Rental";
                        break;
                }

                String mealOverExpensesMarker =
                    expense.type == ExpenseType.DINNER && expense.amount > 5000 ||
                    expense.type == ExpenseType.BREAKFAST && expense.amount > 1000
                        ? "X"
                        : " ";

                Console.WriteLine(expenseName + "\t" + expense.amount + "\t" + mealOverExpensesMarker);

                total += expense.amount;
            }

            Console.WriteLine("Meal expenses: " + mealExpenses);
            Console.WriteLine("Total expenses: " + total);
        }

        private static bool IsMeal(Expense expense)
        {
            return expense.type == ExpenseType.DINNER || expense.type == ExpenseType.BREAKFAST;
        }
    }
}
