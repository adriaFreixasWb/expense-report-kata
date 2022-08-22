﻿namespace ExpenseReports
{
    public record ExpenseType
    {
        public static ExpenseType DINNER { get; } = new ExpenseType("Dinner", true, 5000);
        public static ExpenseType BREAKFAST { get; } = new ExpenseType("Breakfast", true, 1000);
        public static ExpenseType CAR_RENTAL { get; } = new ExpenseType("Car Rental", true, int.MaxValue);

        public string Name { get; }
        public bool IsMeal { get; }
        public int Limit { get; }
        
        private ExpenseType(string name, bool isMeal, int limit) =>
            (Name, IsMeal, Limit) = (name, isMeal, limit);

    }
}