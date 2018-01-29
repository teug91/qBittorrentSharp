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

			if (torrents == null)
				return;

			if (torrents.Count == 0)
				return;

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

			if (hashes.Count != 0)
				await DeleteTorrents(hashes, deleteData);
		}

		/// <summary>
		/// Checks if all torrents are paused.
		/// </summary>
		/// <returns>
		/// Returns false if any torrents are not paused.
		/// </returns>
		public static async Task<bool?> AreAllTorrentsPaused()
		{
			var torrents = await GetTorrents();

			if (torrents == null)
				return null;


				foreach (var torrent in torrents)
					if (torrent.State == TorrentState.QueuedUP
						|| torrent.State == TorrentState.QueuedDL
						|| torrent.State == TorrentState.QueuedUP
						|| torrent.State == TorrentState.Uploading
						|| torrent.State == TorrentState.CheckingUP
						|| torrent.State == TorrentState.CheckingDL
						|| torrent.State == TorrentState.Downloading
						|| torrent.State == TorrentState.StalledDL
						|| torrent.State == TorrentState.StalledUP
						|| torrent.State == TorrentState.MetaDL
						|| torrent.State == TorrentState.ForcedDL
						|| torrent.State == TorrentState.ForcedUP)
					return false;

			return true;
		}
	}
}
