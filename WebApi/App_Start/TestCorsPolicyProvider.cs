namespace WebApi
{
    using System;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web.Cors;
    using System.Web.Http.Cors;

    public class TestCorsPolicyProvider : Attribute, ICorsPolicyProvider
    {
        private CorsPolicy _policy;

        /// <summary>Initializes a new instance of the <see cref="T:System.Attribute" /> class.</summary>
        public TestCorsPolicyProvider()
        {
            _policy = new CorsPolicy
            {
                AllowAnyHeader = true,
            };
        }

        Task<CorsPolicy> ICorsPolicyProvider.GetCorsPolicyAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            _policy.Methods.Clear();
            _policy.Methods.Add("get");
            _policy.Methods.Add("post");
            _policy.Methods.Add("put");

            _policy.Origins.Clear();
            _policy.Origins.Add("http://localhost:3017");

            return Task.FromResult(_policy);
        }
    }
}