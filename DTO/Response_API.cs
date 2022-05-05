using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Response_API
    {
        public string statusDescription { get; set; } = "";
        public string statusCode { get; set; } = "";
        public string contentType { get; set; } = "";
        public string responseUri { get; set; } = "";
        public string responseFromServer { get; set; } = "";
        public string webException { get; set; } = "";
        public string exception { get; set; } = "";
        
    }
}
