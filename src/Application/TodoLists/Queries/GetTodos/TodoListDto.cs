using SuddanApplication.Application.Common.Mappings;
using SuddanApplication.Domain.Entities;

namespace SuddanApplication.Application.TodoLists.Queries.GetTodos;
public class TodoListDto : IMapFrom<TodoList>
{
    public TodoListDto()
    {
        Items = new List<TodoItemDto>();
    }

    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Colour { get; set; }

    public IList<TodoItemDto> Items { get; set; }
}
