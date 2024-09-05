using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Model
{
    public class ServiceResponse<T> : ServiceResponse
    {
        public T? Data { get; set; }
    }


    public class ServiceResponse
    {
        public ResultState State { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
