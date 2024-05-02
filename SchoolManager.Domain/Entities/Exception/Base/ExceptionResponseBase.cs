using System.Net;

namespace SchoolManager.Domain.Entities.Exception.Base
{
    public class ExceptionResponseBase
    {
        public ExceptionResponseBase()
        {
            
        }
        public ExceptionResponseBase(HttpStatusCode statusCode, string statusDescription)
        {
            this.StatusCode = (int)statusCode;
            this.StatusDescription = statusDescription;
        }
        public int StatusCode { get; set; }
        public string StatusDescription { get; set; }
    }
}
