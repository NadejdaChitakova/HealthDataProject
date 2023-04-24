using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Up2TehnologyProject.ClientApi;
using Up2TehnologyProject.IRepository;

namespace Up2TehnologyProject.Repository
{
    public class HealthRepository : IHealthRepository
    {
        private readonly BaseApi _baseApi;
        public HealthRepository(BaseApi baseApi)
        {
            _baseApi = baseApi;
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

        private string GetEndpointUrl() => "https://feber.paxx.up2technology.com/health";
    }
}
