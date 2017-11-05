using Newtonsoft.Json;
using qBittorrentSharp.Enums;

namespace qBittorrentSharp.JSON
{
    public class TorrentContents
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("size")]
        public long Size { get; set; }

        [JsonProperty("progress")]
        public float Progress { get; set; }

        [JsonProperty("priority")]
        public Priority Priority { get; set; }

        [JsonProperty("is_seed")]
        public bool Is_seed { get; set; }

        [JsonProperty("piece_range")]
        public int[] Piece_range { get; set; }
    }
}
