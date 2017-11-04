using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace qBittorrentSharp
{
    public partial class Communicator
    {
        private static async Task<HttpResponseMessage> Get(HttpClient client, string requestUri)
        {
            try
            {
                var reply = await client.GetAsync(requestUri);
                if (!reply.IsSuccessStatusCode)
                    throw new UnauthorizedAccessException();
                return reply;
            }

            catch (HttpRequestException)
            {
                return null;
            }

            catch (UnauthorizedAccessException)
            {
                return null;
            }
        }

        private static async Task<HttpResponseMessage> Post(HttpClient client, string requestUri, FormUrlEncodedContent content = null)
        {
            try
            {
                var reply = await client.PostAsync(requestUri, content);
                if (!reply.IsSuccessStatusCode)
                    throw new UnauthorizedAccessException();
                return reply;
            }

            catch (HttpRequestException)
            {
                return null;
            }

            catch (UnauthorizedAccessException)
            {
                return null;
            }
        }

        private static async Task<HttpResponseMessage> Post(HttpClient client, string requestUri, MultipartFormDataContent content)
        {
            try
            {
                var reply = await client.PostAsync(requestUri, content);
                if (!reply.IsSuccessStatusCode)
                    throw new UnauthorizedAccessException();
                return reply;
            }

            catch (HttpRequestException)
            {
                return null;
            }

            catch (UnauthorizedAccessException)
            {
                return null;
            }
        }
    }
}
