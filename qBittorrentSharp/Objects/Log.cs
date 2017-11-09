using qBittorrentSharp.Enums;
using qBittorrentSharp.JSON;
using System;

namespace qBittorrentSharp.Data
{
    public class Log
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime Timestamp { get; set; }
        public LogType Type { get; set; }

		internal Log(LogJSON l)
		{
			Id = l.id;
			Message = l.message;
			Timestamp = DateTimeOffset.FromUnixTimeSeconds(l.timestamp/1000).DateTime.ToLocalTime();
			Type = (LogType)l.type;
		}
    }
}
