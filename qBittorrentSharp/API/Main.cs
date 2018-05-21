using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using qBittorrentSharp.JSON;
using System.IO;
using qBittorrentSharp.Enums;
using Newtonsoft.Json.Linq;
using qBittorrentSharp.Data;

namespace qBittorrentSharp
{
	/// <summary>
	/// Communicator for qBittorrent WebUI API.
	/// </summary>
    public static partial class API
    {
		private static HttpClient client;

		/// <summary>
		/// Fires when qBittorrent becomes unreachable.
		/// </summary>
		public static event EventHandler Disconnected;

		/// <summary>
		/// Initializes the API.
		/// </summary>
		/// <param name="baseAddress">Host address.</param>
		/// <param name="timeout">Time before timeout.</param>
		public static void Initialize(string baseAddress, int timeout = 100)
        {
			if (client != null)
				client.Dispose();
			client = new HttpClient();
			baseAddress = baseAddress.Replace("\\", "/");
            if (baseAddress[baseAddress.Length - 1] != '/')
                baseAddress += "/";

            Uri.TryCreate(baseAddress, UriKind.Absolute, out Uri uri);

            if (uri == null)
                throw new UriFormatException("Format of base address is invalid!");

            client.BaseAddress = new Uri(baseAddress);
            client.Timeout = TimeSpan.FromSeconds(timeout);
        }

		/// <summary>
		/// Logs in to qBittorrent.
		/// </summary>
		/// <param name="username">Username.</param>
		/// <param name="password">Password.</param>
		/// <returns>True if successful, false if wrong username/password, null if unreachable.</returns>
        public static async Task<bool?> Login(string username, string password)
        {
			var content = ToStringContent("username=" + username + "&password=" + password);
			var reply = await Post(client, "/login", content);

			if (reply == null)
                return null;

            var result = await reply.Content.ReadAsStringAsync();

			if (result == "Ok.")
				return true;

            return false;
        }

		/// <summary>
		/// Logs out of qBittorrent.
		/// </summary>
		/// <returns></returns>
        public static async Task Logout()
        {
            await Post(client, "/logout");
        }

		/// <summary>
		/// Gets API version.
		/// </summary>
		/// <returns>API version.</returns>
        public static async Task<int> GetApiVersion()
        {
            var reply = await Post(client, "/version/api");
            return Int32.Parse(await reply.Content.ReadAsStringAsync());
        }

		/// <summary>
		/// Gets minimum API version.
		/// </summary>
		/// <returns>Minumum API version.</returns>
        public static async Task<int> GetMinApiVersion()
        {
            var reply = await Post(client, "/version/api_min");
            return Int32.Parse(await reply.Content.ReadAsStringAsync());
        }

		/// <summary>
		/// Gets qBittorrent version.
		/// </summary>
		/// <returns>qBittorrent version.</returns>
		public static async Task<string> GetQbittorrentVersion()
        {
            var reply = await Post(client, "/version/qbittorrent");
            return await reply.Content.ReadAsStringAsync();
        }

		/// <summary>
		/// Shuts down qBittorrent.
		/// </summary>
		/// <returns></returns>
        public static async Task ShutdownQbittorrent()
        {
            await Post(client, "/command/shutdown");
        }

		/// <summary>
		/// Gets a list of torrents, filtering optional.
		/// </summary>
		/// <param name="filter">Filter by status.</param>
		/// <param name="category">Filter by category. Empty string is no category.</param>
		/// <param name="sort">Sort by given key.</param>
		/// <param name="reverse">True if reverse sorted.</param>
		/// <param name="limit">Maximum number of torrents returned.</param>
		/// <param name="offset">Set offset (if less than 0, offset from end).</param>
		/// <returns>List of torrents.</returns>
		public static async Task<List<Torrent>> GetTorrents(Status filter = Status.All,
													 string category = null,
													 Key sort = Key.Name,
													 bool reverse = false,
													 int? limit = null,
													 int? offset = null)
        {
            HttpResponseMessage reply;
            var parameters = "?";

            parameters += "filter=" + filter.ToString() + "&";

            if (category != null)
                parameters += "category=" + category + "&";

            parameters += "sort=" + sort + "&";

            parameters += "reverse=" + reverse.ToString() + "&";

            if (limit != null)
                parameters += "limit=" + limit + "&";

            if (offset != null)
                parameters += "offset=" + offset + "&";

            parameters = parameters.Remove(parameters.Length - 1);
			reply = await Post(client, "/query/torrents" + parameters);

			if (reply == null)
				return null;

			var result = await reply.Content.ReadAsStringAsync();
			if (result == "")
				return null;

			var torrentsJSON = JsonConvert.DeserializeObject<List<TorrentJSON>>(await reply.Content.ReadAsStringAsync());
			var torrents = new List<Torrent>();

			foreach (TorrentJSON t in torrentsJSON)
				torrents.Add(new Torrent(t));

			return torrents;
		}

		/// <summary>
		/// Gets properties of a torrent.
		/// </summary>
		/// <param name="hash">Torrent hash.</param>
		/// <returns>Torrent properties.</returns>
        public static async Task<TorrentProperties> GetTorrentProperties(string hash)
        {
            HttpResponseMessage reply = await Post(client, "/query/propertiesGeneral/" + hash);

			if (reply == null)
				return null;

			var result = await reply.Content.ReadAsStringAsync();
			if (result == "")
				return null;

			return new TorrentProperties(JsonConvert.DeserializeObject<TorrentPropertiesJSON>(await reply.Content.ReadAsStringAsync()));
        }

		/// <summary>
		/// Gets all trackers of a torrent.
		/// </summary>
		/// <param name="hash">Torrent hash.</param>
		/// <returns>List of trackers.</returns>
        public static async Task<List<Tracker>> GetTorrentTrackers(string hash)
        {
            HttpResponseMessage reply = await Post(client, "/query/propertiesTrackers/" + hash);

			if (reply == null)
				return null;

			var result = await reply.Content.ReadAsStringAsync();
			if (result == "")
				return null;

			var js = JsonConvert.DeserializeObject<List<TrackerJSON>>(await reply.Content.ReadAsStringAsync());
			var trackers = new List<Tracker>();
			foreach (var e in js)
			{
				trackers.Add(new Tracker(e));
			}

			return trackers;
        }

		/// <summary>
		/// Gets all the web seeds of a torrent.
		/// </summary>
		/// <param name="hash">Torrent hash.</param>
		/// <returns>List of web seeds.</returns>
        public static async Task<List<Uri>> GetTorrentWebSeeds(string hash)
        {
            HttpResponseMessage reply = await Post(client, "/query/propertiesWebSeeds/" + hash);

			if (reply == null)
				return null;

			var result = await reply.Content.ReadAsStringAsync();
			if (result == "")
				return null;

			var torrentWebSeeds =  JsonConvert.DeserializeObject<List<TorrentWebSeedJSON>>(await reply.Content.ReadAsStringAsync());
            var urls = new List<Uri>();
            foreach (TorrentWebSeedJSON torrentWebSeed in torrentWebSeeds)
                urls.Add(torrentWebSeed.Url);

            return urls;
        }

		/// <summary>
		/// Gets the contents of a torrent.
		/// </summary>
		/// <param name="hash">Torrent hash,</param>
		/// <returns>Torrent contents.</returns>
        public static async Task<List<TorrentContents>> GetTorrentContents(string hash)
        {
            HttpResponseMessage reply = await Post(client, "/query/propertiesFiles/" + hash);

			if (reply == null)
				return null;

			var result = await reply.Content.ReadAsStringAsync();
			if (result == "")
				return null;

			var array = JsonConvert.DeserializeObject<TorrentContents[]>(await reply.Content.ReadAsStringAsync());
			return new List<TorrentContents>(array);
        }

		/// <summary>
		/// Gets states of torrent pieces.
		/// </summary>
		/// <param name="hash">Torrent hash.</param>
		/// <returns>States of torrent pieces.</returns>
		public static async Task<List<PieceState>> GetTorrentPiecesStates(string hash)
		{
			HttpResponseMessage reply = await Post(client, "/query/getPieceStates/" + hash);

			if (reply == null)
				return null;

			var result = await reply.Content.ReadAsStringAsync();
			if (result == "")
				return null;

			var array = JsonConvert.DeserializeObject<PieceState[]>(await reply.Content.ReadAsStringAsync());
			return new List<PieceState>(array);
		}

		/// <summary>
		/// Gets hashes of all pieces of a torrent.
		/// </summary>
		/// <param name="hash">Torrent hash.</param>
		/// <returns>Hashes of all pieces of a torrent.</returns>
		public static async Task<List<string>> GetTorrentPiecesHashes(string hash)
		{
			HttpResponseMessage reply = await Post(client, "/query/getPieceHashes/" + hash);
			if (reply == null)
				return null;

			var result = await reply.Content.ReadAsStringAsync();
			if (result == "")
				return null;

			var array = JsonConvert.DeserializeObject<string[]>(await reply.Content.ReadAsStringAsync());

			return new List<string>(array);
		}

		/// <summary>
		/// Gets info you usually see in qBittorrent status bar.
		/// </summary>
		/// <returns>Info you usually see in qBittorrent status bar.</returns>
		public static async Task<TransferInfo> GetTransferInfo()
        {
            HttpResponseMessage reply = await Post(client, "/query/transferInfo");

			if (reply == null)
				return null;

			var result = await reply.Content.ReadAsStringAsync();
			if (result == "")
				return null;

			return JsonConvert.DeserializeObject<TransferInfo>(await reply.Content.ReadAsStringAsync());
        }

		/// <summary>
		/// Gets qBittorrent preferences.
		/// </summary>
		/// <returns>qBittorrent preferences.</returns>
		public static async Task<Preferences> GetPreferences()
        {
            HttpResponseMessage reply = await Post(client, "/query/preferences");

			if (reply == null)
				return null;

			var result = await reply.Content.ReadAsStringAsync();
			if (result == "")
				return null;

			return new Preferences(JsonConvert.DeserializeObject<PreferencesJSON>(await reply.Content.ReadAsStringAsync()));
        }

		/// <summary>
		/// Gets changes since last request.
		/// </summary>
		/// <param name="rid">Requst ID.</param>
		/// <returns>Changes since last request.</returns>
		public static async Task<PartialData> GetPartialData(int rid = 0)
        {
            HttpResponseMessage reply = await Post(client, "/sync/maindata?rid=" + rid);

			if (reply == null)
				return null;

			var result = await reply.Content.ReadAsStringAsync();
			if (result == "")
				return null;

			return new PartialData(JsonConvert.DeserializeObject<PartialDataJSON>(await reply.Content.ReadAsStringAsync()));
        }

		/// <summary>
		/// Gets log entries of given states.
		/// </summary>
		/// <param name="normal">Include normal messages.</param>
		/// <param name="info">Include info messages.</param>
		/// <param name="warning">Include warning messages.</param>
		/// <param name="critical">Include critical messages.</param>
		/// <param name="last_known_id">Exclude log entries with id less or equal to this.</param>
		/// <returns>List of log entries.</returns>
		public static async Task<List<Log>> GetLog(bool normal = true, bool info = true, bool warning = true,
                                                bool critical = true, int last_known_id = -1)
        {
            HttpResponseMessage reply = await Post(client, "/query/getLog?normal=" + normal.ToString()
                                                    + "&info=" + info.ToString() + "&warning=" + warning.ToString()
                                                    + "&critical=" + critical.ToString() + "&last_known_id=" + last_known_id);

			if (reply == null)
				return null;

			var result = await reply.Content.ReadAsStringAsync();
			if (result == "")
				return null;

			var logJSONs = JsonConvert.DeserializeObject<List<LogJSON>>(await reply.Content.ReadAsStringAsync());
			var logs = new List<Log>();

			foreach (var e in logJSONs)
				logs.Add(new Log(e));

			return logs;
        }

		/// <summary>
		/// Downloads from URL.
		/// </summary>
		/// <param name="urls">List of URLs.</param>
		/// <param name="savePath">Download folder.</param>
		/// <param name="cookie">Coookie sent to download the .torrent file..</param>
		/// <param name="category">Category for the torrent.</param>
		/// <param name="skipChecking">Skip hash check.</param>
		/// <param name="paused">Add torrents in the paused state.</param>
		/// <param name="rootFolder">Create the root folder.</param>
		/// <param name="rename">Rename torrent.</param>
		/// <param name="upLimit">Set torrent upload speed limit in bytes/second.</param>
		/// <param name="dlLimit">Set torrent download speed limit in bytes/second.</param>
		/// <param name="squentialDownload">Enable sequential download.</param>
		/// <param name="firstLastPiecePrio">Prioritize download first last piece.</param>
		public static async Task DownloadFromUrl(List<Uri> urls, string savePath = null, string cookie = null, string category = null,
                                            bool? skipChecking = null, bool? paused = null, bool? rootFolder = null,
											string rename = null, int? upLimit = null, int? dlLimit = null,
											string squentialDownload = null, bool? firstLastPiecePrio = null)
        {
			var form = new MultipartFormDataContent();
			form.Add(new StringContent(ListToString(urls, '\n')), "urls");

			if (savePath != null)
				form.Add(new StringContent(savePath), "savepath");

			if (cookie != null)
				form.Add(new StringContent(cookie), "cookie");

			if (category != null)
				form.Add(new StringContent(category), "category");

			if (skipChecking != null)
				form.Add(new StringContent(skipChecking.ToString().ToLower()), "skip_checking");

			if (paused != null)
				form.Add(new StringContent(paused.ToString().ToLower()), "paused");

			if (rootFolder != null)
				form.Add(new StringContent(rootFolder.ToString().ToLower()), "root_folder");

			if (rename != null)
				form.Add(new StringContent(rename), "rename");

			if (upLimit != null)
				form.Add(new StringContent(upLimit.ToString()), "upLimit");

			if (dlLimit != null)
				form.Add(new StringContent(dlLimit.ToString()), "dlLimit");

			if (squentialDownload != null)
				form.Add(new StringContent(squentialDownload), "squentialDownload");

			if (firstLastPiecePrio != null)
				form.Add(new StringContent(firstLastPiecePrio.ToString().ToLower()), "firstLastPiecePrio");

			await Post(client, "/command/download", form);
        }

		/// <summary>
		/// Downloads from disk.
		/// </summary>
		/// <param name="filePaths">List of URLs.</param>
		/// <param name="savePath">Download folder.</param>
		/// <param name="cookie">Coookie sent to download the .torrent file..</param>
		/// <param name="category">Category for the torrent.</param>
		/// <param name="skipChecking">Skip hash check.</param>
		/// <param name="paused">Add torrents in the paused state.</param>
		/// <param name="rootFolder">Create the root folder.</param>
		/// <param name="rename">Rename torrent.</param>
		/// <param name="upLimit">Set torrent upload speed limit in bytes/second.</param>
		/// <param name="dlLimit">Set torrent download speed limit in bytes/second.</param>
		/// <param name="squentialDownload">Enable sequential download.</param>
		/// <param name="firstLastPiecePrio">Prioritize download first last piece.</param>
		public static async Task DownloadFromDisk(List<string> filePaths, string savePath = null, string cookie = null, string category = null,
											bool? skipChecking = null, bool? paused = null, bool? rootFolder = null,
											string rename = null, int? upLimit = null, int? dlLimit = null,
											string squentialDownload = null, bool? firstLastPiecePrio = null)
		{
			var form = new MultipartFormDataContent();

			foreach (string filePath in filePaths)
			{
				string filename = Path.GetFileName(filePath);
				var content = File.ReadAllBytes(filePath);
				form.Add(new ByteArrayContent(content), "torrents", filename);
			}

			if (savePath != null)
				form.Add(new StringContent(savePath), "savepath");

			if (cookie != null)
				form.Add(new StringContent(cookie), "cookie");

			if (category != null)
				form.Add(new StringContent(category), "category");

			if (skipChecking != null)
				form.Add(new StringContent(skipChecking.ToString().ToLower()), "skip_checking");

			if (paused != null)
				form.Add(new StringContent(paused.ToString().ToLower()), "paused");

			if (rootFolder != null)
				form.Add(new StringContent(rootFolder.ToString().ToLower()), "root_folder");

			if (rename != null)
				form.Add(new StringContent(rename), "rename");

			if (upLimit != null)
				form.Add(new StringContent(upLimit.ToString()), "upLimit");

			if (dlLimit != null)
				form.Add(new StringContent(dlLimit.ToString()), "dlLimit");

			if (squentialDownload != null)
				form.Add(new StringContent(squentialDownload), "squentialDownload");

			if (firstLastPiecePrio != null)
				form.Add(new StringContent(firstLastPiecePrio.ToString().ToLower()), "firstLastPiecePrio");

			await Post(client, "/command/upload", form);
		}

		/// <summary>
		/// Adds trackers to torrent.
		/// </summary>
		/// <param name="hash">Torrent hash.</param>
		/// <param name="trackers">Trackers to be added.</param>
		public static async Task AddTrackers(string hash, List<Uri> trackers)
		{
			var content = ToStringContent("hash=" + hash + "&urls=" + ListToString(trackers, '\n'));
			await Post(client, "/command/addTrackers", content);
		}

		/// <summary>
		/// Pauses torrent.
		/// </summary>
		/// <param name="hash">Torrent hash.</param>
		public static async Task PauseTorrent(string hash)
		{
			var content = ToStringContent("hash=" + hash);
			await Post(client, "/command/pause", content);
		}

		/// <summary>
		/// Pauses all torrents.
		/// </summary>
		public static async Task PauseAll()
        {
            await Post(client, "/command/pauseAll");
        }

		/// <summary>
		/// Resumes torrent.
		/// </summary>
		/// <param name="hash">Torrent hash.</param>
		public static async Task ResumeTorrent(string hash)
		{
			var content = ToStringContent("hash=" + hash);
			await Post(client, "/command/resume", content);
		}

		/// <summary>
		/// Resumes all torrents.
		/// </summary>
		public static async Task ResumeAll()
		{
			await Post(client, "/command/resumeAll");
		}

		/// <summary>
		/// Deletes torrents.
		/// </summary>
		/// <param name="hashes">Hashes of torrents to be deleted.</param>
		/// <param name="deleteData">Delete downloaded data.</param>
		public static async Task DeleteTorrents(List<string> hashes, bool deleteData = false)
		{
			var content = ToStringContent("hashes=" + ListToString(hashes, '|'));

			if (deleteData)
				await Post(client, "/command/deletePerm", content);

			else
				await Post(client, "/command/delete", content);
		}

		/// <summary>
		/// Rechecks torrent.
		/// </summary>
		/// <param name="hash">Torrent hash.</param>
		public static async Task RecheckTorrent(string hash)
		{
			var content = ToStringContent("hash=" + hash);
			await Post(client, "/command/recheck", content);
		}

		/// <summary>
		/// Increases priority of torrents. Torrent Queing needs to be enabled.
		/// </summary>
		/// <param name="hashes">Torrent hashes.</param>
		public static async Task IncreaseTorrentPriority(List<string> hashes)
		{
			var content = ToStringContent("hashes=" + ListToString(hashes, '|'));
			await Post(client, "/command/increasePrio", content);
		}

		/// <summary>
		/// Decreases priority of torrents. Torrent Queing needs to be enabled.
		/// </summary>
		/// <param name="hashes">Torrent hashes.</param>
		public static async Task DecreaseTorrentPriority(List<string> hashes)
		{
			var content = ToStringContent("hashes=" + ListToString(hashes, '|'));
			await Post(client, "/command/decreasePrio", content);
		}

		/// <summary>
		/// Sets maximum priority of torrents. Torrent Queing needs to be enabled.
		/// </summary>
		/// <param name="hashes">Torrent hashes.</param>
		public static async Task MaxTorrentPriority(List<string> hashes)
		{
			var content = ToStringContent("hashes=" + ListToString(hashes, '|'));
			await Post(client, "/command/topPrio", content);
		}

		/// <summary>
		/// Sets minimum priority of torrents. Torrent Queing needs to be enabled.
		/// </summary>
		/// <param name="hashes">Torrent hashes.</param>
		public static async Task MinTorrentPriority(List<string> hashes)
		{
			var content = ToStringContent("hashes=" + ListToString(hashes, '|'));
			await Post(client, "/command/bottomPrio", content);
		}

		/// <summary>
		/// Sets file priority.
		/// </summary>
		/// <param name="hash">Torren hashes.</param>
		/// <param name="fileId">File id.</param>
		/// <param name="priority">File priority.</param>
		/// <returns></returns>
		public static async Task SetFilePriority(string hash, int fileId, Priority priority)
		{
			var content = ToStringContent("hash=" + hash + "&id=" + fileId.ToString() + "&priority=" + ((int)priority).ToString());
			await Post(client, "/command/setFilePrio", content);
		}

		/// <summary>
		/// Gets global download speed limit.
		/// </summary>
		/// <returns>Global download speed limit in bytes/second; this value will be zero if no limit is applied.</returns>
		public static async Task<int> GetGlobalDownloadSpeedLimit()
		{
			HttpResponseMessage reply = await Post(client, "/command/getGlobalDlLimit");

			return Int32.Parse(await reply.Content.ReadAsStringAsync());
		}

		/// <summary>
		/// Sets global download speed limit.
		/// </summary>
		/// <param name="limit">Global download speed limit in bytes/second.</param>
		public static async Task SetGlobalDownloadSpeedLimit(long limit)
		{
			var content = ToStringContent("limit=" + limit.ToString());
			await Post(client, "/command/setGlobalDlLimit", content);
		}

		/// <summary>
		/// Getg global upload speed limit.
		/// </summary>
		/// <returns>Global upload speed limit in bytes/second; this value will be zero if no limit is applied.</returns>
		public static async Task<int> GetGlobalUploadSpeedLimit()
		{
			HttpResponseMessage reply = await Post(client, "/command/getGlobalUpLimit");

			return Int32.Parse(await reply.Content.ReadAsStringAsync());
		}

		/// <summary>
		/// Sets global upload speed limit.
		/// </summary>
		/// <param name="limit">Global upload speed limit in bytes/second.</param>
		public static async Task SetGlobalUploadSpeedLimit(long limit)
		{
			var content = ToStringContent("limit=" + limit.ToString());
			await Post(client, "/command/setGlobalUpLimit", content);
		}

		/// <summary>
		/// Get download speed limit of torrents.
		/// </summary>
		/// <returns>Download speed limit of torrents in bytes/second.</returns>
		public static async Task<List<KeyValuePair<string, int>>> GetTorrentDownloadSpeedLimit(List<string> hashes)
		{
			var content = ToStringContent("hashes=" + ListToString(hashes, '|'));
			var reply = await Post(client, "/command/getTorrentsDlLimit", content);
			var objectList = JsonConvert.DeserializeObject<object>(await reply.Content.ReadAsStringAsync());

			var torrentDlLimits = new List<KeyValuePair<string, int>>();
			var properties = (objectList as ICollection).GetEnumerator();
			while (properties.MoveNext())
			{
				JProperty property = (JProperty)properties.Current;
				torrentDlLimits.Add(new KeyValuePair<string, int>(property.Name, (int)property.Value));
			}

			return torrentDlLimits;
		}

		/// <summary>
		/// Sets download speed limit of torrents.
		/// </summary>
		/// <param name="hashes">Torrent hashes.</param>
		/// <param name="limit">Download speed limit of torrents in bytes/second.</param>
		public static async Task SetTorrentDownloadSpeedLimit(List<string> hashes, int limit)
		{
			var content = ToStringContent("hashes=" + ListToString(hashes, '|') + "&limit=" + limit.ToString());
			await Post(client, "/command/setTorrentsDlLimit", content);
		}

		/// <summary>
		/// Gets upload speed limit of torrents.
		/// </summary>
		/// <returns>Upload speed limit of torrents in bytes/second.</returns>
		public static async Task<List<KeyValuePair<string, int>>> GetTorrentUploadSpeedLimit(List<string> hashes)
		{
			var content = ToStringContent("hashes=" + ListToString(hashes, '|'));
			var reply = await Post(client, "/command/getTorrentsUpLimit", content);
			var objectList = JsonConvert.DeserializeObject<object>(await reply.Content.ReadAsStringAsync());

			var torrentUpLimits = new List<KeyValuePair<string, int>>();
			var properties = (objectList as ICollection).GetEnumerator();
			while (properties.MoveNext())
			{
				JProperty property = (JProperty)properties.Current;
				torrentUpLimits.Add(new KeyValuePair<string, int>(property.Name, (int)property.Value));
			}

			return torrentUpLimits;
		}

		/// <summary>
		/// Sets upload speed limit of torrents.
		/// </summary>
		/// <param name="hashes">Torrent hashes.</param>
		/// <param name="limit">Upload speed limit of torrents.</param>
		public static async Task SetTorrentUploadSpeedLimit(List<string> hashes, int limit)
		{
			var content = ToStringContent("hashes=" + ListToString(hashes, '|') + "&limit=" + limit.ToString());
			await Post(client, "/command/setTorrentsUpLimit", content);
		}

		/// <summary>
		/// Sets location of torrents.
		/// </summary>
		/// <param name="hashes">Torrent hashes.</param>
		/// <param name="location">Torrent location.</param>
		public static async Task SetTorrentsLocation(List<string> hashes, string location)
		{
			var content = ToStringContent("hashes=" + ListToString(hashes, '|') + "&location=" + location);
			await Post(client, "/command/setLocation", content);
		}

		/// <summary>
		/// Sets name of torrents.
		/// </summary>
		/// <param name="hash">Torrent hash.</param>
		/// <param name="name">Torrent name.</param>
		public static async Task SetTorrentName(string hash, string name)
		{
			var content = ToStringContent("hash=" + hash + "&name=" + name);
			await Post(client, "/command/rename", content);
		}

		/// <summary>
		/// Sets category of torrents.
		/// </summary>
		/// <param name="hashes">Torrent hashes.</param>
		/// <param name="categoryName">Name of category.</param>
		public static async Task SetTorrentCategory(List<string> hashes, string categoryName)
		{
			var content = ToStringContent("hashes=" + ListToString(hashes, '|') + "&category=" + categoryName);
			await Post(client, "/command/setCategory", content);
		}

		/// <summary>
		/// Adds new category.
		/// </summary>
		/// <param name="categoryName">Category name.</param>
		/// <returns></returns>
		public static async Task AddNewCategory(string categoryName)
		{
			var content = ToStringContent("category=" + categoryName);
			await Post(client, "/command/setCategory", content);
		}

		/// <summary>
		/// Removes category.
		/// </summary>
		/// <param name="categoryNames">Category name.</param>
		/// <returns></returns>
		public static async Task RemoveCategories(List<string> categoryNames)
		{
			var content = ToStringContent("categories=" + ListToString(categoryNames, '\n'));
			await Post(client, "/command/removeCategories", content);
		}

		/// <summary>
		/// Sets automatic torrent management.
		/// </summary>
		/// <param name="hashes">Torrent hashes.</param>
		/// <param name="autoTorrentMgmt">Automatic torrent management.</param>
		/// <returns></returns>
		public static async Task SetAutoTorrentMgmt(List<string> hashes, bool autoTorrentMgmt)
		{
			var content = ToStringContent("hashes=" + ListToString(hashes, '|') + "&enable=" + autoTorrentMgmt.ToString().ToLower());
			await Post(client, "/command/setAutoTMM", content);
		}

		/// <summary>
		/// Sets qBittorrent preferences.
		/// </summary>
		/// <param name="preferences">qBittorrent preferences.</param>
		public static async Task SetPreferences(Preferences preferences)
		{
			var jsonObject = JsonConvert.SerializeObject(new PreferencesJSON(preferences),
														Formatting.None,
														new JsonSerializerSettings
														{
															NullValueHandling = NullValueHandling.Ignore
														});
			var content = ToStringContent("json=" + jsonObject);
			await Post(client, "/command/setPreferences", content);
		}

		/// <summary>
		/// Gets the state of the alternative speed limits.
		/// </summary>
		/// <returns>True if alternative speed limits is enabled.</returns>
		public static async Task<bool> IsAltSpeedLimitsEnabled()
		{
			HttpResponseMessage reply = await Post(client, "/command/alternativeSpeedLimitsEnabled");

			if (Int32.Parse(await reply.Content.ReadAsStringAsync()) == 1)
				return true;

			return false;
		}

		/// <summary>
		/// Toggles the state of the alternative speed limits.
		/// </summary>
		public static async Task ToggleAltSpeedLimits()
		{
			await Post(client, "/command/toggleAlternativeSpeedLimits");
		}

		/// <summary>
		/// Toggles sequential download.
		/// </summary>
		/// <param name="hashes">Torrent hashes.</param>
		public static async Task ToggleSequentialDownload(List<string> hashes)
		{
			var content = ToStringContent("hashes=" + ListToString(hashes, '|'));
			await Post(client, "/command/toggleSequentialDownload", content);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="hashes"></param>
		/// <returns></returns>
		public static async Task ToggleFirstLastPiecePrio(List<string> hashes)
		{
			var content = ToStringContent("hashes=" + ListToString(hashes, '|'));
			await Post(client, "/command/toggleFirstLastPiecePrio", content);
		}

		/// <summary>
		/// Sets first/last piece priority of torrents.
		/// </summary>
		/// <param name="hashes">Torrent hashes.</param>
		/// <param name="activate">Whether to activate first/last piece priority of torrents.</param>
		public static async Task SetForceStart(List<string> hashes, bool activate)
		{
			var content = ToStringContent("hashes=" + ListToString(hashes, '|') + "&value=" + activate.ToString().ToLower());
			await Post(client, "/command/setForceStart", content);
		}

		/// <summary>
		/// Sets super seeding of torrents.
		/// </summary>
		/// <param name="hashes">Torrent hashes.</param>
		/// <param name="activate">Whether to activate super seeding of torrents.</param>
		/// <returns></returns>
		public static async Task SetSuperSeeding(List<string> hashes, bool activate)
		{
			var content = ToStringContent("hashes=" + ListToString(hashes, '|') + "&value=" + activate.ToString().ToLower());
			await Post(client, "/command/setSuperSeeding", content);
		}

		private static void RaiseDisconnectedEvent()
		{
			Disconnected?.Invoke(typeof(API), EventArgs.Empty);
		}
	}
}
