namespace ExpenseReports
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
    }
}
