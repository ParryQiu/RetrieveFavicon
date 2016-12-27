using System;
using System.Linq;
using System.Net;
using HtmlAgilityPack;

namespace Common.Helper.RetrieveFavicon
{
    public static class Favicon
    {
        #region 获取站点的 Favicon

        /// <summary>
        /// 获取站点的 Favicon
        /// </summary>
        /// <param name="url">站点的 URL</param>
        /// <returns>站点的 Favicon 地址</returns>
        public static string RetrieveFavicon(string url)
        {
            string returnFavicon = null;

            //1. 直接获取站点的根目录图标
            var uri = new Uri(url);
            if (uri.HostNameType == UriHostNameType.Dns)
            {
                returnFavicon = string.Format("{0}://{1}/favicon.ico", uri.Scheme == "https" ? "https" : "http", uri.Host);
                if (UrlExists(returnFavicon))
                {
                    return returnFavicon;
                }
            }

            //2. 从页面的 HTML 中抓取
            var pageHtml = new WebClient().DownloadString(url);
            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(pageHtml);

            var elements = htmlDocument.DocumentNode.SelectNodes("//link[contains(@rel, 'icon')]");
            if (elements != null && elements.Any())
            {
                var favicon = elements.First();
                returnFavicon = favicon.GetAttributeValue("href", null);
                if (!string.IsNullOrWhiteSpace(returnFavicon))
                {
                    return returnFavicon;
                }
            }

            //3. 处理 apple-touch-icon 的情况
            var elementsAppleTouchIcon = htmlDocument.DocumentNode.SelectNodes("//link[contains(@rel, 'apple-touch-icon')]");
            if (elementsAppleTouchIcon != null && elementsAppleTouchIcon.Any())
            {
                var favicon = elementsAppleTouchIcon.First();
                returnFavicon = favicon.GetAttributeValue("href", null);
                if (!string.IsNullOrWhiteSpace(returnFavicon))
                {
                    return returnFavicon;
                }
            }

            return returnFavicon;
        }

        private static bool UrlExists(string url)
        {
            try
            {
                var webRequest = WebRequest.Create(url);
                webRequest.Method = "HEAD";
                var webResponse = (HttpWebResponse)webRequest.GetResponse();
                return webResponse.StatusCode == HttpStatusCode.OK;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion
    }
}
