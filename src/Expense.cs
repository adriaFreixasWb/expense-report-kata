﻿namespace ExpenseReports
{
    public class Expense
    {
        public ExpenseType Type { get; set; }
        public int Amount { get; set; }
        public bool IsMeal
        {
            get => Type == ExpenseType.DINNER || 
                Type == ExpenseType.BREAKFAST;
        }
        public string ToExpenseName()
        {
            if(Type == ExpenseType.DINNER)
            { 
                return "Dinner"; 
            }
            if (Type == ExpenseType.BREAKFAST)
            {
                return "Breakfast";
            }
            if (Type == ExpenseType.CAR_RENTAL)
            {
                return "Car Rental";
            }
            return string.Empty;
        }
    }
}
