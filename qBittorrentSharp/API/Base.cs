using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace qBittorrentSharp
{
    public partial class API
    {
        private static async Task<HttpResponseMessage> Get(HttpClient client, string requestUri)
        {
            try
            {
                var reply = await client.GetAsync(requestUri);
				if (!reply.IsSuccessStatusCode)
					throw new HttpRequestException(reply.ReasonPhrase);
				return reply;
			}

			catch (HttpRequestException)
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
                    throw new HttpRequestException(reply.ReasonPhrase);
				return reply;
            }

            catch (HttpRequestException)
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
					throw new HttpRequestException(reply.ReasonPhrase);
				return reply;
			}

			catch (HttpRequestException)
			{
				return null;
			}
		}

		private static string ListToString(List<string> stringList , char separator)
		{
			string returnString = "";
			foreach (string element in stringList)
				returnString += element + separator;
			returnString = returnString.Remove(returnString.Length - 1);

			return returnString;
		}

		private static string ListToString(List<Uri> uris, char separator)
		{
			string returnString = "";
			foreach (Uri element in uris)
				returnString += element.ToString() + separator;
			returnString = returnString.Remove(returnString.Length - 1);

			return returnString;
		}
	}
}
