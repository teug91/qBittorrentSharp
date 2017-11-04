using Newtonsoft.Json;
using qBittorrentSharp.Enums;

namespace qBittorrentSharp.JSON
{
    public class TorrentInfo
    {
        [JsonProperty("hash")]
        public string Hash { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("size")]
        public long Size { get; set; }

        [JsonProperty("progress")]
        public float Progress { get; set; }

        [JsonProperty("dlspeed")]
        public int Dlspeed { get; set; }

        [JsonProperty("upspeed")]
        public int Upspeed { get; set; }

        [JsonProperty("priority")]
        public int Priority { get; set; }

        [JsonProperty("num_seeds")]
        public int Num_seeds { get; set; }

        [JsonProperty("num_complete")]
        public int Num_complete { get; set; }

        [JsonProperty("num_leechs")]
        public int Num_leechs { get; set; }

        [JsonProperty("num_incomplete")]
        public int Num_incomplete { get; set; }

        [JsonProperty("ratio")]
        public float Ratio { get; set; }

        [JsonProperty("eta")]
        public long Eta { get; set; }

        [JsonProperty("state")]
        public States State { get; set; }

        [JsonProperty("seq_dl")]
        public bool Seq_dl { get; set; }

        [JsonProperty("f_l_piece_prio")]
        public bool F_l_piece_prio { get; set; }

        [JsonProperty("category", NullValueHandling = NullValueHandling.Ignore)]
        public int Category { get; set; }

        [JsonProperty("super_seeding")]
        public bool Super_seeding { get; set; }

        [JsonProperty("force_start")]
        public bool Force_start { get; set; }
    }
}
