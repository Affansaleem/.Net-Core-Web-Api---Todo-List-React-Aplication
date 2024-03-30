using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos;
using api.Models;

namespace api.Interfaces
{
    public interface ITodoRepository
    {
        Task<List<Todos>> GetAllAsync();
        Task<Todos?> GetByIdAsync(int id);
        Task<Todos> CreateAsync(Todos todo);
        Task<Todos?> DeleteAsync(int id);
        Task<Todos?> UpdateAsync(int id, UpdateRequestDto updateRequestDto);
    }
}