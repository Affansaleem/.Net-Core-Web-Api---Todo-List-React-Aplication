using api.Dtos;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private ITodoRepository _todoRepository;
        public TodosController(ITodoRepository todoRepository)
        {
            _todoRepository=todoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var todos= await _todoRepository.GetAllAsync();
            if(todos == null)
            {
                return BadRequest("No Todo found");
            }
            var todoDto=todos.Select(s=>s.ToTodoDto());
            return Ok(todoDto);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var todos= await _todoRepository.GetByIdAsync(id);
            if(todos==null)
            {
                return NotFound();
            }
            return Ok(todos.ToTodoDto());

        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTodoRequestDto createTodoRequestDto)
        {
            var todo= createTodoRequestDto.ToTodoFromDto();
            var todoDto= await _todoRepository.CreateAsync(todo);
            return CreatedAtAction(nameof(GetById),new {id=todoDto.Id},todoDto.ToTodoDto());
            
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var todos= await _todoRepository.DeleteAsync(id);
            if(todos==null)
            {
                return NotFound();
            }
            return Ok(todos.ToTodoDto());
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateRequestDto updateRequestDto)
        {
            var todo = await _todoRepository.UpdateAsync(id, updateRequestDto);
            if(todo == null)
            {
                return NotFound();
            }
            return Ok(todo.ToTodoDto());
        }
    }
}