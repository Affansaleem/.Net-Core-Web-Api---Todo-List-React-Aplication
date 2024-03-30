using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos
{
    public class UpdateRequestDto
    {
        public string Title { get; set; }=string.Empty;
        public string Description { get; set; }=string.Empty;
        public bool Completed { get; set; }=false;
    }
}