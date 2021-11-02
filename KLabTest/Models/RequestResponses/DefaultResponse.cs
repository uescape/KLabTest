using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KLabTest.Models.RequestResponses
{
    public class DefaultResponse<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; }
    }
}
