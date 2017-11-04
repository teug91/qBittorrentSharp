using Newtonsoft.Json;
using qBittorrentSharp.Enums;

namespace qBittorrentSharp.JSON
{
    public class TransferInfo
    {
        [JsonProperty("dl_info_speed")]
        public int Dl_info_speed { get; set; }

        [JsonProperty("dl_info_data")]
        public long Dl_info_data { get; set; }

        [JsonProperty("up_info_speed")]
        public int Up_info_speed { get; set; }

        [JsonProperty("up_info_data")]
        public long Up_info_data { get; set; }

        [JsonProperty("dl_rate_limit")]
        public int Dl_rate_limit { get; set; }

        [JsonProperty("up_rate_limit")]
        public int Up_rate_limit { get; set; }

        [JsonProperty("dht_nodes")]
        public int Dht_nodes { get; set; }

        [JsonProperty("connection_status")]
        public ConnectionStatus Connection_status { get; set; }

        [JsonProperty("queueing")]
        public bool Queueing { get; set; }

        [JsonProperty("use_alt_speed_limits")]
        public bool Use_alt_speed_limits { get; set; }

        [JsonProperty("refresh_interval")]
        public int Refresh_interval { get; set; }
    }
}
