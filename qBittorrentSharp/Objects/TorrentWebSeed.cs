using Newtonsoft.Json;
using System;

namespace qBittorrentSharp.JSON
{
    public class TorrentWebSeed
    {
        [JsonProperty("url")]
        public Uri Url { get; set; }
    }
}
