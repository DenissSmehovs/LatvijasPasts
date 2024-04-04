using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LatvijasPasts.UseCases.Models
{
    public class ServiceResult
    {
        public object ResultObject { get; set; }
        public HttpStatusCode Status { get; set; }
    }
}
