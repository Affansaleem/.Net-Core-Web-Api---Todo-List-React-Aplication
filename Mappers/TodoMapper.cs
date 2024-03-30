using api.Dtos;
using api.Models;

namespace api.Mappers
{
    public static class TodoMapper
    {
        public static TodoDto ToTodoDto(this Todos todos)
        {
            return new TodoDto
            {
                Id=todos.Id,
                Completed=todos.Completed,
                DateTime=todos.DateTime,
                Description=todos.Description,
                Title=todos.Title
            };
        }
        public static Todos ToTodoFromDto(this CreateTodoRequestDto createTodoRequestDto)
        {
            return new Todos
            {
                Title=createTodoRequestDto.Title,
                Description=createTodoRequestDto.Description,
                Completed=false,
                DateTime=DateTime.Now
            };
        }
    }
}