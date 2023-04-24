using Up2TehnologyProject.ClientApi;
using Up2TehnologyProject.IRepository;

namespace Up2TehnologyProject.Repository
{
    public class HealthRepository : IHealthRepository
    {
        private readonly BaseApi _baseApi;
        private IConfiguration _configuration;

        public HealthRepository(BaseApi baseApi, IConfiguration configuration)
        {
            _baseApi = baseApi;
            _configuration = configuration;
        }

        public Task<HttpResponseMessage> FetchDataFromEndpointAsync()
        {
            var response = _baseApi.SendRequest(HttpMethod.Get, GetEndpointUrl());

            if (!response.IsCompletedSuccessfully)
            {
                throw new ArgumentException("The server response is not compled successfully.");
            }

            return response;
        }

        private string GetEndpointUrl()
        {
            string url = _configuration.GetValue<string>("HealthCheckUrl");
            return url;
        }
    }
}
