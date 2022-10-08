using FluentAssertions;
using NUnit.Framework;
using SuddanApplication.Application.Common.Exceptions;
using SuddanApplication.Application.TodoItems.Commands.CreateTodoItem;
using SuddanApplication.Application.TodoItems.Commands.DeleteTodoItem;
using SuddanApplication.Application.TodoLists.Commands.CreateTodoList;
using SuddanApplication.Domain.Entities;

using static SuddanApplication.Application.IntegrationTests.Testing;

namespace SuddanApplication.Application.IntegrationTests.TodoItems.Commands;
public class DeleteTodoItemTests : BaseTestFixture
{
    [Test]
    public async Task ShouldRequireValidTodoItemId()
    {
        var command = new DeleteTodoItemCommand(99);

        await FluentActions.Invoking(() =>
            SendAsync(command)).Should().ThrowAsync<NotFoundException>();
    }

    [Test]
    public async Task ShouldDeleteTodoItem()
    {
        var listId = await SendAsync(new CreateTodoListCommand
        {
            Title = "New List"
        });

        var itemId = await SendAsync(new CreateTodoItemCommand
        {
            ListId = listId,
            Title = "New Item"
        });

        await SendAsync(new DeleteTodoItemCommand(itemId));

        var item = await FindAsync<TodoItem>(itemId);

        item.Should().BeNull();
    }
}
