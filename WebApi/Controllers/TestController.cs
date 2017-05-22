namespace WebApi.Controllers
{
    using System.Net.Http;
    using System.Web.Http;
    using System.Web.Http.Cors;

    //[EnableCors(origins: "http://localhost:3017", headers:"*", methods:"*")]
    public class TestController : ApiController
    {
        //[EnableCors(origins: "http://localhost:3017", headers: "*", methods: "GET")]
        public HttpResponseMessage Get()
        {
            return new HttpResponseMessage()
            {
                Content = new StringContent("GET: Test message")
            };
        }

        public HttpResponseMessage Post()
        {
            return new HttpResponseMessage()
            {
                Content = new StringContent("POST: Test message")
            };
        }

        public HttpResponseMessage Put()
        {
            return new HttpResponseMessage()
            {
                Content = new StringContent("PUT: Test message")
            };
        }
    }
}
