namespace WebApi
{
    using System;
    using System.IO;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web.Cors;
    using System.Web.Hosting;
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
                AllowAnyMethod = true,
            };
        }

        Task<CorsPolicy> ICorsPolicyProvider.GetCorsPolicyAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            string root = HostingEnvironment.ApplicationPhysicalPath;
            string filename = Path.Combine(root, "origins.txt");

            string origins = File.ReadAllText(filename);

            if (!string.IsNullOrWhiteSpace(origins))
            {
                _policy.Origins.Clear();

                foreach (string origin in origins.Split(','))
                {
                    _policy.Origins.Add(origin);
                }
            }
            return Task.FromResult(_policy);
        }
    }
}