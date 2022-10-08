using FluentAssertions;
using NUnit.Framework;
using SuddanApplication.Application.Common.Exceptions;
using SuddanApplication.Application.TodoLists.Commands.CreateTodoList;
using SuddanApplication.Application.TodoLists.Commands.DeleteTodoList;
using SuddanApplication.Domain.Entities;

using static SuddanApplication.Application.IntegrationTests.Testing;

namespace SuddanApplication.Application.IntegrationTests.TodoLists.Commands;
public class DeleteTodoListTests : BaseTestFixture
{
    [Test]
    public async Task ShouldRequireValidTodoListId()
    {
        var command = new DeleteTodoListCommand(99);
        await FluentActions.Invoking(() => SendAsync(command)).Should().ThrowAsync<NotFoundException>();
    }

    [Test]
    public async Task ShouldDeleteTodoList()
    {
        var listId = await SendAsync(new CreateTodoListCommand
        {
            Title = "New List"
        });

        await SendAsync(new DeleteTodoListCommand(listId));

        var list = await FindAsync<TodoList>(listId);

        list.Should().BeNull();
    }
}
