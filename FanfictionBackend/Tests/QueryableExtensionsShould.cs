using NUnit.Framework;
using FanfictionBackend.ExtensionClasses;

namespace Tests;

[TestFixture]
public class QueryableExtensionsShould
{
    private IQueryable<int> queryable;
    [SetUp]
    public void SetUp()
    {
        queryable =  new EnumerableQuery<int>(new []{1, 2, 3, 4, 5});
    }
    
    [Test]
    [TestCase(0,1)]
    [TestCase(0,0)]
    [TestCase(1,0)]
    [TestCase(-1, -1)]
    public void ToPaginationList_ShouldThrowArgumentException_WhenArgumentsAreNotPositive(int pageNumber, int pageSize)
    {
        queryable
            .Invoking(q => q.ToPaginationList(pageNumber, pageSize))
            .Should()
            .Throw<ArgumentException>();
    }

    [Test]
    public void ToPaginationList_ShouldThrowArgumentException_WhenPageNumberIsGreaterThanExistingPagesCount()
    {
        var pageNumber = queryable.Count() + 1;
        var pageSize = queryable.Count() / 2;
        queryable
            .Invoking(q => q.ToPaginationList(pageNumber, pageSize))
            .Should()
            .Throw<ArgumentException>();
    }

    [Test]
    public void ToPaginationList_ShouldReturnPageListWithFalseHasNextPage_WhenPageNumberIsLast()
    {
        var paginationList = queryable.ToPaginationList( queryable.Count(), 1);
        paginationList.HasNextPage.Should().BeFalse();
    }
    
    [Test]
    public void ToPaginationList_ShouldReturnPageListWithFalseHasPreviousPage_WhenPageNumberIsFirst()
    {
        var paginationList = queryable.ToPaginationList( 1, 1);
        paginationList.HasPreviousPage.Should().BeFalse();
    }

    [Test]
    [TestCase(2,1)]
    [TestCase(4,1)]
    [TestCase(2,2)]
    public void ToPaginationList_ShouldReturnPageListWithTrueHasPreviousPageAndHasNextPage_WhenArgumentsAreNotAnEdgeCases(int pageNumber, int pageSize)
    {
        var paginationList = queryable.ToPaginationList(pageNumber, pageSize);
        paginationList.HasNextPage.Should().BeTrue();
        paginationList.HasPreviousPage.Should().BeTrue();
    }
    
    [Test]
    public void ToPaginationList_ShouldReturnPageListWithRightEntries_WhenArgumentsAreNotAnEdgeCases()
    {
        var pageNumber = 2;
        var pageSize = 2;
        var paginationList = queryable.ToPaginationList(pageNumber, pageSize);
        paginationList.Should().BeEquivalentTo(new[] { 3, 4 });
    }
    
    [Test]
    public void ToPaginationList_ShouldReturnPageListWithRightCount_WhenArgumentsAreNotAnEdgeCases()
    {
        var pageNumber = 2;
        var pageSize = 2;
        var paginationList = queryable.ToPaginationList(pageNumber, pageSize);
        paginationList.Count.Should().Be(2);
    }
}