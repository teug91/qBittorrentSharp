using Newtonsoft.Json;
using qBittorrentSharp.Enums;
using System.Collections.Generic;

namespace qBittorrentSharp.JSON
{
    public class PartialData
    {
        [JsonProperty("rid")]
        public int Rid { get; set; }

        [JsonProperty("full_update")]
        public string Full_update { get; set; }

        [JsonProperty("torrents")]
        public object Torrents { get; set; }

        [JsonProperty("torrents_removed")]
        public string[] Torrents_removed { get; set; }

        [JsonProperty("categories")]
        public string[] Categories { get; set; }

        [JsonProperty("categories_removed")]
        public string[] Categories_removed { get; set; }

        [JsonProperty("server_state")]
        public TransferInfo TransferInfo { get; set; }
    }
}
