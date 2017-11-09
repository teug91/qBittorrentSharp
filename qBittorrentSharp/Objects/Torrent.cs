using qBittorrentSharp.Enums;
using qBittorrentSharp.JSON;
using System;

namespace qBittorrentSharp.Data
{
    public class Torrent
    {
		public DateTime Added_On { get; set; }
		public long Amount_Left { get; set; }
		public string Category { get; set; }
		public long Completed { get; set; }
		public long Completion_On { get; set; }
		public long Dl_Limit { get; set; }
		public long Dl_Speed { get; set; }
		public long Downloaded { get; set; }
		public long Downloaded_Session { get; set; }
		public TimeSpan Eta { get; set; }
		public bool First_Last_Piece_Prio { get; set; }
		public bool Force_Start { get; set; }
		public string Hash { get; set; }
		public DateTime Last_Activity { get; set; }
		public string Name { get; set; }
		public int Num_Complete { get; set; }
		public int Num_Incomplete { get; set; }
		public int Num_Leechs { get; set; }
		public int Num_Seeds { get; set; }
		public Priority Priority { get; set; }
		public float Progress { get; set; }
		public float Ratio { get; set; }
		public float Ratio_Limit { get; set; }
		public string Save_Path { get; set; }
		public DateTime Seen_Complete { get; set; }
		public bool Seq_Dl { get; set; }
		public long Size { get; set; }
		public TorrentState State { get; set; }
		public bool Super_Seeding { get; set; }
		public long Total_Size { get; set; }
		public Uri Tracker { get; set; }
		public long Up_Limit { get; set; }
		public long Uploaded { get; set; }
		public long Uploaded_Session { get; set; }
		public long Up_Speed { get; set; }

		public Torrent() { }

		internal Torrent(TorrentJSON t)
		{
			Added_On = DateTimeOffset.FromUnixTimeSeconds(t.added_on).DateTime.ToLocalTime();
			Amount_Left = t.amount_left;
			Category = t.category;
			Completed = t.completed;
			Completion_On = t.completion_on;
			Dl_Limit = t.dlspeed;
			Dl_Speed = t.dl_limit;
			Downloaded = t.downloaded;
			Downloaded_Session = t.downloaded_session;
			Eta = TimeSpan.FromSeconds(t.eta);
			First_Last_Piece_Prio = t.f_l_piece_prio;
			Force_Start = t.force_start;
			Hash = t.hash;
			Last_Activity = DateTimeOffset.FromUnixTimeSeconds(t.last_activity).DateTime.ToLocalTime();
			Name = t.name;
			Num_Complete = t.num_complete;
			Num_Incomplete = t.num_incomplete;
			Num_Leechs = t.num_leechs;
			Num_Seeds = t.num_seeds;
			Priority = (Priority)t.priority;
			Progress = t.progress;
			Ratio = t.ratio;
			Ratio_Limit = t.ratio_limit;
			Save_Path = t.save_path;
			Seen_Complete = DateTimeOffset.FromUnixTimeSeconds(t.seen_complete).DateTime.ToLocalTime();
			Seq_Dl = t.seq_dl;
			Size = t.size;
			State = (TorrentState)Enum.Parse(typeof(TorrentState), t.state, true);
			Super_Seeding = t.super_seeding;
			Total_Size = t.total_size;
			if(t.tracker != "")
				Tracker = new Uri(t.tracker);
			Up_Limit = t.up_limit;
			Uploaded = t.uploaded;
			Uploaded_Session = t.uploaded_session;
			Up_Speed = t.upspeed;
	}
	}
}
