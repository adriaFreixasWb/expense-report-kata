namespace ExpenseReports
{
    public class Expense
    {
        public ExpenseType Type { get; set; }
        public int Amount { get; set; }
        public bool IsMeal
        {
            get => 
                Type == ExpenseType.DINNER ||
                Type == ExpenseType.BREAKFAST;
        }
        public bool IsOverLimit
        {
            get =>  Amount > Type.Limit ;
        }
        public string ToExpenseName() =>
            Type.Name;
    }
}
