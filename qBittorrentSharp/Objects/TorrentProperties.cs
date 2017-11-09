using Newtonsoft.Json;

namespace qBittorrentSharp.JSON
{
    public class TorrentProperties
    {
        [JsonProperty("save_path")]
        public string Save_path { get; set; }

        [JsonProperty("creation_date")]
        public int Creation_date { get; set; }

        [JsonProperty("piece_size")]
        public int Piece_size { get; set; }

        [JsonProperty("comment")]
        public string Comment { get; set; }

        [JsonProperty("total_wasted")]
        public long Total_wasted { get; set; }

        [JsonProperty("total_uploaded")]
        public long Total_uploaded { get; set; }

        [JsonProperty("total_uploaded_session")]
        public long Total_uploaded_session { get; set; }

        [JsonProperty("total_downloaded")]
        public long Total_downloaded { get; set; }

        [JsonProperty("total_downloaded_session")]
        public long Total_downloaded_session { get; set; }

        [JsonProperty("up_limit")]
        public long Up_limit { get; set; }

        [JsonProperty("dl_limit")]
        public long Dl_limit { get; set; }

        [JsonProperty("time_elapsed")]
        public long Time_elapsed { get; set; }

        [JsonProperty("seeding_time")]
        public long Seeding_time { get; set; }

        [JsonProperty("nb_connections")]
        public int Nb_connections { get; set; }

        [JsonProperty("nb_connections_limit")]
        public int Nb_connections_limit { get; set; }

        [JsonProperty("share_ratio")]
        public float Share_ratio { get; set; }

        [JsonProperty("addition_date")]
        public int Addition_date { get; set; }

        [JsonProperty("completion_date")]
        public int Completion_date { get; set; }

        [JsonProperty("created_by")]
        public string Created_by { get; set; }

        [JsonProperty("dl_speed_avg")]
        public long Dl_speed_avg { get; set; }

        [JsonProperty("dl_speed")]
        public long Dl_speed { get; set; }

        [JsonProperty("eta")]
        public long Eta { get; set; }

        [JsonProperty("last_seen")]
        public int Last_seen { get; set; }

        [JsonProperty("peers")]
        public int Peers { get; set; }

        [JsonProperty("peers_total")]
        public int Peers_total { get; set; }

        [JsonProperty("pieces_have")]
        public int Pieces_have { get; set; }

        [JsonProperty("pieces_num")]
        public int Pieces_num { get; set; }

        [JsonProperty("reannounce")]
        public int Reannounce { get; set; }

        [JsonProperty("seeds")]
        public int Seeds { get; set; }

        [JsonProperty("seeds_total")]
        public int Seeds_total { get; set; }

        [JsonProperty("total_size")]
        public long Total_size { get; set; }

        [JsonProperty("up_speed_avg")]
        public long Up_speed_avg { get; set; }

        [JsonProperty("up_speed")]
        public long Up_speed { get; set; }
    }
}
