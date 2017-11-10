using Newtonsoft.Json;
using System;

namespace qBittorrentSharp.JSON
{
    public class TrackerJSON
    {
        public Uri Url { get; set; }
        public string Status { get; set; }
        public int Num_Peers { get; set; }
        public string Msg { get; set; }
    }
}
