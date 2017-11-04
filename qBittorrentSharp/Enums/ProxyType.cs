namespace qBittorrentSharp.Enums
{
    public enum ProxyType
    {
        ProxyIsDisabled = -1,
        HttpProxyWithoutAuthentication = 1,
        Socks5ProxyWithoutAuthentication = 2,
        HttpProxyWithAuthentication = 3,
        Socks5ProxyWithAuthentication = 4,
        Socks4ProxyWithoutAuthentication = 5
    };
}
