using qBittorrentSharp.Enums;
using qBittorrentSharp.JSON;
using System;

namespace qBittorrentSharp.Data
{
    public class TorrentContents
    {
        public string Name { get; set; }
        public long Size { get; set; }
        public float Progress { get; set; }
        public Priority Priority { get; set; }
        public bool Is_Seed { get; set; }
        public int[] Piece_Range { get; set; }

		public TorrentContents() { }
	}
}
