using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROAGRO.Modelos.FrontModels
{
    public class Response
    {
        public Response()
        {
            this.Value = new { };
            this.Message = String.Empty;
        }
        public int Code { get; set; }
        public object Value { get; set; }
        public string Message { get; set; }
    }
}
