using System;
using System.Collections.Generic;
using System.Text;

namespace qBittorrentSharp.Enums
{
    public enum TorrentState
    {
        error,
        pausedUP,
        pausedDL,
        queuedUP,
        queuedDL,
        uploading,
        stalledUP,
        checkingUP,
        checkingDL,
        downloading,
        stalledDL,
        metaDL
    };
}
