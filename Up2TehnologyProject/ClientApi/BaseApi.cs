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
            var httpRequestMsg = new HttpRequestMessage(httpMethod, requestUri);

            return _httpClient.Send(httpRequestMsg);
        }
    }
}
