using System;
using System.Collections.Generic;
using System.Text;

namespace qBittorrentSharp.JSON
{

	public class PreferencesJSON
	{
		public string add_trackers { get; set; }
		public bool? add_trackers_enabled { get; set; }
		public int? alt_dl_limit { get; set; }
		public int? alt_up_limit { get; set; }
		public bool? anonymous_mode { get; set; }
		public bool? autorun_enabled { get; set; }
		public string autorun_program { get; set; }
		public bool? bypass_local_auth { get; set; }
		public bool? dht { get; set; }
		public int? dl_limit { get; set; }
		public bool? dont_count_slow_torrents { get; set; }
		public string dyndns_domain { get; set; }
		public bool? dyndns_enabled { get; set; }
		public string dyndns_password { get; set; }
		public int? dyndns_service { get; set; }
		public string dyndns_username { get; set; }
		public bool? enable_utp { get; set; }
		public int? encryption { get; set; }
		public string export_dir { get; set; }
		public string export_dir_fin { get; set; }
		public bool? force_proxy { get; set; }
		public bool? incomplete_files_ext { get; set; }
		public bool? ip_filter_enabled { get; set; }
		public string ip_filter_path { get; set; }
		public bool? ip_filter_trackers { get; set; }
		public bool? limit_tcp_overhead { get; set; }
		public bool? limit_utp_rate { get; set; }
		public int? listen_port { get; set; }
		public string locale { get; set; }
		public bool? lsd { get; set; }
		public bool? mail_notification_auth_enabled { get; set; }
		public string mail_notification_email { get; set; }
		public bool? mail_notification_enabled { get; set; }
		public string mail_notification_password { get; set; }
		public string mail_notification_smtp { get; set; }
		public bool? mail_notification_ssl_enabled { get; set; }
		public string mail_notification_username { get; set; }
		public int? max_active_downloads { get; set; }
		public int? max_active_torrents { get; set; }
		public int? max_active_uploads { get; set; }
		public int? max_connec { get; set; }
		public int? max_connec_per_torrent { get; set; }
		public float? max_ratio { get; set; }
		public int? max_ratio_act { get; set; }
		public bool? max_ratio_enabled { get; set; }
		public int? max_uploads { get; set; }
		public int? max_uploads_per_torrent { get; set; }
		public bool? pex { get; set; }
		public bool? preallocate_all { get; set; }
		public bool? proxy_auth_enabled { get; set; }
		public string proxy_ip { get; set; }
		public string proxy_password { get; set; }
		public bool? proxy_peer_connections { get; set; }
		public int? proxy_port { get; set; }
		public int? proxy_type { get; set; }
		public string proxy_username { get; set; }
		public bool? queueing_enabled { get; set; }
		public bool? random_port { get; set; }
		public string save_path { get; set; }
		public Dictionary<string, int> scan_dirs { get; set; }
		public int? schedule_from_hour { get; set; }
		public int? schedule_from_min { get; set; }
		public int? schedule_to_hour { get; set; }
		public int? schedule_to_min { get; set; }
		public int? scheduler_days { get; set; }
		public bool? scheduler_enabled { get; set; }
		public string ssl_cert { get; set; }
		public string ssl_key { get; set; }
		public string temp_path { get; set; }
		public bool? temp_path_enabled { get; set; }
		public int? up_limit { get; set; }
		public bool? upnp { get; set; }
		public bool? use_https { get; set; }
		public string web_ui_domain_list { get; set; }
		public string web_ui_password { get; set; }
		public int? web_ui_port { get; set; }
		public bool? web_ui_upnp { get; set; }
		public string web_ui_username { get; set; }
	}
}
