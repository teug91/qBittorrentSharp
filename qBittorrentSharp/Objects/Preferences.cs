using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace qBittorrentSharp
{
    public class Preferences
    {
		[JsonProperty("autorun_enabled", NullValueHandling = NullValueHandling.Ignore)]
		public bool? Autorun_enabled { get; set; }

		[JsonProperty("queueing_enabled", NullValueHandling = NullValueHandling.Ignore)]
		public bool? Queueing_enabled { get; set; }
	}
}
