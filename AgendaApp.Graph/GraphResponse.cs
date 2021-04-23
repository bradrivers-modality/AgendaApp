using Newtonsoft.Json;
using System.ComponentModel;

namespace AgendaApp.Graph
{
    public class GraphResponse<TEntity>
    {
        [JsonProperty("@odata.nextLink")]
        [DefaultValue("")]
        public string NextLink { get; set; }
        
        [JsonProperty("value")]
        public TEntity[] Entities { get; set; }
    }
}