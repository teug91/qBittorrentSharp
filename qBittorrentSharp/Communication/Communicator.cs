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

        /*public async Task<TorrentContents> GetTorrentContents(string hash)
        {
            HttpResponseMessage reply = await Base.Post(client, "/query/propertiesFiles/" + hash);

            var result = await reply.Content.ReadAsStringAsync();

            if (reply == null)
                return null;

            return JsonConvert.DeserializeObject<TorrentContents>(await reply.Content.ReadAsStringAsync());
        }*/

        /*public async Task<PieceStates[]> GetTorrentPiecesStates(string hash)
        {
            HttpResponseMessage reply = await Base.Post(client, "/query/getPieceStates/" + hash);

            if (reply == null)
                return null;

            var result = await reply.Content.ReadAsStringAsync();

            string[] array = result.Split(',');

            var piecesStates = new PieceStates[array.Length];

            int i = 0;

            foreach (var item in array)
            {
                if (item.Contains(']'))
                {
                    piecesStates[i] = (PieceStates)item[0];
                    i++;
                }
            }

            return piecesStates;
        }*/

        public async Task<TransferInfo> GetTransferInfo()
        {
            HttpResponseMessage reply = await Post(client, "/query/transferInfo");

            if (reply == null)
                return null;

            return JsonConvert.DeserializeObject<TransferInfo>(await reply.Content.ReadAsStringAsync());
        }

        public async Task<Preferences> GetPreferences()
        {
            HttpResponseMessage reply = await Post(client, "/query/preferences");

            if (reply == null)
                return null;

            return JsonConvert.DeserializeObject<Preferences>(await reply.Content.ReadAsStringAsync());
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

        public async Task PauseAll()
        {
            await Post(client, "/command/pauseAll");
        }
    }
}
