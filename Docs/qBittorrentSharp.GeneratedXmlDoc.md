# qBittorrentSharp #

## Type API

 Communicator for qBittorrent WebUI API. 



---
#### Method API.DeleteAfterMaxSeedTime(System.TimeSpan,System.Boolean)

 Deletes torrents that have seeded longer than maximum time. 

|Name | Description |
|-----|------|
|maxSeedTime: |Maximum time of seeding.|
|deleteData: |Delete data if True.|


---
#### Method API.DeleteAfterMaxRatio(System.Single,System.Boolean)

 Deletes torrents that have seeded longer than maximum time. 

|Name | Description |
|-----|------|
|maxRatio: |Maximum ratio when seeding.|
|deleteData: |Delete data if True.|


---
#### Method API.AreAllTorrentsPaused

 Checks if all torrents are paused. 

**Returns**:  Returns false if any torrents are not paused. 



---
#### Event API.Disconnected

 Fires when qBittorrent becomes unreachable. 



---
#### Method API.Initialize(System.String,System.Int32)

 Initializes the API. 

|Name | Description |
|-----|------|
|baseAddress: |Host address.|
|timeout: |Time before timeout.|


---
#### Method API.Login(System.String,System.String)

 Logs in to qBittorrent. 

|Name | Description |
|-----|------|
|username: |Username.|
|password: |Password.|
**Returns**: True if successful, false if wrong username/password, null if unreachable.



---
#### Method API.Logout

 Logs out of qBittorrent. 

**Returns**: 



---
#### Method API.GetApiVersion

 Gets API version. 

**Returns**: API version.



---
#### Method API.GetMinApiVersion

 Gets minimum API version. 

**Returns**: Minumum API version.



---
#### Method API.GetQbittorrentVersion

 Gets qBittorrent version. 

**Returns**: qBittorrent version.



---
#### Method API.ShutdownQbittorrent

 Shuts down qBittorrent. 

**Returns**: 



---
#### Method API.GetTorrents(qBittorrentSharp.Enums.Status,System.String,qBittorrentSharp.Enums.Key,System.Boolean,System.Nullable{System.Int32},System.Nullable{System.Int32})

 Gets a list of torrents, filtering optional. 

|Name | Description |
|-----|------|
|filter: |Filter by status.|
|category: |Filter by category. Empty string is no category.|
|sort: |Sort by given key.|
|reverse: |True if reverse sorted.|
|limit: |Maximum number of torrents returned.|
|offset: |Set offset (if less than 0, offset from end).|
**Returns**: List of torrents.



---
#### Method API.GetTorrentProperties(System.String)

 Gets properties of a torrent. 

|Name | Description |
|-----|------|
|hash: |Torrent hash.|
**Returns**: Torrent properties.



---
#### Method API.GetTorrentTrackers(System.String)

 Gets all trackers of a torrent. 

|Name | Description |
|-----|------|
|hash: |Torrent hash.|
**Returns**: List of trackers.



---
#### Method API.GetTorrentWebSeeds(System.String)

 Gets all the web seeds of a torrent. 

|Name | Description |
|-----|------|
|hash: |Torrent hash.|
**Returns**: List of web seeds.



---
#### Method API.GetTorrentContents(System.String)

 Gets the contents of a torrent. 

|Name | Description |
|-----|------|
|hash: |Torrent hash,|
**Returns**: Torrent contents.



---
#### Method API.GetTorrentPiecesStates(System.String)

 Gets states of torrent pieces. 

|Name | Description |
|-----|------|
|hash: |Torrent hash.|
**Returns**: States of torrent pieces.



---
#### Method API.GetTorrentPiecesHashes(System.String)

 Gets hashes of all pieces of a torrent. 

|Name | Description |
|-----|------|
|hash: |Torrent hash.|
**Returns**: Hashes of all pieces of a torrent.



---
#### Method API.GetTransferInfo

 Gets info you usually see in qBittorrent status bar. 

**Returns**: Info you usually see in qBittorrent status bar.



---
#### Method API.GetPreferences

 Gets qBittorrent preferences. 

**Returns**: qBittorrent preferences.



---
#### Method API.GetPartialData(System.Int32)

 Gets changes since last request. 

|Name | Description |
|-----|------|
|rid: |Requst ID.|
**Returns**: Changes since last request.



---
#### Method API.GetLog(System.Boolean,System.Boolean,System.Boolean,System.Boolean,System.Int32)

 Gets log entries of given states. 

|Name | Description |
|-----|------|
|normal: |Include normal messages.|
|info: |Include info messages.|
|warning: |Include warning messages.|
|critical: |Include critical messages.|
|last_known_id: |Exclude log entries with id less or equal to this.|
**Returns**: List of log entries.



---
#### Method API.DownloadFromUrl(System.Collections.Generic.List{System.Uri},System.String,System.String,System.String,System.Nullable{System.Boolean},System.Nullable{System.Boolean},System.Nullable{System.Boolean},System.String,System.Nullable{System.Int32},System.Nullable{System.Int32},System.String,System.Nullable{System.Boolean})

 Downloads from URL. 

|Name | Description |
|-----|------|
|urls: |List of URLs.|
|savePath: |Download folder.|
|cookie: |Coookie sent to download the .torrent file..|
|category: |Category for the torrent.|
|skipChecking: |Skip hash check.|
|paused: |Add torrents in the paused state.|
|rootFolder: |Create the root folder.|
|rename: |Rename torrent.|
|upLimit: |Set torrent upload speed limit in bytes/second.|
|dlLimit: |Set torrent download speed limit in bytes/second.|
|squentialDownload: |Enable sequential download.|
|firstLastPiecePrio: |Prioritize download first last piece.|


---
#### Method API.DownloadFromDisk(System.Collections.Generic.List{System.String},System.String,System.String,System.String,System.Nullable{System.Boolean},System.Nullable{System.Boolean},System.Nullable{System.Boolean},System.String,System.Nullable{System.Int32},System.Nullable{System.Int32},System.String,System.Nullable{System.Boolean})

 Downloads from disk. 

|Name | Description |
|-----|------|
|filePaths: |List of URLs.|
|savePath: |Download folder.|
|cookie: |Coookie sent to download the .torrent file..|
|category: |Category for the torrent.|
|skipChecking: |Skip hash check.|
|paused: |Add torrents in the paused state.|
|rootFolder: |Create the root folder.|
|rename: |Rename torrent.|
|upLimit: |Set torrent upload speed limit in bytes/second.|
|dlLimit: |Set torrent download speed limit in bytes/second.|
|squentialDownload: |Enable sequential download.|
|firstLastPiecePrio: |Prioritize download first last piece.|


---
#### Method API.AddTrackers(System.String,System.Collections.Generic.List{System.Uri})

 Adds trackers to torrent. 

|Name | Description |
|-----|------|
|hash: |Torrent hash.|
|trackers: |Trackers to be added.|


---
#### Method API.PauseTorrent(System.String)

 Pauses torrent. 

|Name | Description |
|-----|------|
|hash: |Torrent hash.|


---
#### Method API.PauseAll

 Pauses all torrents. 



---
#### Method API.ResumeTorrent(System.String)

 Resumes torrent. 

|Name | Description |
|-----|------|
|hash: |Torrent hash.|


---
#### Method API.ResumeAll

 Resumes all torrents. 



---
#### Method API.DeleteTorrents(System.Collections.Generic.List{System.String},System.Boolean)

 Deletes torrents. 

|Name | Description |
|-----|------|
|hashes: |Hashes of torrents to be deleted.|
|deleteData: |Delete downloaded data.|


---
#### Method API.RecheckTorrent(System.String)

 Rechecks torrent. 

|Name | Description |
|-----|------|
|hash: |Torrent hash.|


---
#### Method API.IncreaseTorrentPriority(System.Collections.Generic.List{System.String})

 Increases priority of torrents. Torrent Queing needs to be enabled. 

|Name | Description |
|-----|------|
|hashes: |Torrent hashes.|


---
#### Method API.DecreaseTorrentPriority(System.Collections.Generic.List{System.String})

 Decreases priority of torrents. Torrent Queing needs to be enabled. 

|Name | Description |
|-----|------|
|hashes: |Torrent hashes.|


---
#### Method API.MaxTorrentPriority(System.Collections.Generic.List{System.String})

 Sets maximum priority of torrents. Torrent Queing needs to be enabled. 

|Name | Description |
|-----|------|
|hashes: |Torrent hashes.|


---
#### Method API.MinTorrentPriority(System.Collections.Generic.List{System.String})

 Sets minimum priority of torrents. Torrent Queing needs to be enabled. 

|Name | Description |
|-----|------|
|hashes: |Torrent hashes.|


---
#### Method API.SetFilePriority(System.String,System.Int32,qBittorrentSharp.Enums.Priority)

 Sets file priority. 

|Name | Description |
|-----|------|
|hash: |Torren hashes.|
|fileId: |File id.|
|priority: |File priority.|
**Returns**: 



---
#### Method API.GetGlobalDownloadSpeedLimit

 Gets global download speed limit. 

**Returns**: Global download speed limit in bytes/second; this value will be zero if no limit is applied.



---
#### Method API.SetGlobalDownloadSpeedLimit(System.Int64)

 Sets global download speed limit. 

|Name | Description |
|-----|------|
|limit: |Global download speed limit in bytes/second.|


---
#### Method API.GetGlobalUploadSpeedLimit

 Getg global upload speed limit. 

**Returns**: Global upload speed limit in bytes/second; this value will be zero if no limit is applied.



---
#### Method API.SetGlobalUploadSpeedLimit(System.Int64)

 Sets global upload speed limit. 

|Name | Description |
|-----|------|
|limit: |Global upload speed limit in bytes/second.|


---
#### Method API.GetTorrentDownloadSpeedLimit(System.Collections.Generic.List{System.String})

 Get download speed limit of torrents. 

**Returns**: Download speed limit of torrents in bytes/second.



---
#### Method API.SetTorrentDownloadSpeedLimit(System.Collections.Generic.List{System.String},System.Int32)

 Sets download speed limit of torrents. 

|Name | Description |
|-----|------|
|hashes: |Torrent hashes.|
|limit: |Download speed limit of torrents in bytes/second.|


---
#### Method API.GetTorrentUploadSpeedLimit(System.Collections.Generic.List{System.String})

 Gets upload speed limit of torrents. 

**Returns**: Upload speed limit of torrents in bytes/second.



---
#### Method API.SetTorrentUploadSpeedLimit(System.Collections.Generic.List{System.String},System.Int32)

 Sets upload speed limit of torrents. 

|Name | Description |
|-----|------|
|hashes: |Torrent hashes.|
|limit: |Upload speed limit of torrents.|


---
#### Method API.SetTorrentsLocation(System.Collections.Generic.List{System.String},System.String)

 Sets location of torrents. 

|Name | Description |
|-----|------|
|hashes: |Torrent hashes.|
|location: |Torrent location.|


---
#### Method API.SetTorrentName(System.String,System.String)

 Sets name of torrents. 

|Name | Description |
|-----|------|
|hash: |Torrent hash.|
|name: |Torrent name.|


---
#### Method API.SetTorrentCategory(System.Collections.Generic.List{System.String},System.String)

 Sets category of torrents. 

|Name | Description |
|-----|------|
|hashes: |Torrent hashes.|
|categoryName: |Name of category.|


---
#### Method API.AddNewCategory(System.String)

 Adds new category. 

|Name | Description |
|-----|------|
|categoryName: |Category name.|
**Returns**: 



---
#### Method API.RemoveCategories(System.Collections.Generic.List{System.String})

 Removes category. 

|Name | Description |
|-----|------|
|categoryNames: |Category name.|
**Returns**: 



---
#### Method API.SetAutoTorrentMgmt(System.Collections.Generic.List{System.String},System.Boolean)

 Sets automatic torrent management. 

|Name | Description |
|-----|------|
|hashes: |Torrent hashes.|
|autoTorrentMgmt: |Automatic torrent management.|
**Returns**: 



---
#### Method API.SetPreferences(qBittorrentSharp.Data.Preferences)

 Sets qBittorrent preferences. 

|Name | Description |
|-----|------|
|preferences: |qBittorrent preferences.|


---
#### Method API.IsAltSpeedLimitsEnabled

 Gets the state of the alternative speed limits. 

**Returns**: True if alternative speed limits is enabled.



---
#### Method API.ToggleAltSpeedLimits

 Toggles the state of the alternative speed limits. 



---
#### Method API.ToggleSequentialDownload(System.Collections.Generic.List{System.String})

 Toggles sequential download. 

|Name | Description |
|-----|------|
|hashes: |Torrent hashes.|


---
#### Method API.ToggleFirstLastPiecePrio(System.Collections.Generic.List{System.String})



|Name | Description |
|-----|------|
|hashes: ||
**Returns**: 



---
#### Method API.SetForceStart(System.Collections.Generic.List{System.String},System.Boolean)

 Sets first/last piece priority of torrents. 

|Name | Description |
|-----|------|
|hashes: |Torrent hashes.|
|activate: |Whether to activate first/last piece priority of torrents.|


---
#### Method API.SetSuperSeeding(System.Collections.Generic.List{System.String},System.Boolean)

 Sets super seeding of torrents. 

|Name | Description |
|-----|------|
|hashes: |Torrent hashes.|
|activate: |Whether to activate super seeding of torrents.|
**Returns**: 



---
## Type Data.Log

 Log. 



---
#### Property Data.Log.Id

 ID of the message. 



---
#### Property Data.Log.Message

 Text of the message. 



---
#### Property Data.Log.Timestamp

 Time since epoch. 



---
#### Property Data.Log.Type

 Type of the message. 



---
#### Method Data.Log.#ctor

 Initializes a new instance of the [[|T:qBittorrentSharp.Data.Log]] class. 



---
## Type Data.PartialData

 Partial data. Changes since last request. 



---
#### Property Data.PartialData.Rid

 Response ID. 



---
#### Property Data.PartialData.Full_Update

 Whether the response contains all the data or partial data. 



---
#### Property Data.PartialData.Torrents

 Torrent list. 



---
#### Property Data.PartialData.Torrents_Removed

 List of hashes of torrent removed since last request. 



---
#### Property Data.PartialData.Categories

 List of categories added since last request. 



---
#### Property Data.PartialData.Categories_Removed

 List of categories removed since last request. 



---
#### Property Data.PartialData.Queueing

 Priority system usage flag. 



---
#### Property Data.PartialData.Server_State

 Server state. 



---
#### Method Data.PartialData.#ctor

 Initializes a new instance of the [[|T:qBittorrentSharp.Data.PartialData]] class. 



---
## Type Data.Preferences

 Preferences. 



---
#### Property Data.Preferences.Add_Trackers

 Trackers to be added to new torrents. 



---
#### Property Data.Preferences.Add_Trackers_Enabled

 Automatically add trackers to new torrents. 



---
#### Property Data.Preferences.Alt_Dl_Limit

 Alternative global download speed limit in KiB/s. 



---
#### Property Data.Preferences.Alt_Up_Limit

 Alternative global upload speed limit in KiB/s. 



---
#### Property Data.Preferences.Anonymous_Mode

 If true anonymous mode will be enabled. 



---
#### Property Data.Preferences.Autorun_Enabled

 True if external program should be run after torrent has finished downloading. 



---
#### Property Data.Preferences.Autorun_Program

 Program path/name/arguments to run if autorun_enabled is enabled; path is separated by slashes; you can use %f and %n arguments, which will be expanded by qBittorent as path_to_torrent_file and torrent_name (from the GUI; not the .torrent file name) respectively. 



---
#### Property Data.Preferences.Bypass_Local_Auth

 True if authentication challenge for loopback address (127.0.0.1) should be disabled. 



---
#### Property Data.Preferences.Dht

 True if DHT is enabled. 



---
#### Property Data.Preferences.DhtSameAsBT

 True if DHT port should match TCP port 



---
#### Property Data.Preferences.Dht_Port

 DHT port if dhtSameAsBT is false. 



---
#### Property Data.Preferences.Dl_Limit

 Global download speed limit in KiB/s; -1 means no limit is applied. 



---
#### Property Data.Preferences.Dont_Count_Slow_Torrents

 If true torrents w/o any activity (stalled ones) will not be counted towards max_active_* limits. 



---
#### Property Data.Preferences.Dyndns_Domain

 Your DDNS domain name. 



---
#### Property Data.Preferences.Dyndns_Enabled

 True if server DNS should be updated dynamically. 



---
#### Property Data.Preferences.Dyndns_Password

 Password for DDNS service. 



---
#### Property Data.Preferences.Dyndns_Service

 DDNS service. 



---
#### Property Data.Preferences.Dyndns_Username

 Username for DDNS service. 



---
#### Property Data.Preferences.Enable_Utp

 True if uTP protocol should be enabled. 



---
#### Property Data.Preferences.Encryption

 Encryption. 



---
#### Property Data.Preferences.Export_Dir

 Path to directory to copy .torrent files if export_dir_enabled is enabled; path is separated by slashes. 



---
#### Property Data.Preferences.Export_Dir_Finished

 Path to directory to copy .torrent files if export_dir_enabled is enabled; path is separated by slashes. 



---
#### Property Data.Preferences.Force_Proxy

 True if the connections not supported by the proxy are disabled 



---
#### Property Data.Preferences.Incomplete_Files_Ext

 If true .!qB extension will be appended to incomplete files. 



---
#### Property Data.Preferences.Ip_Filter_Enabled

 True if external IP filter should be enabled. 



---
#### Property Data.Preferences.Ip_Filter_Path

 Path to IP filter file (.dat, .p2p, .p2b files are supported); path is separated by slashes. 



---
#### Property Data.Preferences.Ip_Filter_Trackers

 True if IP filters are applied to trackers. 



---
#### Property Data.Preferences.Limit_Tcp_Overhead

 True if [du]l_limit should be applied to estimated TCP overhead (service data: e.g. packet headers). 



---
#### Property Data.Preferences.Limit_Utp_Rate

 True if [du]l_limit should be applied to uTP connections. 



---
#### Property Data.Preferences.Listen_Port

 Port for incoming connections. 



---
#### Property Data.Preferences.Locale

 Currently selected language. 



---
#### Property Data.Preferences.Lsd

 True if LSD is enabled. 



---
#### Property Data.Preferences.Mail_Notification_Auth_Enabled

 True if smtp server requires authentication 



---
#### Property Data.Preferences.Mail_Notification_Email

 e-mail to send notifications to. 



---
#### Property Data.Preferences.Mail_Notification_Enabled

 True if e-mail notification should be enabled. 



---
#### Property Data.Preferences.Mail_Notification_Password

 Password for smtp authentication. 



---
#### Property Data.Preferences.Mail_Notification_Smtp

 smtp server for e-mail notifications. 



---
#### Property Data.Preferences.Mail_Notification_Ssl_Enabled

 True if smtp server requires SSL connection. 



---
#### Property Data.Preferences.Mail_Notification_Username

 Username for smtp authentication. 



---
#### Property Data.Preferences.Max_Active_Downloads

 Maximum number of active simultaneous downloads. 



---
#### Property Data.Preferences.Max_Active_Torrents

 Maximum number of active simultaneous downloads and uploads. 



---
#### Property Data.Preferences.Max_Active_Uploads

 Maximum number of active simultaneous uploads. 



---
#### Property Data.Preferences.Max_Connec

 Maximum global number of simultaneous connections. 



---
#### Property Data.Preferences.Max_Connec_Per_Torrent

 Maximum number of simultaneous connections per torrent. 



---
#### Property Data.Preferences.Max_Ratio

 Get the global share ratio limit. 



---
#### Property Data.Preferences.Max_Ratio_Action

 Action performed when a torrent reaches the maximum share ratio. 



---
#### Property Data.Preferences.Max_Ratio_Enabled

 True if share ratio limit is enabled. 



---
#### Property Data.Preferences.Max_Uploads

 Maximum number of upload slots. 



---
#### Property Data.Preferences.Max_Uploads_Per_Torrent

 Maximum number of upload slots per torrent. 



---
#### Property Data.Preferences.Pex

 True if PeX is enabled. 



---
#### Property Data.Preferences.Preallocate_All

 True if file preallocation should take place, otherwise sparse files are used. 



---
#### Property Data.Preferences.Proxy_Auth_Enabled

 True proxy requires authentication; doesn't apply to SOCKS4 proxies. 



---
#### Property Data.Preferences.Proxy_Ip

 Proxy IP address or domain name. 



---
#### Property Data.Preferences.Proxy_Password

 Password for proxy authentication. 



---
#### Property Data.Preferences.Proxy_Peer_Connections

 True if peer and web seed connections should be proxified. 



---
#### Property Data.Preferences.Proxy_Port

 Proxy port. 



---
#### Property Data.Preferences.Proxy_type

 Proxy type. 



---
#### Property Data.Preferences.Proxy_Username

 Username for proxy authentication. 



---
#### Property Data.Preferences.Queueing_Enabled

 True if torrent queuing is enabled. 



---
#### Property Data.Preferences.Random_Port

 True if the port is randomly selected. 



---
#### Property Data.Preferences.Save_Path

 Default save path for torrents, separated by slashes. 



---
#### Property Data.Preferences.Scan_Dirs

 List of watch folders, true if torrents gets added automatically. 



---
#### Property Data.Preferences.Schedule_From

 Scheduler starting time. 



---
#### Property Data.Preferences.Schedule_To

 Scheduler ending time. 



---
#### Property Data.Preferences.Scheduler_Days

 Scheduler days. 



---
#### Property Data.Preferences.Scheduler_Enabled

 True if alternative limits should be applied according to schedule. 



---
#### Property Data.Preferences.Ssl_Cert

 SSL certificate contents (this is a not a path). 



---
#### Property Data.Preferences.Ssl_Key

 SSL keyfile contents (this is a not a path). 



---
#### Property Data.Preferences.Temp_Path

 Path for incomplete torrents, separated by slashes. 



---
#### Property Data.Preferences.Temp_Path_Enabled

 True if folder for incomplete torrents is enabled. 



---
#### Property Data.Preferences.Up_Limit

 Global upload speed limit in KiB/s; -1 means no limit is applied 



---
#### Property Data.Preferences.Upnp

 True if UPnP/NAT-PMP is enabled. 



---
#### Property Data.Preferences.Use_Https

 True if WebUI HTTPS access is enabled. 



---
#### Property Data.Preferences.Web_Ui_Domain_List

 WebUI domain list. 



---
#### Property Data.Preferences.Web_Ui_Password

 MD5 hash of WebUI password. 



---
#### Property Data.Preferences.Web_Ui_Port

 WebUI port. 



---
#### Property Data.Preferences.Web_Ui_Upnp

 True if UPnP is used for the WebUI port. 



---
#### Property Data.Preferences.Web_Ui_Username

 WebUI username. 



---
#### Method Data.Preferences.#ctor

 Initializes a new instance of the [[|T:qBittorrentSharp.Data.Preferences]] class. 



---
## Type Data.Time

 Time, i.e. 18:30. 



---
#### Property Data.Time.Hours

 Hours. 



---
#### Property Data.Time.Minutes

 Minutes. 



---
#### Method Data.Time.#ctor(System.Int32,System.Int32)

 Initializes a new instance of the [[|T:qBittorrentSharp.Data.Time]] class. 

|Name | Description |
|-----|------|
|hours: |Hours needs to be 0-23.|
|minutes: |Minutes needs to be 0-59.|


---
## Type Data.Torrent

 Torrent. 



---
#### Property Data.Torrent.Added_On

 When torrent was addes. 



---
#### Property Data.Torrent.Amount_Left

 Amount of bytes left before completion. 



---
#### Property Data.Torrent.Category

 Category of the torrent. 



---
#### Property Data.Torrent.Completed

 Amount completed bytes. 



---
#### Property Data.Torrent.Completion_On

 Completetion time. 



---
#### Property Data.Torrent.Dl_Limit

 Torrent download speed limit in (bytes/s). 



---
#### Property Data.Torrent.Dl_Speed

 Torrent download speed (bytes/s). 



---
#### Property Data.Torrent.Downloaded

 Total data downloaded for torrent (bytes). 



---
#### Property Data.Torrent.Downloaded_Session

 Data downloaded this session (bytes). 



---
#### Property Data.Torrent.Eta

 Torrent ETA. 



---
#### Property Data.Torrent.First_Last_Piece_Prio

 True if first last piece are prioritized. 



---
#### Property Data.Torrent.Force_Start

 True if force start is enabled for this torrent. 



---
#### Property Data.Torrent.Hash

 Torrent hash. 



---
#### Property Data.Torrent.Last_Activity

 When last activity was. 



---
#### Property Data.Torrent.Name

 Torrent name. 



---
#### Property Data.Torrent.Num_Complete

 Number of seeds in the swarm. 



---
#### Property Data.Torrent.Num_Incomplete

 Number of leechers in the swarm. 



---
#### Property Data.Torrent.Num_Leechs

 Number of leechers connected to. 



---
#### Property Data.Torrent.Num_Seeds

 Number of seeds connected to. 



---
#### Property Data.Torrent.Priority

 Torrent priority. 



---
#### Property Data.Torrent.Progress

 Torrent progress. 



---
#### Property Data.Torrent.Ratio

 Torrent share ratio. 



---
#### Property Data.Torrent.Ratio_Limit

 Torrent ratio limit. 



---
#### Property Data.Torrent.Save_Path

 Torrent save path. 



---
#### Property Data.Torrent.Seen_Complete

 When seen complete. 



---
#### Property Data.Torrent.Seq_Dl

 True if sequential download is enabled. 



---
#### Property Data.Torrent.Size

 Total size (bytes) of files selected for download. 



---
#### Property Data.Torrent.State

 Torrent state. 



---
#### Property Data.Torrent.Super_Seeding

 True if super seeding is enabled. 



---
#### Property Data.Torrent.Total_Size

 Torrent total size (bytes). 



---
#### Property Data.Torrent.Tracker

 Torrent tracker. 



---
#### Property Data.Torrent.Up_Limit

 Torrent upload speed limit in (bytes/s). 



---
#### Property Data.Torrent.Uploaded

 Total data uploaded for torrent (bytes). 



---
#### Property Data.Torrent.Uploaded_Session

 Total data uploaded this session (bytes). 



---
#### Property Data.Torrent.Up_Speed

 Torrent upload speed (bytes/s). 



---
#### Method Data.Torrent.#ctor

 Initializes a new instance of the [[|T:qBittorrentSharp.Data.Torrent]] class. 



---
## Type Data.TorrentContents

 Torrent contents. 



---
#### Property Data.TorrentContents.Name

 File name (including relative path). 



---
#### Property Data.TorrentContents.Size

 File size (bytes). 



---
#### Property Data.TorrentContents.Progress

 File progress. 



---
#### Property Data.TorrentContents.Priority

 File priority. 



---
#### Property Data.TorrentContents.Is_Seed

 True if file is seeding/complete. 



---
#### Property Data.TorrentContents.Piece_Range

 The first number is the starting piece index and the second number is the ending piece index (inclusive). 



---
#### Method Data.TorrentContents.#ctor

 Initializes a new instance of the [[|T:qBittorrentSharp.Data.TorrentContents]] class. 



---
## Type Data.TorrentProperties

 Torrent properties. 



---
#### Property Data.TorrentProperties.Save_Path

 Torrent save path. 



---
#### Property Data.TorrentProperties.Creation_Date

 Torrent creation date. 



---
#### Property Data.TorrentProperties.Piece_Size

 Torrent piece size (bytes). 



---
#### Property Data.TorrentProperties.Comment

 Torrent comment. 



---
#### Property Data.TorrentProperties.Total_Wasted

 Total data wasted for torrent (bytes). 



---
#### Property Data.TorrentProperties.Total_Uploaded

 Total data uploaded for torrent (bytes). 



---
#### Property Data.TorrentProperties.Total_Uploaded_Session

 Total data uploaded this session (bytes). 



---
#### Property Data.TorrentProperties.Total_Downloaded

 Total data uploaded for torrent (bytes). 



---
#### Property Data.TorrentProperties.Total_Downloaded_Session

 Total data downloaded this session (bytes). 



---
#### Property Data.TorrentProperties.Up_Limit

 Torrent upload limit (bytes/s). 



---
#### Property Data.TorrentProperties.Dl_Limit

 Torrent download limit (bytes/s). 



---
#### Property Data.TorrentProperties.Time_Elapsed

 Torrent elapsed time. 



---
#### Property Data.TorrentProperties.Seeding_Time

 Torrent elapsed time while complete. 



---
#### Property Data.TorrentProperties.Nb_Connections

 Torrent connection count. 



---
#### Property Data.TorrentProperties.Nb_Connections_Limit

 Torrent connection count limit. 



---
#### Property Data.TorrentProperties.Share_Ratio

 Torrent share ratio. 



---
#### Property Data.TorrentProperties.Addition_Date

 When this torrent was added. 



---
#### Property Data.TorrentProperties.Completion_Date

 Torrent completion date. 



---
#### Property Data.TorrentProperties.Created_By

 Torrent creator. 



---
#### Property Data.TorrentProperties.Dl_Speed_Avg

 Torrent average download speed (bytes/second). 



---
#### Property Data.TorrentProperties.Dl_Speed

 Torrent download speed (bytes/second). 



---
#### Property Data.TorrentProperties.Eta

 Torrent ETA. 



---
#### Property Data.TorrentProperties.Last_Seen

 Last seen complete date. 



---
#### Property Data.TorrentProperties.Peers

 Number of peers connected to. 



---
#### Property Data.TorrentProperties.Peers_Total

 Number of peers in the swarm. 



---
#### Property Data.TorrentProperties.Pieces_Have

 Number of pieces owned. 



---
#### Property Data.TorrentProperties.Pieces_Num

 Number of pieces of the torrent. 



---
#### Property Data.TorrentProperties.Reannounce

 Time until the next announce. 



---
#### Property Data.TorrentProperties.Seeds

 Number of seeds connected to. 



---
#### Property Data.TorrentProperties.Seeds_Total

 Number of seeds in the swarm. 



---
#### Property Data.TorrentProperties.Total_Size

 Torrent total size (bytes). 



---
#### Property Data.TorrentProperties.Up_Speed_Avg

 Torrent average upload speed (bytes/second). 



---
#### Property Data.TorrentProperties.Up_Speed

 Torrent upload speed (bytes/second). 



---
#### Method Data.TorrentProperties.#ctor

 Initializes a new instance of the [[|T:qBittorrentSharp.Data.TorrentProperties]] class. 



---
## Type Data.Tracker

 Torrent tracker. 



---
#### Property Data.Tracker.Url

 Tracker url 



---
#### Property Data.Tracker.Status

 Tracker status. 



---
#### Property Data.Tracker.Num_Peers

 Number of peers for current torrent reported by the tracker. 



---
#### Property Data.Tracker.Msg

 Tracker message (there is no way of knowing what this message is - it's up to tracker admins). 



---
#### Method Data.Tracker.#ctor

 Initializes a new instance of the [[|T:qBittorrentSharp.Data.Tracker]] class. 



---
## Type Data.TransferInfo

 Transfer info. 



---
#### Property Data.TransferInfo.Dl_Info_Speed

 Global download rate (bytes/s). 



---
#### Property Data.TransferInfo.Dl_Info_Data

 Data downloaded this session (bytes). 



---
#### Property Data.TransferInfo.Up_Info_Speed

 Global upload rate (bytes/s). 



---
#### Property Data.TransferInfo.Up_Info_Data

 Data uploaded this session (bytes). 



---
#### Property Data.TransferInfo.Dl_Rate_Limit

 Download rate limit (bytes/s). 



---
#### Property Data.TransferInfo.Up_Rate_Limit

 Upload rate limit (bytes/s). 



---
#### Property Data.TransferInfo.Dht_Nodes

 DHT nodes connected to. 



---
#### Property Data.TransferInfo.Connection_Status

 Connection status. 



---
#### Property Data.TransferInfo.Queueing

 True if torrent queueing is enabled. 



---
#### Property Data.TransferInfo.Use_Alt_Speed_Limits

 True if alternative speed limits are enabled. 



---
#### Property Data.TransferInfo.Refresh_Interval

 Transfer list refresh interval (milliseconds) 



---
#### Method Data.TransferInfo.#ctor

 Initializes a new instance of the [[|T:qBittorrentSharp.Data.TransferInfo]] class. 



---
## Type QBTException

 Represents an exception thrown by API. 



---
#### Property QBTException.HttpStatusCode

 The [[|P:qBittorrentSharp.QBTException.HttpStatusCode]]. 



---
#### Method QBTException.#ctor(System.Net.HttpStatusCode,System.String)

 Initializes a new instance of the [[|T:qBittorrentSharp.QBTException]] class. 

 /// |Name | Description |
|-----|------|
|httpStatusCode: |The [[|P:qBittorrentSharp.QBTException.HttpStatusCode]].|
|message: |The message which describes the reason of throwing this exception.|


---
## Type Enums.ConnectionStatus

 Connection status. 



---
#### Field Enums.ConnectionStatus.Connected

 Connected. 



---
#### Field Enums.ConnectionStatus.Firewalled

 Firewalled. 



---
#### Field Enums.ConnectionStatus.Disconnected

 Disconnected. 



---
## Type Enums.DynDnsService

 DynDNS service. 



---
#### Field Enums.DynDnsService.UseDyDns

 Use DyDNS. 



---
#### Field Enums.DynDnsService.UseNoIp

 Use NOIP. 



---
## Type Enums.Encryption

 Encryption. 



---
#### Field Enums.Encryption.PreferEncryption

 Prefer encryption. 



---
#### Field Enums.Encryption.ForceEncryptionOn

 Force encryption on. 



---
#### Field Enums.Encryption.ForceEncryptionOff

 Force encryption off. 



---
## Type Enums.Key

 Torrent key. 



---
#### Field Enums.Key.Hash

 Torrent hash. 



---
#### Field Enums.Key.Name

 Torrent name. 



---
#### Field Enums.Key.Size

 Total size of files selected for download. 



---
#### Field Enums.Key.Progress

 Torrent progress. 



---
#### Field Enums.Key.DlSpeed

 Torrent download speed. 



---
#### Field Enums.Key.UpSpeed

 Torrent upload speed. 



---
#### Field Enums.Key.Priority

 Torrent priority. 



---
#### Field Enums.Key.Num_Seeds

 Number of seeds connected to. 



---
#### Field Enums.Key.Num_Complete

 Number of seeds in the swarm. 



---
#### Field Enums.Key.Num_Leechs

 Number of leechers connected to. 



---
#### Field Enums.Key.Num_Incomplete

 Number of leechers in the swarm. 



---
#### Field Enums.Key.Ratio

 Torrent share ratio. 



---
#### Field Enums.Key.Eta

 Torrent ETA. 



---
#### Field Enums.Key.State

 Torrent state. 



---
#### Field Enums.Key.Seq_Dl

 Sequential download. 



---
#### Field Enums.Key.F_L_Piece_Prio

 First last piece prioritized. 



---
#### Field Enums.Key.Category

 Category of the torrent. 



---
#### Field Enums.Key.Super_Seeding

 Super seeding. 



---
#### Field Enums.Key.Force_Start

 Force start. 



---
## Type Enums.Locale

 Locale. 



---
#### Field Enums.Locale.en

 English 



---
#### Field Enums.Locale.en_AU

 English(Australia) 



---
#### Field Enums.Locale.en_GB

 English(United Kingdom) 



---
#### Field Enums.Locale.eo_EO

 Esperanto 



---
#### Field Enums.Locale.fr_FR

 Français 



---
#### Field Enums.Locale.de_DE

 Deutsch 



---
#### Field Enums.Locale.hu_HU

 Magyar 



---
#### Field Enums.Locale.is

 Íslenska 



---
#### Field Enums.Locale.id

 Bahasa Indonesia 



---
#### Field Enums.Locale.it_IT

 Italiano 



---
#### Field Enums.Locale.nl_NL

 Nederlands 



---
#### Field Enums.Locale.es_ES

 Español 



---
#### Field Enums.Locale.ca_ES

 Català 



---
#### Field Enums.Locale.gl_ES

 Galego 



---
#### Field Enums.Locale.oc

 lenga d'òc 



---
#### Field Enums.Locale.pt_BR

 Português brasileiro 



---
#### Field Enums.Locale.pt_PT

 Português 



---
#### Field Enums.Locale.pl_PL

 Polski 



---
#### Field Enums.Locale.lv_LV

 latviešu valoda 



---
#### Field Enums.Locale.lt_LT

 Lietuvių 



---
#### Field Enums.Locale.ms_MY

 بهاس ملايو 



---
#### Field Enums.Locale.cs_CZ

 Čeština 



---
#### Field Enums.Locale.sk_SK

 Slovenčina 



---
#### Field Enums.Locale.sl_SI

 Slovenščina 



---
#### Field Enums.Locale.sr_CS

 Српски 



---
#### Field Enums.Locale.hi_IN

 हिन्दी, हिंदी 



---
#### Field Enums.Locale.hr_HR

 Hrvatski 



---
#### Field Enums.Locale.hy_AM

 Հայերեն 



---
#### Field Enums.Locale.ro_RO

 Română 



---
#### Field Enums.Locale.tr_TR

 Türkçe 



---
#### Field Enums.Locale.el_GR

 Ελληνικά 



---
#### Field Enums.Locale.sv_SE

 Svenska 



---
#### Field Enums.Locale.fi_FI

 Suomi 



---
#### Field Enums.Locale.nb_NO

 Norsk 



---
#### Field Enums.Locale.da_DK

 Dansk 



---
#### Field Enums.Locale.bg_BG

 Български 



---
#### Field Enums.Locale.uk_UA

 Українська 



---
#### Field Enums.Locale.uz_Latn

 >أۇزبېك 



---
#### Field Enums.Locale.ru_RU

 Русский 



---
#### Field Enums.Locale.ja_JP

 日本語 



---
#### Field Enums.Locale.he_IL

 עברית 



---
#### Field Enums.Locale.ar_AE

 עברית 



---
#### Field Enums.Locale.ka_GE

 עברית 



---
#### Field Enums.Locale.be_BY

 Беларуская 



---
#### Field Enums.Locale.eu_ES

 Euskara 



---
#### Field Enums.Locale.vi_VN

 tiếng Việt 



---
#### Field Enums.Locale.zh

 简体中文 



---
#### Field Enums.Locale.zh_TW

 正體中文 



---
#### Field Enums.Locale.zh_HK

 香港正體字 



---
#### Field Enums.Locale.ko_KR

 한글 



---
## Type Enums.LogType

 Log type. 



---
#### Field Enums.LogType.Normal

 Normal. 



---
#### Field Enums.LogType.Info

 Info. 



---
#### Field Enums.LogType.Warning

 Warning. 



---
#### Field Enums.LogType.Critical

 Critical. 



---
## Type Enums.MaxRatioAction

 Action when maximum ratio has been reached. 



---
#### Field Enums.MaxRatioAction.PauseTorrent

 Pause torrent. 



---
#### Field Enums.MaxRatioAction.RemoveTorrent

 Remove torrent. 



---
## Type Enums.PieceState

 State of torrent piece. 



---
#### Field Enums.PieceState.NotDownloadedYet

 Not downloaded yet. 



---
#### Field Enums.PieceState.NowDownloading

 Now downloading. 



---
#### Field Enums.PieceState.AlreadyDownloaded

 Already downloaded. 



---
## Type Enums.Priority

 File priority. 



---
#### Field Enums.Priority.DoNotDownload

 Do not download. 



---
#### Field Enums.Priority.NormalPriority

 Normal priority. 



---
#### Field Enums.Priority.HighPriority

 High priority. 



---
#### Field Enums.Priority.MaximalPriority

 Maximal priority. 



---
## Type Enums.ProxyType

 Proxy type. 



---
#### Field Enums.ProxyType.ProxyIsDisabled

 Proxy is disabled. 



---
#### Field Enums.ProxyType.HttpProxyWithoutAuthentication

 HTTP proxy without authentication. 



---
#### Field Enums.ProxyType.Socks5ProxyWithoutAuthentication

 SOCKS5 proxy without authentication 



---
#### Field Enums.ProxyType.HttpProxyWithAuthentication

 HTTP proxy with authentication 



---
#### Field Enums.ProxyType.Socks5ProxyWithAuthentication

 SOCKS5 proxy with authentication 



---
#### Field Enums.ProxyType.Socks4ProxyWithoutAuthentication

 SOCKS4 proxy without authentication 



---
## Type Enums.SchedulerDay

 Scheduler day. 



---
#### Field Enums.SchedulerDay.EveryDay

 Every day. 



---
#### Field Enums.SchedulerDay.EveryWeekday

 Every weekday. 



---
#### Field Enums.SchedulerDay.EveryWeekend

 Every weekend. 



---
#### Field Enums.SchedulerDay.EveryMonday

 Every Monday. 



---
#### Field Enums.SchedulerDay.EveryTuesday

 Every Tuesday. 



---
#### Field Enums.SchedulerDay.EveryWednesday

 Every Wednesday. 



---
#### Field Enums.SchedulerDay.EveryThursday

 Every Thursday. 



---
#### Field Enums.SchedulerDay.EveryFriday

 Every Friday. 



---
#### Field Enums.SchedulerDay.EverySaturday

 Every Saturday. 



---
#### Field Enums.SchedulerDay.EverySunday

 Every Sunday. 



---
## Type Enums.Status

 Torrent status. 



---
#### Field Enums.Status.All

 All statuses. 



---
#### Field Enums.Status.Downloading

 Downloading. 



---
#### Field Enums.Status.Completed

 Completed. 



---
#### Field Enums.Status.Paused

 Paused. 



---
#### Field Enums.Status.Active

 Active. 



---
#### Field Enums.Status.Inactive

 Inactive. 



---
## Type Enums.TorrentState

 Torrent state. 



---
#### Field Enums.TorrentState.Error

 Some error occurred, applies to paused torrents. 



---
#### Field Enums.TorrentState.PausedUP

 Torrent is paused and has finished downloading. 



---
#### Field Enums.TorrentState.PausedDL

 Torrent is paused and has NOT finished downloading. 



---
#### Field Enums.TorrentState.QueuedUP

 Queuing is enabled and torrent is queued for upload. 



---
#### Field Enums.TorrentState.QueuedDL

 Queuing is enabled and torrent is queued for download. 



---
#### Field Enums.TorrentState.Uploading

 Torrent is being seeded and data is being transferred. 



---
#### Field Enums.TorrentState.StalledUP

 Torrent is being seeded, but no connection were made. 



---
#### Field Enums.TorrentState.CheckingUP

 Torrent has finished downloading and is being checked; this status also applies to preallocation (if enabled) and checking resume data on qBt startup. 



---
#### Field Enums.TorrentState.CheckingDL

 Same as checkingUP, but torrent has NOT finished downloading. 



---
#### Field Enums.TorrentState.Downloading

 Torrent is being downloaded and data is being transferred. 



---
#### Field Enums.TorrentState.StalledDL

 Torrent is being downloaded, but no connection were made. 



---
#### Field Enums.TorrentState.MetaDL

 Torrent has just started downloading and is fetching metadata. 



---
#### Field Enums.TorrentState.ForcedDL

 Torrent is being forced downloaded and data is being transferred. 



---
#### Field Enums.TorrentState.ForcedUP

 Torrent is being forced uploaded, but no connection were made. 



---
## Type Enums.Trackerstatus

 Tracker status. 



---
#### Field Enums.Trackerstatus.Working

 Tracker has been contacted and is working 



---
#### Field Enums.Trackerstatus.Updating

 Tracker is currently being updated 



---
#### Field Enums.Trackerstatus.NotWorking

 Tracker has been contacted, but it is not working (or doesn't send proper replies) 



---
#### Field Enums.Trackerstatus.NotContactedYet

 Tracker has not been contacted yet 



---


