using System;
using System.Collections.Generic;
using System.Text;
using qBittorrentSharp.Enums;
using System.Net.Mail;

namespace qBittorrentSharp.Data
{

	public class Preferences
	{
		public List<Uri> Add_Trackers { get; set; } // ---------------------------
		public bool? Add_Trackers_Enabled { get; set; }
		public long? Alt_Dl_Limit { get; set; }
		public long? Alt_Up_Limit { get; set; }
		public bool? Anonymous_Mode { get; set; }
		public bool? Autorun_Enabled { get; set; }
		public string Autorun_Program { get; set; }
		public bool? Bypass_Local_Auth { get; set; }
		public bool? Dht { get; set; }
		public long? Dl_Limit { get; set; }
		public bool? Dont_Count_Slow_Torrents { get; set; }
		public string Dyndns_Domain { get; set; }
		public bool? Dyndns_Enabled { get; set; }
		public string Dyndns_Password { get; set; }
		public DynDnsService? Dyndns_Service { get; set; } // ---------------------------
		public string Dyndns_Username { get; set; }
		public bool? Enable_Utp { get; set; }
		public Encryption? Encryption { get; set; } // ---------------------------
		public string Export_Dir { get; set; }
		public string Export_Dir_Fin { get; set; }
		public bool? Force_Proxy { get; set; }
		public bool? Incomplete_Files_Ext { get; set; }
		public bool? Ip_Filter_Enabled { get; set; }
		public string Ip_Filter_Path { get; set; }
		public bool? Tp_Filter_Trackers { get; set; }
		public bool? Limit_Tcp_Overhead { get; set; }
		public bool? Limit_Utp_Rate { get; set; }
		public int? Listen_Port { get; set; }
		public Locale? Locale { get; set; } // ---------------------------
		public bool? Lsd { get; set; }
		public bool? Mail_Notification_Auth_Enabled { get; set; }
		public MailAddress Mail_Notification_Email { get; set; } // ---------------------------
		public bool? Mail_Notification_Enabled { get; set; }
		public string Mail_Notification_Password { get; set; }
		public string Mail_Notification_Smtp { get; set; }
		public bool? Mail_Notification_Ssl_Enabled { get; set; }
		public string Mail_Notification_Username { get; set; }
		public int? Max_Active_Downloads { get; set; }
		public int? Max_Active_Torrents { get; set; }
		public int? Max_Active_Uploads { get; set; }
		public int? Max_Connec { get; set; }
		public int? Max_Connec_Per_Torrent { get; set; }
		public float? Max_Ratio { get; set; }
		public MaxRatioAction? Max_Ratio_Action { get; set; } // ---------------------------
		public bool? Max_Ratio_Enabled { get; set; }
		public int? Max_Uploads { get; set; }
		public int? Max_Uploads_Per_Torrent { get; set; }
		public bool? Pex { get; set; }
		public bool? Preallocate_All { get; set; }
		public bool? Proxy_Auth_Enabled { get; set; }
		public string Proxy_Ip { get; set; }
		public string Proxy_Password { get; set; }
		public bool? Proxy_Peer_Connections { get; set; }
		public int? Proxy_Port { get; set; }
		public ProxyType? proxy_type { get; set; } // ---------------------------
		public string Proxy_Username { get; set; }
		public bool? Queueing_Enabled { get; set; }
		public bool? Random_Port { get; set; }
		public string Save_Path { get; set; }
		public Dictionary<string, bool> Scan_Dirs { get; set; } // ---------------------------
		public TimeSpan? Schedule_From { get; set; } // ---------------------------
		public TimeSpan? Schedule_To { get; set; } // ---------------------------
		public SchedulerDay? Scheduler_Days { get; set; } // ---------------------------
		public bool? Scheduler_Enabled { get; set; }
		public string Ssl_Cert { get; set; }
		public string Ssl_Key { get; set; }
		public string Temp_Path { get; set; }
		public bool? Temp_Path_Enabled { get; set; }
		public long? Up_Limit { get; set; }
		public bool? Upnp { get; set; }
		public bool? Use_Https { get; set; }
		public string Web_Ui_Domain_List { get; set; }
		public string Web_Ui_Password { get; set; }
		public int? Web_Ui_Port { get; set; }
		public bool? Web_Ui_Upnp { get; set; }
		public string Web_Ui_Username { get; set; }
	}
}
