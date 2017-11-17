using qBittorrentSharp.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace qBittorrentSharp
{
	public static partial class API
	{
		/// <summary>
		/// Deletes torrents that have seeded longer than maximum time.
		/// </summary>
		/// <param name="maxSeedTime">Maximum time of seeding.</param>
		/// <param name="deleteData">Delete data if True.</param>
		public static async Task DeleteAfterMaxSeedTime(TimeSpan maxSeedTime, bool deleteData)
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

		/// <summary>
		/// Checks if all torrents are paused.
		/// </summary>
		/// <returns>
		/// Returns false if any torrents are not paused.
		/// </returns>
		public static async Task<bool> AreAllTorrentsPaused()
		{
			var torrents = await GetTorrents();

			foreach (var torrent in torrents)
			{
				if (torrent.State != TorrentState.PausedDL || torrent.State != TorrentState.PausedUP)
					return false;
			}

			return true;
		}
	}
}
