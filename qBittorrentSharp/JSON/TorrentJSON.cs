using Newtonsoft.Json;
using qBittorrentSharp.Enums;

namespace qBittorrentSharp.JSON
{
	internal class TorrentJSON
	{
		internal int added_on { get; set; }
		internal long amount_left { get; set; }
		internal string category { get; set; }
		internal long completed { get; set; }
		internal long completion_on { get; set; }
		internal long dl_limit { get; set; }
		internal long dlspeed { get; set; }
		internal long downloaded { get; set; }
		internal long downloaded_session { get; set; }
		internal long eta { get; set; }
		internal bool f_l_piece_prio { get; set; }
		internal bool force_start { get; set; }
		internal string hash { get; set; }
		internal int last_activity { get; set; }
		internal string name { get; set; }
		internal int num_complete { get; set; }
		internal int num_incomplete { get; set; }
		internal int num_leechs { get; set; }
		internal int num_seeds { get; set; }
		internal int priority { get; set; }
		internal float progress { get; set; }
		internal float ratio { get; set; }
		internal float ratio_limit { get; set; }
		internal string save_path { get; set; }
		internal long seen_complete { get; set; }
		internal bool seq_dl { get; set; }
		internal long size { get; set; }
		internal string state { get; set; }
		internal bool super_seeding { get; set; }
		internal long total_size { get; set; }
		internal string tracker { get; set; }
		internal long up_limit { get; set; }
		internal long uploaded { get; set; }
		internal long uploaded_session { get; set; }
		internal long upspeed { get; set; }
	}
}
