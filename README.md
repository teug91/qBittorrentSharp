# qBittorrentSharp <img align="right" src="qblight.ico" width="128" style="margin:0px 30px">
C# library to work with the [qBittorrent WebUI API](https://github.com/qbittorrent/qBittorrent/wiki/WebUI-API-Documentation).

This library is largely untested. [The official qBittorrent WebUI API documentation](https://github.com/qbittorrent/qBittorrent/wiki/WebUI-API-Documentation) might be helpfull.

## How to use it ##
qBittorrentSharp.API.Initialize("http://192.168.1.100:8080"); // Initialize

bool? LogInSuccessful = await qBittorrentSharp.API.Login("username", "password"); // Login

await qBittorrentSharp.API.PauseAll(); // Run some method

## Credit
* [qBittorrent](https://github.com/qbittorrent/qBittorrent) - A BitTorrent client
* [Json.NET](https://www.newtonsoft.com/json) - Popular high-performance JSON framework for .NET
