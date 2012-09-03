using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;

namespace Bekk.dotnetintro.WebApi.Console
{
    public class WebApiAdapter
    {
        private readonly string _url;

        public WebApiAdapter(string url)
        {
            _url = url;
        }

        public IEnumerable<BlogEntry> Get()
        {
            var result = new HttpClient().GetAsync(_url).Result;
            return JsonConvert.DeserializeObject<IEnumerable<BlogEntry>>(result.Content.ReadAsStringAsync().Result);
        }
    }

    public class BlogEntry
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
