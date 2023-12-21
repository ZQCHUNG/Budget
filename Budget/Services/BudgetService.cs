using Budget.Interfaces;

namespace Budget.Services;

public class BudgetService
{
    private readonly IBudgetRepo _budgetRepo;

    public BudgetService(IBudgetRepo budgetRepo)
    {
        _budgetRepo = budgetRepo;
    }
    public decimal Query(DateTime start, DateTime end)
    {
        var budgetDtos = _budgetRepo.GetAll();
       
        var startYearMonth = start.ToString("yyyyMM");
        return budgetDtos.Where(x => x.YearMonth == startYearMonth).Sum(o => o.Amount);
        return 3100;
    }
}