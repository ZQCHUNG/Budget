using Budget.Interfaces;
using Budget.Models;
using Budget.Services;
using FluentAssertions;
using NSubstitute;

namespace BudgetTests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void query_whole_month()
    {
        IBudgetRepo budgetRepo = Substitute.For<IBudgetRepo>();

        budgetRepo.GetAll().Returns(new List<BudgetDto>()
        {
            new BudgetDto()
            {
                YearMonth = "202312",
                Amount = 3100
            }
        });
        
        var budgetService = new BudgetService(budgetRepo);

        var amount = budgetService.Query(new DateTime(2023,12,01), new DateTime(2023,12,31));

        amount.Should().Be(3100);
    }
}