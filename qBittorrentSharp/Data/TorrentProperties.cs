using qBittorrentSharp.JSON;
using System;

namespace qBittorrentSharp.Data
{
    public class TorrentProperties
    {
		public string Save_Path { get; set; }
		public DateTime Creation_Date { get; set; }
		public long Piece_Size { get; set; }
		public string Comment { get; set; }
		public long Total_Wasted { get; set; }
		public long Total_Uploaded { get; set; }
		public long Total_Uploaded_Session { get; set; }
		public long Total_Downloaded { get; set; }
		public long Total_Downloaded_Session { get; set; }
		public long Up_Limit { get; set; }
		public long Dl_Limit { get; set; }
		public TimeSpan Time_Elapsed { get; set; }
		public TimeSpan Seeding_Time { get; set; }
		public int Nb_Connections { get; set; }
		public int Nb_Connections_Limit { get; set; }
		public float Share_Ratio { get; set; }
		public DateTime Addition_Date { get; set; }
		public DateTime Completion_Date { get; set; }
		public string Created_By { get; set; }
		public long Dl_Speed_Avg { get; set; }
		public long Dl_Speed { get; set; }
		public TimeSpan Eta { get; set; }
		public DateTime Last_Seen { get; set; }
		public int Peers { get; set; }
		public int Peers_Total { get; set; }
		public int Pieces_Have { get; set; }
		public int Pieces_Num { get; set; }
		public TimeSpan Reannounce { get; set; }
		public int Seeds { get; set; }
		public int Seeds_Total { get; set; }
		public long Total_Size { get; set; }
		public long Up_Speed_Avg { get; set; }
		public long Up_Speed { get; set; }

		public TorrentProperties() { }

		internal TorrentProperties(TorrentPropertiesJSON t)
		{
			Save_Path = t.Save_Path;
			Creation_Date = DateTimeOffset.FromUnixTimeSeconds(t.Creation_Date).DateTime.ToLocalTime();
			Piece_Size = t.Piece_Size;
			Comment = t.Comment;
			Total_Wasted = t.Total_Wasted;
			Total_Uploaded = t.Total_Uploaded;
			Total_Uploaded_Session = t.Total_Uploaded_Session;
			Total_Downloaded = t.Total_Downloaded;
			Total_Downloaded_Session = t.Total_Downloaded_Session;
			Up_Limit = t.Up_Limit;
			Dl_Limit = t.Dl_Limit;
			Time_Elapsed = TimeSpan.FromSeconds(t.Time_Elapsed);
			Seeding_Time = TimeSpan.FromSeconds(t.Seeding_Time);
			Nb_Connections = Nb_Connections;
			Nb_Connections_Limit = Nb_Connections_Limit;
			Share_Ratio = Share_Ratio;
			Addition_Date = DateTimeOffset.FromUnixTimeSeconds(t.Addition_Date).DateTime.ToLocalTime();
			Completion_Date = DateTimeOffset.FromUnixTimeSeconds(t.Completion_Date).DateTime.ToLocalTime();
			Created_By = Created_By;
			Dl_Speed_Avg = Dl_Speed_Avg;
			Dl_Speed = Dl_Speed;
			Eta = TimeSpan.FromSeconds(t.Eta);
			Last_Seen = DateTimeOffset.FromUnixTimeSeconds(t.Last_Seen).DateTime.ToLocalTime();
			Peers = Peers;
			Peers_Total = Peers_Total;
			Pieces_Have = Pieces_Have;
			Pieces_Num = Pieces_Num;
			Reannounce = TimeSpan.FromSeconds(t.Reannounce);
			Seeds = Seeds;
			Seeds_Total = Seeds_Total;
			Total_Size = Total_Size;
			Up_Speed_Avg = Up_Speed_Avg;
			Up_Speed = Up_Speed;
		}
	}
}
