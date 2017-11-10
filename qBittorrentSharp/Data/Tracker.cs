using qBittorrentSharp.JSON;
using qBittorrentSharp.Enums;
using System;
using System.Text.RegularExpressions;

namespace qBittorrentSharp.Data
{
    public class Tracker
    {
        public Uri Url { get; set; }
        public Trackerstatus Status { get; set; }
        public int Num_Peers { get; set; }
        public string Msg { get; set; }

		public Tracker() { }

		internal Tracker(TrackerJSON t)
		{
			Url = t.Url;
			Status = (Trackerstatus)Enum.Parse(typeof(Trackerstatus), new Regex(@"\s|[.]").Replace(t.Status, ""), true);
			Num_Peers = t.Num_Peers;
			Msg = t.Msg;
		}
	}
}
