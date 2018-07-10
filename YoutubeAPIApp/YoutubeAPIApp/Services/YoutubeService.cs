using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YoutubeAPIApp.Entities;

namespace YoutubeAPIApp.Services
{
    public class YoutubeService
    {
        public static string KeyAccess = "AIzaSyBkPV__1Ehh5BX_ByGbrNuYgcxZ17vddbw";

        public static Task<GoogleYoutubeApi> ListarVideosYoutube(string busca, string tokenProxPagina = "")
        {
            var url = $"https://www.googleapis.com/youtube/v3/search?key={KeyAccess}&part=snippet&maxResults=10&q={busca}&pageToken={tokenProxPagina}";
            return new RestService().MakeGetRequestHttpClient<GoogleYoutubeApi>(url);
        }
    }
}
