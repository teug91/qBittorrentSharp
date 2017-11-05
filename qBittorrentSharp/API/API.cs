using Newtonsoft.Json.Linq;
using qBittorrentSharp.JSON;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace qBittorrentSharp
{
    public class API
    {
        public static List<Torrent> ToTorrent(PartialData partialData)
        {
            var torrents = new List<Torrent>();
            var collection = partialData.Torrents as ICollection;

            var ts = collection.GetEnumerator();

            while (ts.MoveNext())
            {
                Torrent torrent = new Torrent();
                JProperty o = (JProperty) ts.Current;
                torrent.Hash = o.Name;

                //o.

                //int i = 0;
            }

            return torrents;
        }
    }
}
