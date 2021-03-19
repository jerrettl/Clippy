using HtmlAgilityPack;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;
using System.Threading.Tasks;

namespace Clippy.Helpers
{
    public class ImageDownloaderHelper
    {
        const int MAX_TRIES = 5;

        // Take the URL of a website as input, and download the first available
        // image from that page. Returns the name of the file that was downloaded.
        public static async Task<string> FetchImageFromUrl(string url)
        {
            if (url == null) return null;

            // Add a protocol to the URL in the case that it doesn't already have one.
            if (!url.StartsWith("http://") && !url.StartsWith("https://"))
            {
                url = "http://" + url;
            }

            // Setup for making requests to the internet.
            HttpClientHandler handler = new HttpClientHandler() { AllowAutoRedirect = false };
            HttpClient client = new HttpClient(handler);
            HttpRequestMessage request = null;
            HttpResponseMessage response = null;
            string pageContent = null;

            int triesMade = 0;

            // Take the provided URL and try to find a website that will give a successful status.
            // When necessary, handle redirections until success is found.
            while (response == null || response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                if (triesMade > MAX_TRIES) break;

                try
                {
                    // Create the HTTP request.
                    request = new HttpRequestMessage(HttpMethod.Get, url);
                    request.Headers.AcceptEncoding.Add(new StringWithQualityHeaderValue("identity"));
                }
                catch (UriFormatException exception)
                {
                    // This URL isn't any good.
                    Console.Error.WriteLine(exception);
                    return null;
                }

                try
                {
                    // Send the HTTP request.
                    response = await client.SendAsync(request);
                }
                catch (HttpRequestException exception)
                {
                    // This is probably a bogus URL.
                    Console.Error.WriteLine(exception);
                    return null;
                }

                // Save the page contents.
                pageContent = await response.Content.ReadAsStringAsync();

                // Extrapolate the fully resolved URL.
                try
                {
                    url = response.Headers.Location.AbsoluteUri;
                }
                catch
                {
                    // There are no (additional) redirects.
                    break;
                }

                triesMade++;
            }

            // Parse the retrieved HTML.
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(pageContent);

            // Find the first <img> tag.
            HtmlNode firstImage = doc.DocumentNode.SelectSingleNode("//img");
            if (firstImage == null) return null;

            // Generate the full URL to the image.
            string imageSrc = firstImage.Attributes["src"].Value;
            string imageUrl;
            if (imageSrc.StartsWith("http://") ||
                imageSrc.StartsWith("https://"))
            {
                imageUrl = imageSrc;
            }
            else if (imageSrc.StartsWith("//"))
            {
                imageUrl = $"http:{imageSrc}";
            }
            else if (imageSrc.StartsWith("/"))
            {
                imageUrl = $"{url}{imageSrc.Split("/", 2)[1]}";
            }
            else
            {
                imageUrl = $"{url}{imageSrc}";
            }

            // Download the image using a unique identifier.
            string strippedImageUrl = (imageUrl.Contains("?")) ? imageUrl.Split("?")[0] : imageUrl;
            string newFileName = Guid.NewGuid().ToString() + "_" + System.IO.Path.GetFileName(strippedImageUrl);
            string localImagePath = "wwwroot/images/bookmarks/" + newFileName;

            // Download the image.
            try
            {
                WebClient webClient = new WebClient();
                webClient.DownloadFile(imageUrl, localImagePath);
            }
            catch (WebException exception)
            {
                // Possibly a 404 error. Final catch-all if the website is finicky.
                Console.Error.WriteLine(exception);
                return null;
            }

            return newFileName;
        }
    }
}