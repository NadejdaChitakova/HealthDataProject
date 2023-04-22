namespace Up2TehnologyProject.ClientApi
{
    public class BaseApi
    {
        private readonly HttpClient _httpClient;

        public BaseApi(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> SendRequest(HttpMethod httpMethod, string url)
        {
            Uri requestUri = new Uri(url);
            return await SendRequest(httpMethod, url);
        }
    }
}
