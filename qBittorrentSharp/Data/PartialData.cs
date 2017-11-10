using qBittorrentSharp.JSON;
using System.Collections.Generic;

namespace qBittorrentSharp.Data
{
    public class PartialData
    {
		public int Rid { get; set; }
		public bool Full_Update { get; set; }
		public List<Torrent> Torrents { get; set; }
		public List<string> Torrents_Removed { get; set; }
		public List<string> Categories { get; set; }
		public List<string> Categories_Removed { get; set; }
		public TransferInfo Server_State { get; set; }

		public PartialData() { }

		internal PartialData(PartialDataJSON p)
		{
			Rid = p.rid;
			Full_Update = p.full_update;
			Torrents = new List<Torrent>();
			foreach(var e in p.torrents)
			{
				e.Value.hash = e.Key;
				Torrents.Add(new Torrent(e.Value));
			}
			if (p.torrents_removed != null)
				Torrents_Removed = new List<string>(p.torrents_removed);
			else
				Torrents_Removed = new List<string>();
			if (p.categories != null)
				Categories = new List<string>(p.categories);
			else
				Categories = new List<string>();
			if (p.categories_removed != null)
				Categories_Removed = new List<string>(p.categories_removed);
			else
				Categories_Removed = new List<string>();
			Server_State = new TransferInfo(p.server_state);
		}
	}
}
