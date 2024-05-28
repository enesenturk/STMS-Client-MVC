using System.Net;

namespace NS.STMS.CORE.Helpers.RestfulServiceHelpers.Models
{
    public class RestfulServiceResponseDto
    {

        public string Response { get; set; }
        public HttpStatusCode StatusCode { get; set; }

    }
}
