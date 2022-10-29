using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebProjectV1.Dto
{
    public class ResponseDto
    {
        public object? Result { get; set; }
        public bool Success { get; set; } = true;
        public string Message { get; set; } = string.Empty;
        public List<string>? ErrorMessages { get; set; }
    }
}