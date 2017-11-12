using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace qBittorrentSharp
{
	public partial class API
	{
		/// <summary>
		/// Deletes torrents that have seeded longer than maximum time.
		/// </summary>
		/// <param name="maxSeedTime">Maximum time of seeding.</param>
		/// <param name="deleteData">Delete data if True.</param>
		public async Task DeleteAfterMaxSeedTime(TimeSpan maxSeedTime, bool deleteData)
		{
			var torrents = await GetTorrents();
			var hashes = new List<string>();

			foreach (var torrent in torrents)
			{
				var seedingTimeSpan = (await GetTorrentProperties(torrent.Hash)).Seeding_Time;
				if (seedingTimeSpan != null)
				{
					if (seedingTimeSpan > maxSeedTime)
					{
						hashes.Add(torrent.Hash);
					}
				}
			}

			await DeleteTorrents(hashes, deleteData);
		}
	}
}
