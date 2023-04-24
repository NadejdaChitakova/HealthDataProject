namespace Up2TehnologyProject.IRepository
{
    public interface IHealthRepository
    {
        public Task<HttpResponseMessage> FetchDataFromEndpointAsync();
    }
}
