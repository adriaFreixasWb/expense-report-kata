namespace ExpenseReports.Test;

public class ExpenseReportShould
{
    private readonly ExpenseReport _expenseReport = new ExpenseReport();
    private readonly StringWriter _stringWriter = new StringWriter();
    private readonly DateTime _currentDate = new DateTime(2022, 08, 01);
    public ExpenseReportShould()
    {
        Console.SetOut(_stringWriter);
    }

    [Fact]
    public void Print_Empty_List()
    {
        var expectedOutput = $"Expenses {_currentDate}\r\nMeal expenses: 0\r\nTotal expenses: 0\r\n";
        _expenseReport.PrintReport(CreateExpenseList(), _currentDate);
        Assert.Equal(expectedOutput, _stringWriter.ToString());
    }

    [Theory]
    [InlineData("DINNER", 5001, "Dinner")]
    [InlineData("BREAKFAST", 1001, "Breakfast")]
    public void Print_Non_Accepted_Meal_Expensese(string expenseType, int cost, string expectedExpense)
    {
        var expectedOutput = $"Expenses {_currentDate}\r\n{expectedExpense}\t{cost}\tX\r\nMeal expenses: {cost}\r\nTotal expenses: {cost}\r\n";
        List<Expense> expenses = CreateExpenseList(
            CreateExpense(expenseType, cost));

        _expenseReport.PrintReport(expenses, _currentDate);
        Assert.Equal(expectedOutput, _stringWriter.ToString());
    }


    [Theory]
    [InlineData("DINNER", 5000, "Dinner", 5000)]
    [InlineData("BREAKFAST", 1000, "Breakfast", 1000)]
    [InlineData("CAR_RENTAL", 10000, "Car Rental", 0)]
    public void Print_Accepted_Expensese(string expenseType, int cost, string expectedExpense, int exptectedMealExpense)
    {
        var expectedOutput = $"Expenses {_currentDate}\r\n{expectedExpense}\t{cost}\t \r\nMeal expenses: {exptectedMealExpense}\r\nTotal expenses: {cost}\r\n";
        var expenses = CreateExpenseList(
            CreateExpense(expenseType, cost));

        _expenseReport.PrintReport(expenses, _currentDate);
        Assert.Equal(expectedOutput, _stringWriter.ToString());
    }

    [Fact]
    public void Print_List_Of_Expenses()
    {   var expectedOutput = $"Expenses {_currentDate}\r\n" +
            "Dinner\t5000\t \r\n" +
            "Dinner\t5001\tX\r\n" +
            "Breakfast\t1000\t \r\n" +
            "Breakfast\t1001\tX\r\n" +
            "Car Rental\t10000\t \r\n" +
            "Meal expenses: 12002\r\nTotal expenses: 22002\r\n";

        var expenses = CreateExpenseList(
            CreateExpense(5000, ExpenseType.DINNER),
            CreateExpense(5001, ExpenseType.DINNER),
            CreateExpense(1000, ExpenseType.BREAKFAST),
            CreateExpense(1001, ExpenseType.BREAKFAST),
            CreateExpense(10000, ExpenseType.CAR_RENTAL));

        _expenseReport.PrintReport(expenses, _currentDate);
        Assert.Equal(expectedOutput, _stringWriter.ToString());
    }
    private static Expense CreateExpense(string expenseType, int cost) =>
        new Expense { amount = cost, type = Enum.Parse<ExpenseType>(expenseType) };
    private static Expense CreateExpense(int cost, ExpenseType expenseType) =>
        new Expense { amount = cost, type = expenseType };
    private static List<Expense> CreateExpenseList(params Expense[] expenses) =>
        expenses.ToList();
}