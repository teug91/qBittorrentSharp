using Newtonsoft.Json;
using qBittorrentSharp.Enums;

namespace qBittorrentSharp.JSON
{
    public class Preferences
    {
        [JsonProperty("locale")]
        public string Locale { get; set; }

        [JsonProperty("save_path")]
        public string Save_path { get; set; }

        [JsonProperty("temp_path_enabled")]
        public bool Temp_path_enabled { get; set; }

        [JsonProperty("temp_path")]
        public string Temp_path { get; set; }

        /*[JsonProperty("scan_dirs")]
        public string Scan_dirs { get; set; }*/

        [JsonProperty("download_in_scan_dirs")]
        public bool Download_in_scan_dirs { get; set; }

        [JsonProperty("export_dir_enabled")]
        public bool Export_dir_enabled { get; set; }

        [JsonProperty("export_dir")]
        public string Export_dir { get; set; }

        [JsonProperty("mail_notification_enabled")]
        public bool Mail_notification_enabled { get; set; }

        [JsonProperty("mail_notification_email")]
        public string Mail_notification_email { get; set; }

        [JsonProperty("mail_notification_smtp")]
        public string Mail_notification_smtp { get; set; }

        [JsonProperty("mail_notification_ssl_enabled")]
        public bool Mail_notification_ssl_enabled { get; set; }

        [JsonProperty("mail_notification_auth_enabled")]
        public bool Mail_notification_auth_enabled { get; set; }

        [JsonProperty("mail_notification_username")]
        public string Mail_notification_username { get; set; }

        [JsonProperty("mail_notification_password")]
        public string Mail_notification_password { get; set; }

        [JsonProperty("autorun_enabled")]
        public bool Autorun_enabled { get; set; }

        [JsonProperty("autorun_program")]
        public string Autorun_program { get; set; }

        [JsonProperty("preallocate_all")]
        public bool Preallocate_all { get; set; }

        [JsonProperty("queueing_enabled")]
        public bool Queueing_enabled { get; set; }

        [JsonProperty("max_active_downloads")]
        public int Max_active_downloads { get; set; }

        [JsonProperty("max_active_torrents")]
        public int Max_active_torrents { get; set; }

        [JsonProperty("max_active_uploads")]
        public int Max_active_uploads { get; set; }

        [JsonProperty("dont_count_slow_torrents")]
        public bool Dont_count_slow_torrents { get; set; }

        [JsonProperty("max_ratio_enabled")]
        public bool Max_ratio_enabled { get; set; }

        [JsonProperty("max_ratio")]
        public float Max_ratio { get; set; }

        [JsonProperty("max_ratio_act")]
        public MaxRatioAct Max_ratio_act { get; set; }

        [JsonProperty("incomplete_files_ext")]
        public bool Incomplete_files_ext { get; set; }

        [JsonProperty("listen_port")]
        public int Listen_port { get; set; }

        [JsonProperty("upnp")]
        public bool Upnp { get; set; }

        [JsonProperty("random_port ")]
        public bool Random_port { get; set; }

        [JsonProperty("dl_limit")]
        public int Dl_limit { get; set; }

        [JsonProperty("up_limit")]
        public int Up_limit { get; set; }

        [JsonProperty("max_connec")]
        public int Max_connec { get; set; }

        [JsonProperty("max_connec_per_torrent")]
        public int Max_connec_per_torrent { get; set; }

        [JsonProperty("max_uploads")]
        public int Max_uploads { get; set; }

        [JsonProperty("max_uploads_per_torrent")]
        public int Max_uploads_per_torrent { get; set; }

        [JsonProperty("enable_utp")]
        public bool Enable_utp { get; set; }

        [JsonProperty("limit_utp_rate")]
        public bool limit_utp_rate { get; set; }

        [JsonProperty("limit_tcp_overhead")]
        public bool Limit_tcp_overhead { get; set; }

        [JsonProperty("alt_dl_limit")]
        public int Alt_dl_limit { get; set; }

        [JsonProperty("alt_up_limit")]
        public int Alt_up_limit { get; set; }

        [JsonProperty("scheduler_enabled")]
        public bool Scheduler_enabled { get; set; }

        [JsonProperty("schedule_from_hour")]
        public int Schedule_from_hour { get; set; }

        [JsonProperty("schedule_from_min")]
        public int Schedule_from_min { get; set; }

        [JsonProperty("schedule_to_hour")]
        public int Schedule_to_hour { get; set; }

        [JsonProperty("schedule_to_min")]
        public int Schedule_to_min { get; set; }

        [JsonProperty("scheduler_days")]
        public SchedulerDay Scheduler_days { get; set; }

        [JsonProperty("dht")]
        public bool Dht { get; set; }

        [JsonProperty("dhtSameAsBT")]
        public bool DhtSameAsBT { get; set; }

        [JsonProperty("dht_port")]
        public int Dht_port { get; set; }

        [JsonProperty("pex")]
        public bool Pex { get; set; }

        [JsonProperty("lsd")]
        public bool Lsd { get; set; }

        [JsonProperty("encryption")]
        public Encryption Encryption { get; set; }

        [JsonProperty("anonymous_mode")]
        public bool Anonymous_mode { get; set; }

        [JsonProperty("proxy_type")]
        public ProxyType Proxy_type { get; set; }

        [JsonProperty("proxy_ip")]
        public string Proxy_ip { get; set; }

        [JsonProperty("proxy_port")]
        public int Proxy_port { get; set; }

        [JsonProperty("proxy_peer_connections")]
        public bool Proxy_peer_connections { get; set; }

        [JsonProperty("force_proxy ")]
        public bool Force_proxy { get; set; }

        [JsonProperty("proxy_auth_enabled")]
        public bool Proxy_auth_enabled { get; set; }

        [JsonProperty("proxy_username")]
        public string Proxy_username { get; set; }

        [JsonProperty("proxy_password")]
        public string Proxy_password { get; set; }

        [JsonProperty("ip_filter_enabled")]
        public bool Ip_filter_enabled { get; set; }

        [JsonProperty("ip_filter_path")]
        public string Ip_filter_path { get; set; }

        [JsonProperty("ip_filter_trackers ")]
        public bool Ip_filter_trackers { get; set; }

        [JsonProperty("web_ui_port")]
        public int Web_ui_port { get; set; }

        [JsonProperty("web_ui_upnp ")]
        public bool Web_ui_upnp { get; set; }

        [JsonProperty("web_ui_username")]
        public string Web_ui_username { get; set; }

        [JsonProperty("web_ui_password")]
        public string Web_ui_password { get; set; }

        [JsonProperty("bypass_local_auth")]
        public bool Bypass_local_auth { get; set; }

        [JsonProperty("use_https")]
        public bool Use_https { get; set; }

        [JsonProperty("ssl_key")]
        public string Ssl_key { get; set; }

        [JsonProperty("ssl_cert")]
        public string Ssl_cert { get; set; }

        [JsonProperty("dyndns_enabled")]
        public bool Dyndns_enabled { get; set; }

        [JsonProperty("dyndns_service")]
        public DynDnsService Dyndns_service { get; set; }

        [JsonProperty("dyndns_username ")]
        public string Dyndns_username { get; set; }

        [JsonProperty("dyndns_password")]
        public string Dyndns_password { get; set; }

        [JsonProperty("dyndns_domain")]
        public string Dyndns_domain { get; set; }
    }
}
