using Budget.Interfaces;
using Budget.Models;
using Budget.Services;
using FluentAssertions;
using NSubstitute;

namespace BudgetTests;

public class BudgetTests
{
    private IBudgetRepo _budgetRepo = null!;
    private BudgetService _budgetService = null!;

    [SetUp]
    public void Setup()
    {
        _budgetRepo = Substitute.For<IBudgetRepo>();
        _budgetService = new BudgetService(_budgetRepo);
    }

    [Test]
    public void query_whole_month()
    {
        GivenBudget(
            new BudgetDto()
            {
                YearMonth = "202312",
                Amount = 3100
            }
        );

        var amount = WhenQueryBudget(new DateTime(2023, 12, 01), new DateTime(2023, 12, 31));

        amount.Should().Be(3100);
    }

    [Test]
    public void query_cross_month()
    {
        GivenBudget(
            new BudgetDto()
            {
                YearMonth = "202312",
                Amount = 3100
            },
            new BudgetDto
            {
                YearMonth = "202311",
                Amount = 600
            }
        );

        var start = new DateTime(2023, 11, 01);
        var end = new DateTime(2023, 12, 10);
        var amount = WhenQueryBudget(start, end);

        amount.Should().Be(1600);
    }

    [Test]
    public void query_partial_month()
    {
        GivenBudget(
            new BudgetDto()
            {
                YearMonth = "202312",
                Amount = 3100
            }
        );

        var start = new DateTime(2023, 12, 01);
        var end = new DateTime(2023, 12, 10);
        var amount = WhenQueryBudget(start, end);

        amount.Should().Be(1000);
    }


    private decimal WhenQueryBudget(DateTime start, DateTime end)
    {
        var amount = _budgetService.Query(start, end);
        return amount;
    }

    private void GivenBudget(params BudgetDto[] budgetDtos)
    {
        _budgetRepo.GetAll().Returns(budgetDtos.ToList());
    }
}