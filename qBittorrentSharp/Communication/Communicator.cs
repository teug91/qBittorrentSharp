using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using qBittorrentSharp.JSON;
using System.Diagnostics;
using System.IO;
using qBittorrentSharp.Enums;
using Newtonsoft.Json.Linq;

namespace qBittorrentSharp
{
    public partial class Communicator
    {
        private HttpClient client;

        public Communicator(string baseAddress, int timeout = 100)
        {
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

        public async Task<bool?> Login(string username, string password)
        {
            var content = new[]
            {
                new KeyValuePair<string, string>("username", username),
                new KeyValuePair<string, string>("password", password)
            };

            var reply = await Post(client, "/login", new FormUrlEncodedContent(content));

            if (reply == null)
                return null;

            var result = await reply.Content.ReadAsStringAsync();

            if (result == "Ok.")
                return true;

            return false;
        }

        public async Task Logout()
        {
            await Post(client, "/logout");
        }

        public async Task<int> GetApiVersion()
        {
            var reply = await Post(client, "/version/api");
            return Int32.Parse(await reply.Content.ReadAsStringAsync());
        }

        public async Task<int> GetMinApiVersion()
        {
            var reply = await Post(client, "/version/api_min");
            return Int32.Parse(await reply.Content.ReadAsStringAsync());
        }

        public async Task<string> GetQbittorrentVersion()
        {
            var reply = await Post(client, "/version/qbittorrent");
            return await reply.Content.ReadAsStringAsync();
        }

        public async Task ShutdownQbittorrent()
        {
            await Post(client, "/command/shutdown");
        }

        public async Task<List<TorrentInfo>> GetTorrents(string filter = null,
                                                            string category = null,
                                                            string sort = null,
                                                            bool reverse = false,
                                                            int limit = 0,
                                                            int offset = 0)
        {
            HttpResponseMessage reply;
            var parameters = "?";

            if (filter != null)
                parameters += "filter=" + filter + "&";

            if (category != null)
                parameters += "category=" + category + "&";

            if (sort != null)
                parameters += "sort=" + sort + "&";

            if (reverse != false)
                parameters += "reverse=" + reverse.ToString() + "&";

            if (limit != 0)
                parameters += "limit=" + limit + "&";

            if (offset != 0)
                parameters += "offset=" + offset + "&";

            if (parameters != "?")
            {
                parameters = parameters.Remove(parameters.Length - 1);
                reply = await Post(client, "/query/torrents" + parameters);

            }

            else
                reply = await Post(client, "/query/torrents");

            if (reply == null)
                return null;

            return JsonConvert.DeserializeObject<List<TorrentInfo>>(await reply.Content.ReadAsStringAsync());
        }

        public async Task<TorrentProperties> GetTorrentProperties(string hash)
        {
            HttpResponseMessage reply = await Post(client, "/query/propertiesGeneral/" + hash);

            if (reply == null)
                return null;

            return JsonConvert.DeserializeObject<TorrentProperties>(await reply.Content.ReadAsStringAsync());
        }

        public async Task<List<TorrentTracker>> GetTorrentTrackers(string hash)
        {
            HttpResponseMessage reply = await Post(client, "/query/propertiesTrackers/" + hash);

            if (reply == null)
                return null;

            return JsonConvert.DeserializeObject<List<TorrentTracker>>(await reply.Content.ReadAsStringAsync());
        }

        public async Task<List<Uri>> GetTorrentWebSeeds(string hash)
        {
            HttpResponseMessage reply = await Post(client, "/query/propertiesWebSeeds/" + hash);

            if (reply == null)
                return null;

            var torrentWebSeeds =  JsonConvert.DeserializeObject<List<TorrentWebSeed>>(await reply.Content.ReadAsStringAsync());
            var urls = new List<Uri>();
            foreach (TorrentWebSeed torrentWebSeed in torrentWebSeeds)
                urls.Add(torrentWebSeed.Url);

            return urls;
        }

        public async Task<List<TorrentContents>> GetTorrentContents(string hash)
        {
            HttpResponseMessage reply = await Post(client, "/query/propertiesFiles/" + hash);

            var result = await reply.Content.ReadAsStringAsync();

            if (reply == null)
                return null;

            var array = JsonConvert.DeserializeObject<TorrentContents[]>(await reply.Content.ReadAsStringAsync());
			return new List<TorrentContents>(array);
        }

		public async Task<List<PieceStates>> GetTorrentPiecesStates(string hash)
		{
			HttpResponseMessage reply = await Post(client, "/query/getPieceStates/" + hash);

			var result = await reply.Content.ReadAsStringAsync();

			if (reply == null)
				return null;

			var array = JsonConvert.DeserializeObject<PieceStates[]>(await reply.Content.ReadAsStringAsync());
			return new List<PieceStates>(array);
		}

		public async Task<TransferInfo> GetTransferInfo()
        {
            HttpResponseMessage reply = await Post(client, "/query/transferInfo");

            if (reply == null)
                return null;

            return JsonConvert.DeserializeObject<TransferInfo>(await reply.Content.ReadAsStringAsync());
        }

        public async Task<PreferencesJSON> GetPreferences()
        {
            HttpResponseMessage reply = await Post(client, "/query/preferences");

            if (reply == null)
                return null;

			return JsonConvert.DeserializeObject<PreferencesJSON>(await reply.Content.ReadAsStringAsync());
        }

        public async Task<PartialData> GetPartialData(int rid = 0)
        {
            HttpResponseMessage reply = await Post(client, "/sync/maindata?rid=" + rid);

            if (reply == null)
                return null;

            //API.ToTorrent(JsonConvert.DeserializeObject<PartialData>(await reply.Content.ReadAsStringAsync()));

            return JsonConvert.DeserializeObject<PartialData>(await reply.Content.ReadAsStringAsync());
        }

        public async Task<List<Log>> GetLog(bool normal = true, bool info = true, bool warning = true,
                                                bool critical = true, int last_known_id = -1)
        {
            HttpResponseMessage reply = await Post(client, "/query/getLog?normal=" + normal.ToString()
                                                    + "&info=" + info.ToString() + "&warning=" + warning.ToString()
                                                    + "&critical=" + critical.ToString() + "&last_known_id=" + last_known_id);

            if (reply == null)
                return null;

            return JsonConvert.DeserializeObject<List<Log>>(await reply.Content.ReadAsStringAsync());
        }

        public async Task DownloadFromUrl(List<Uri> urls, string savePath = null, string cookie = null, string category = null,
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

		public async Task DownloadFromDisk(List<string> filePaths, string savePath = null, string cookie = null, string category = null,
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
				int i = 0;
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

		public async Task AddTrackers(string hash, List<Uri> trackers)
		{
			/*string trackersString = "";
			foreach (Uri tracker in trackers)
				trackersString += tracker.ToString() + "\n";
			trackersString = trackersString.Remove(trackersString.Length - 1);*/

			var content = new[]
			{
				new KeyValuePair<string, string>("hash", hash),
				new KeyValuePair<string, string>("urls", ListToString(trackers, '\n'))
			};

			await Post(client, "/command/addTrackers", new FormUrlEncodedContent(content));
		}

		public async Task PauseTorrent(string hash)
		{
			var content = new[]
			{
				new KeyValuePair<string, string>("hash", hash)
			};

			await Post(client, "/command/pause", new FormUrlEncodedContent(content));
		}

		public async Task PauseAll()
        {
            await Post(client, "/command/pauseAll");
        }

		public async Task ResumeTorrent(string hash)
		{
			var content = new[]
			{
				new KeyValuePair<string, string>("hash", hash)
			};

			await Post(client, "/command/resume", new FormUrlEncodedContent(content));
		}

		public async Task ResumeAll()
		{
			await Post(client, "/command/resumeAll");
		}

		public async Task DeleteTorrents(List<string> hashes, bool deleteData = false)
		{
			var content = new[]
			{
				new KeyValuePair<string, string>("hashes", ListToString(hashes, '|'))
			};

			if (deleteData)
				await Post(client, "/command/deletePerm", new FormUrlEncodedContent(content));

			else
				await Post(client, "/command/delete", new FormUrlEncodedContent(content));
		}

		public async Task RecheckTorrent(string hash)
		{
			var content = new[]
			{
				new KeyValuePair<string, string>("hash", hash)
			};

			await Post(client, "/command/recheck", new FormUrlEncodedContent(content));
		}

		// Torrent Queing needs to be enabled
		public async Task IncreaseTorrentPriority(List<string> hashes)
		{
			var content = new[]
			{
				new KeyValuePair<string, string>("hashes", ListToString(hashes, '|'))
			};

			await Post(client, "/command/increasePrio", new FormUrlEncodedContent(content));
		}

		// Torrent Queing needs to be enabled
		public async Task DecreaseTorrentPriority(List<string> hashes)
		{
			var content = new[]
			{
				new KeyValuePair<string, string>("hashes", ListToString(hashes, '|'))
			};

			await Post(client, "/command/decreasePrio", new FormUrlEncodedContent(content));
		}

		// Torrent Queing needs to be enabled
		public async Task MaxTorrentPriority(List<string> hashes)
		{
			var content = new[]
			{
				new KeyValuePair<string, string>("hashes", ListToString(hashes, '|'))
			};

			await Post(client, "/command/topPrio", new FormUrlEncodedContent(content));
		}

		// Torrent Queing needs to be enabled
		public async Task MinTorrentPriority(List<string> hashes)
		{
			var content = new[]
			{
				new KeyValuePair<string, string>("hashes", ListToString(hashes, '|'))
			};

			await Post(client, "/command/bottomPrio", new FormUrlEncodedContent(content));
		}

		public async Task SetFilePriority(string hash, int fileId, Priority priority)
		{
			var content = new[]
			{
				new KeyValuePair<string, string>("hash", hash),
				new KeyValuePair<string, string>("id", fileId.ToString()),
				new KeyValuePair<string, string>("priority", ((int)priority).ToString())
			};

			await Post(client, "/command/setFilePrio", new FormUrlEncodedContent(content));
		}

		public async Task<int> GetGlobalDownloadLimit()
		{
			HttpResponseMessage reply = await Post(client, "/command/getGlobalDlLimit");

			return Int32.Parse(await reply.Content.ReadAsStringAsync());
		}

		public async Task SetGlobalDownloadLimit(int limit)
		{
			var content = new[]
			{
				new KeyValuePair<string, string>("limit", limit.ToString())
			};

			await Post(client, "/command/setGlobalDlLimit", new FormUrlEncodedContent(content));
		}

		public async Task<int> GetGlobalUploadLimit()
		{
			HttpResponseMessage reply = await Post(client, "/command/getGlobalUpLimit");

			return Int32.Parse(await reply.Content.ReadAsStringAsync());
		}

		public async Task SetGlobalUploadLimit(int limit)
		{
			var content = new[]
			{
				new KeyValuePair<string, string>("limit", limit.ToString())
			};

			await Post(client, "/command/setGlobalUpLimit", new FormUrlEncodedContent(content));
		}

		public async Task<List<KeyValuePair<string, int>>> GetTorrentDownloadLimit(List<string> hashes)
		{
			var content = new[]
			{
				new KeyValuePair<string, string>("hashes", ListToString(hashes, '|'))
			};

			var reply = await Post(client, "/command/getTorrentsDlLimit", new FormUrlEncodedContent(content));
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

		public async Task SetTorrentDownloadLimit(List<string> hashes, int limit)
		{
			var content = new[]
			{
				new KeyValuePair<string, string>("hashes", ListToString(hashes, '|')),
				new KeyValuePair<string, string>("limit", limit.ToString())
			};

			await Post(client, "/command/setTorrentsDlLimit", new FormUrlEncodedContent(content));
		}

		public async Task<List<KeyValuePair<string, int>>> GetTorrentUploadLimit(List<string> hashes)
		{
			var content = new[]
			{
				new KeyValuePair<string, string>("hashes", ListToString(hashes, '|'))
			};

			var reply = await Post(client, "/command/getTorrentsUpLimit", new FormUrlEncodedContent(content));
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

		public async Task SetTorrentUploadLimit(List<string> hashes, int limit)
		{
			var content = new[]
			{
				new KeyValuePair<string, string>("hashes", ListToString(hashes, '|')),
				new KeyValuePair<string, string>("limit", limit.ToString())
			};

			await Post(client, "/command/setTorrentsUpLimit", new FormUrlEncodedContent(content));
		}

		public async Task SetTorrentsLocation(List<string> hashes, string location)
		{
			var content = new[]
			{
				new KeyValuePair<string, string>("hashes", ListToString(hashes, '|')),
				new KeyValuePair<string, string>("location", location)
			};

			await Post(client, "/command/setLocation", new FormUrlEncodedContent(content));
		}

		public async Task SetTorrentName(string hash, string name)
		{
			var content = new[]
			{
				new KeyValuePair<string, string>("hash", hash),
				new KeyValuePair<string, string>("name", name)
			};

			await Post(client, "/command/rename", new FormUrlEncodedContent(content));
		}

		public async Task SetTorrentCategory(List<string> hashes, string categoryName)
		{
			var content = new[]
			{
				new KeyValuePair<string, string>("hashes", ListToString(hashes, '|')),
				new KeyValuePair<string, string>("category", categoryName)
			};

			await Post(client, "/command/setCategory", new FormUrlEncodedContent(content));
		}

		public async Task AddNewCategory(string categoryName)
		{
			var content = new[]
			{
				new KeyValuePair<string, string>("category", categoryName)
			};

			await Post(client, "/command/setCategory", new FormUrlEncodedContent(content));
		}

		public async Task RemoveCategories(List<string> categoryNames)
		{
			var content = new[]
			{
				new KeyValuePair<string, string>("categories", ListToString(categoryNames, '\n')),
			};

			await Post(client, "/command/removeCategories", new FormUrlEncodedContent(content));
		}

		public async Task SetAutoTorrentMgmt(List<string> hashes, bool autoTorrentMgmt)
		{
			var content = new[]
			{
				new KeyValuePair<string, string>("hashes", ListToString(hashes, '|')),
				new KeyValuePair<string, string>("enable", autoTorrentMgmt.ToString().ToLower())
			};

			await Post(client, "/command/setAutoTMM", new FormUrlEncodedContent(content));
		}

		public async Task SetPreferences(PreferencesJSON preferences)
		{
			var jsonObject = JsonConvert.SerializeObject(preferences,
														Formatting.None,
														new JsonSerializerSettings
														{
															NullValueHandling = NullValueHandling.Ignore
														});
			var content = new[]
			{
				new KeyValuePair<string, string>("json", jsonObject)
			};

			await Post(client, "/command/setPreferences", new FormUrlEncodedContent(content));
		}

		public async Task<bool> IsAltSpeedLimitsEnabled()
		{
			HttpResponseMessage reply = await Post(client, "/command/alternativeSpeedLimitsEnabled");

			if (Int32.Parse(await reply.Content.ReadAsStringAsync()) == 1)
				return true;

			return false;
		}

		public async Task ToggleAltSpeedLimits()
		{
			await Post(client, "/command/toggleAlternativeSpeedLimits");
		}

		public async Task ToggleSequentialDownload(List<string> hashes)
		{
			var content = new[]
			{
				new KeyValuePair<string, string>("hashes", ListToString(hashes, '|'))
			};

			await Post(client, "/command/toggleSequentialDownload", new FormUrlEncodedContent(content));
		}

		public async Task ToggleFirstLastPiecePrio(List<string> hashes)
		{
			var content = new[]
			{
				new KeyValuePair<string, string>("hashes", ListToString(hashes, '|'))
			};

			await Post(client, "/command/toggleFirstLastPiecePrio", new FormUrlEncodedContent(content));
		}

		public async Task SetForceStart(List<string> hashes, bool activate)
		{
			var content = new[]
			{
				new KeyValuePair<string, string>("hashes", ListToString(hashes, '|')),
				new KeyValuePair<string, string>("value", activate.ToString().ToLower())
			};

			await Post(client, "/command/setForceStart", new FormUrlEncodedContent(content));
		}

		public async Task SetSuperSeeding(List<string> hashes, bool activate)
		{
			var content = new[]
			{
				new KeyValuePair<string, string>("hashes", ListToString(hashes, '|')),
				new KeyValuePair<string, string>("value", activate.ToString().ToLower())
			};

			await Post(client, "/command/setSuperSeeding", new FormUrlEncodedContent(content));
		}
	}
}
