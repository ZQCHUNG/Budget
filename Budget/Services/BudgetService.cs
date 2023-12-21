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
        // var budgetDtos = _budgetRepo.GetAll();
        
        return 3100;
    }
}