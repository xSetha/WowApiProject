using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace WowAPI
{
    public class HttpDataResponse<T> : HttpResponse
    {
        public HttpDataResponse(T? data, HttpStatusCode statusCode)
        {
            Data = data;
            StatusCode = statusCode;
        }

        public HttpDataResponse()
        {
        }

        public HttpDataResponse(T? data)
        {
            Data = data;
        }

        public HttpDataResponse(HttpStatusCode statusCode)
        {
            StatusCode = statusCode;
        }

        public HttpDataResponse(bool isRequestCancelled) : base(isRequestCancelled) { }

        public T? Data { get; }
    }

}
