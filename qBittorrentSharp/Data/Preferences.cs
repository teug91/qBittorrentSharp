using System;
using System.Collections.Generic;
using qBittorrentSharp.Enums;

namespace qBittorrentSharp.Data
{

	public class Preferences
	{
		public List<Uri> Add_Trackers { get; set; }
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
		public DynDnsService? Dyndns_Service { get; set; }
		public string Dyndns_Username { get; set; }
		public bool? Enable_Utp { get; set; }
		public Encryption? Encryption { get; set; }
		public string Export_Dir { get; set; }
		public string Export_Dir_Fin { get; set; }
		public bool? Force_Proxy { get; set; }
		public bool? Incomplete_Files_Ext { get; set; }
		public bool? Ip_Filter_Enabled { get; set; }
		public string Ip_Filter_Path { get; set; }
		public bool? Ip_Filter_Trackers { get; set; }
		public bool? Limit_Tcp_Overhead { get; set; }
		public bool? Limit_Utp_Rate { get; set; }
		public int? Listen_Port { get; set; }
		public Locale? Locale { get; set; }
		public bool? Lsd { get; set; }
		public bool? Mail_Notification_Auth_Enabled { get; set; }
		public string Mail_Notification_Email { get; set; }
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
		public MaxRatioAction? Max_Ratio_Action { get; set; }
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
		public ProxyType? Proxy_type { get; set; }
		public string Proxy_Username { get; set; }
		public bool? Queueing_Enabled { get; set; }
		public bool? Random_Port { get; set; }
		public string Save_Path { get; set; }
		public Dictionary<string, bool> Scan_Dirs { get; set; }
		public Time Schedule_From { get; set; }
		public Time Schedule_To { get; set; }
		public SchedulerDay? Scheduler_Days { get; set; }
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

		public Preferences() { }

		internal Preferences(JSON.PreferencesJSON p)
		{
			Add_Trackers = new List<Uri>();
			if (p.add_trackers != "")
			{
				var strings = p.add_trackers.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
				foreach (var e in strings)
				{
					try { Add_Trackers.Add(new Uri(e)); }
					catch { }
				}
			}
			Add_Trackers_Enabled = p.add_trackers_enabled;
			Alt_Dl_Limit = p.alt_dl_limit;
			Alt_Up_Limit = p.alt_up_limit;
			Anonymous_Mode = p.anonymous_mode;
			Autorun_Enabled = p.autorun_enabled;
			Autorun_Program = p.autorun_program;
			Bypass_Local_Auth = p.bypass_local_auth;
			Dht = p.dht;
			Dl_Limit = p.dl_limit;
			Dont_Count_Slow_Torrents = p.dont_count_slow_torrents;
			Dyndns_Domain = p.dyndns_domain;
			Dyndns_Enabled = p.dyndns_enabled;
			Dyndns_Password = p.dyndns_password;
			Dyndns_Service = (DynDnsService)p.dyndns_service;
			Dyndns_Username = p.dyndns_username;
			Enable_Utp = p.enable_utp;
			Encryption = (Encryption)p.encryption;
			Export_Dir = p.export_dir;
			Export_Dir_Fin = p.export_dir_fin;
			Force_Proxy = p.force_proxy;
			Incomplete_Files_Ext = p.incomplete_files_ext;
			Ip_Filter_Enabled = p.ip_filter_enabled;
			Ip_Filter_Path = p.ip_filter_path;
			Ip_Filter_Trackers = p.ip_filter_trackers;
			Limit_Tcp_Overhead = p.limit_tcp_overhead;
			Limit_Utp_Rate = p.limit_utp_rate;
			Listen_Port = p.listen_port;
			Locale = (Locale)Enum.Parse(typeof(Locale), p.locale, true);
			Lsd = p.lsd;
			Mail_Notification_Auth_Enabled = p.mail_notification_auth_enabled;
			Mail_Notification_Email = p.mail_notification_email;
			Mail_Notification_Enabled = p.mail_notification_enabled;
			Mail_Notification_Password = p.mail_notification_password;
			Mail_Notification_Smtp = p.mail_notification_smtp;
			Mail_Notification_Ssl_Enabled = p.mail_notification_ssl_enabled;
			Mail_Notification_Username = p.mail_notification_username;
			Max_Active_Downloads = p.max_active_downloads;
			Max_Active_Torrents = p.max_active_torrents;
			Max_Active_Uploads = p.max_active_uploads;
			Max_Connec = p.max_connec;
			Max_Connec_Per_Torrent = p.max_connec_per_torrent;
			Max_Ratio = p.max_ratio;
			Max_Ratio_Action = (MaxRatioAction)p.max_ratio_act;
			Max_Ratio_Enabled = p.max_ratio_enabled;
			Max_Uploads = p.max_uploads;
			Max_Uploads_Per_Torrent = p.max_uploads_per_torrent;
			Pex = p.pex;
			Preallocate_All = p.preallocate_all;
			Proxy_Auth_Enabled = p.proxy_auth_enabled;
			Proxy_Ip = p.proxy_ip;
			Proxy_Password = p.proxy_password;
			Proxy_Peer_Connections = p.proxy_peer_connections;
			Proxy_Port = p.proxy_port;
			Proxy_type = (ProxyType)p.proxy_type;
			Proxy_Username = p.proxy_username;
			Queueing_Enabled = p.queueing_enabled;
			Random_Port = p.random_port;
			Save_Path = p.save_path;
			Scan_Dirs = new Dictionary<string, bool>();
			if (p.scan_dirs != null)
				foreach (var e in p.scan_dirs)
					Scan_Dirs.Add(e.Key, (e.Value == 1));
			Schedule_From = new Time((int)p.schedule_from_hour, (int)p.schedule_from_min);
			Schedule_To = new Time((int)p.schedule_to_hour, (int)p.schedule_to_min);
			Scheduler_Days = (SchedulerDay)p.scheduler_days;
			Scheduler_Enabled = p.scheduler_enabled;
			Ssl_Cert = p.ssl_cert;
			Ssl_Key = p.ssl_key;
			Temp_Path = p.temp_path;
			Temp_Path_Enabled = p.temp_path_enabled;
			Up_Limit = p.up_limit;
			Upnp = p.upnp;
			Use_Https = p.use_https;
			Web_Ui_Domain_List = p.web_ui_domain_list;
			Web_Ui_Password = p.web_ui_password;
			Web_Ui_Port = p.web_ui_port;
			Web_Ui_Upnp = p.web_ui_upnp;
			Web_Ui_Username = p.web_ui_username;
		}
	}
}
