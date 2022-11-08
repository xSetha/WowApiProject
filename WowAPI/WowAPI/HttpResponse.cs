using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WowAPI
{
    public class HttpResponse
    {
        public HttpResponse()
        {
        }

        public HttpResponse(HttpStatusCode statusCode)
        {
            StatusCode = statusCode;
        }

        public HttpResponse(bool isrequestCancelled)
        {
            IsRequestCancelled = isrequestCancelled;
        }

        public bool IsRequestCancelled { get; protected set; } = false;

        public HttpStatusCode StatusCode { get; protected set; } = HttpStatusCode.BadRequest;
    }
}
