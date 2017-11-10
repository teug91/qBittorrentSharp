using qBittorrentSharp.Enums;
using qBittorrentSharp.JSON;
using System;

namespace qBittorrentSharp.Data
{
    public class TransferInfo
    {
		public long Dl_Info_Speed { get; set; }
		public long Dl_Info_Data { get; set; }
		public long Up_Info_Speed { get; set; }
		public long Up_Info_Data { get; set; }
		public long Dl_Rate_Limit { get; set; }
		public long Up_Rate_Limit { get; set; }
		public int Dht_Nodes { get; set; }
		public ConnectionStatus Connection_Status { get; set; }
		public bool Queueing { get; set; }
		public bool Use_Alt_Speed_Limits { get; set; }
		public int Refresh_Interval { get; set; }

		public TransferInfo() { }

		internal TransferInfo(TransferInfoJSON t)
		{
			Dl_Info_Speed = t.dl_info_speed;
			Dl_Info_Data = t.dl_info_data;
			Up_Info_Speed = t.up_info_speed;
			Up_Info_Data = t.up_info_data;
			Dl_Rate_Limit = t.dl_rate_limit;
			Up_Rate_Limit = t.up_rate_limit;
			Dht_Nodes = t.dht_nodes;
			Connection_Status = (ConnectionStatus)Enum.Parse(typeof(ConnectionStatus), t.connection_status, true);
			Queueing = t.queueing;
			Use_Alt_Speed_Limits = t.use_alt_speed_limits;
			Refresh_Interval = t.refresh_interval;
		}
	}
}
