using Up2TehnologyProject.IRepository;

namespace Up2TehnologyProject.Repository
{
    public class HealthRepository : IHealthRepository
    {
        public void FetchDataFromEndpoint()
        {
            throw new NotImplementedException();
        }

        private string GetEndpointUrl() => "https://feber.paxx.up2technology.com/health";
    }
}
