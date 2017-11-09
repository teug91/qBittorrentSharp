using Newtonsoft.Json;
using qBittorrentSharp.Enums;

namespace qBittorrentSharp.JSON
{
    public class LogJSON
    {
        public int id { get; set; }
        public string message { get; set; }
        public long timestamp { get; set; }
        public int type { get; set; }
    }
}
