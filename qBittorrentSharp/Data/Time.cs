using System;

namespace qBittorrentSharp.Data
{
    public class Time
    {
		public int Hours { get; set; }
		public int Minutes { get; set; }

		public Time(int hours, int minutes)
		{
			if (hours < 0 || hours > 23)
				throw new ArgumentOutOfRangeException("Hours needs to be 0-23");

			if (minutes < 0 || minutes > 59)
				throw new ArgumentOutOfRangeException("Minutes needs to be 0-59");

			Hours = hours;
			Minutes = minutes;
		}
    }
}
