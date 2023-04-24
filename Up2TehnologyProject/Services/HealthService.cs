using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Up2TehnologyProject.IRepository;
using Up2TehnologyProject.IServices;

namespace Up2TehnologyProject.Services
{
    public class HealthService : IHealthService
    {
        private readonly IHealthRepository _healthRepository;
        private readonly string KEY_FILTER_NAME = "adapter";
        private readonly string ENTRIES_KEY_NAME = "entries";

        public HealthService(IHealthRepository healthRepository)
        {
            _healthRepository = healthRepository;
        }

        public Object GetHealthJsonData()
        {
            var data = _healthRepository.FetchDataFromEndpointAsync();

            var adapterData = ExtractAdapterDataRelated(data);

            return adapterData;
        }

        public Object GetHealthXmlData()
        {
            var data = _healthRepository.FetchDataFromEndpointAsync();

            var adapterData = ExtractAdapterDataRelated(data);

            return ConverToXml(adapterData?.Result);
        }

        private async Task<string> ExtractAdapterDataRelated(Task<HttpResponseMessage>? response)
        {
            string content = await response.Result.Content.ReadAsStringAsync();
            JObject json = JObject.Parse(content);

            if (json == null)
            {
                throw new ArgumentException("The response cannot be parsed to json.");
            }

            var entries = json.Value<JObject>(ENTRIES_KEY_NAME).Properties();

            var entriesDict = entries
                .Where(x => x.Name.ToLower().Contains(KEY_FILTER_NAME))
                .ToDictionary(
                    k => k.Name,
                    v => v.Value);


            string result = JsonConvert.SerializeObject(entriesDict);

            return result;
        }

        private Object? ConverToXml(string serializedObject)
        {
            return JsonConvert.DeserializeXmlNode(serializedObject, "root").OuterXml;
        }
    }
}
