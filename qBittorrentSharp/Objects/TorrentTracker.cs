using Newtonsoft.Json;
using System;

namespace qBittorrentSharp.JSON
{
    public class TorrentTracker
    {
        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("num_peers")]
        public int Num_peers { get; set; }

        [JsonProperty("msg")]
        public string Msg { get; set; }
    }
}
