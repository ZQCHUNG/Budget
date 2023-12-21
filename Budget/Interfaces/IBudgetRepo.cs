using Budget.Models;

namespace Budget.Interfaces;

public interface IBudgetRepo
{
    List<BudgetDto> GetAll();
}