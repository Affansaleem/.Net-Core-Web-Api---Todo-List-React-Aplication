using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class TodoRepository : ITodoRepository
    {
        private readonly TodosDbContext _context;
        public TodoRepository(TodosDbContext context)
        {
            _context=context;
        }

        public async Task<Todos> CreateAsync(Todos todo)
        {
            var newtodo=await _context.Todos.AddAsync(todo);
            await _context.SaveChangesAsync();
            return todo;
        }

        public async Task<Todos?> DeleteAsync(int id)
        {
            var todo= await _context.Todos.FirstOrDefaultAsync(x=>x.Id == id);
            if(todo == null)
            {
                return null;
            }
            _context.Todos.Remove(todo);
            await _context.SaveChangesAsync();
            return todo;
        }

        public async Task<List<Todos>> GetAllAsync()
        {
            var todos= await _context.Todos.ToListAsync();
            return todos;
        }

        public async Task<Todos> GetByIdAsync(int id)
        {
            var todo= await _context.Todos.FirstOrDefaultAsync(x=>x.Id == id);
            if(todo == null)
            {
                return null;
            }
            return todo;
        }

        public async Task<Todos?> UpdateAsync(int id, UpdateRequestDto updateRequestDto)
        {
            var todo = await _context.Todos.FirstOrDefaultAsync(x=>x.Id==id);
            if(todo == null)
            {
                return null;
            }
            todo.Completed= updateRequestDto.Completed;
            todo.Description=updateRequestDto.Description;
            todo.Title=updateRequestDto.Title;
            await _context.SaveChangesAsync();
            return todo;
        }
    }
}