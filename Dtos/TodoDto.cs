using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos
{
    public class TodoDto
    {
        public int Id { get; set; }
        public string Title { get; set; }=string.Empty;
        public string Description { get; set; }=string.Empty;
        public DateTime DateTime { get; set; } = DateTime.Now;
        public bool Completed { get; set; }=false;
    }
}