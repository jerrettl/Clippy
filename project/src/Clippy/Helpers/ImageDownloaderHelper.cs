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
        const string USER_AGENT = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/74.0.3729.169 Safari/537.36";

        // Take the URL of a website as input, and attempt to download an image
        // from it using different methods. Returns the name of the file that was downloaded.
        // If every method fails, return null.
        public static async Task<string> FetchImageFromUrl(string url)
        {
            if (url == null) return null;

            Tuple<string, string> pageData = await FetchPage(url);
            if (pageData == null) return null;
            string resolvedUrl = pageData.Item1;
            string pageContent = pageData.Item2;
            if (resolvedUrl == null) return null;

            string image = FetchImageFromUrlUsingPage(resolvedUrl, pageContent);
            if (image == null) image = FetchImageFromUrlUsingFavicon(resolvedUrl, pageContent);

            return image;
        }

        // Take the URL of a website as input and attempt to resolve it.
        // Returns a tuple containing the final resolved URL of the page and
        // the HTML contents of the retrieved page.
        private static async Task<Tuple<string, string>> FetchPage(string url)
        {
            // Add a protocol to the URL in the case that it doesn't already have one.
            if (!url.StartsWith("http://") && !url.StartsWith("https://"))
            {
                url = "http://" + url;
            }

            // Setup for making requests to the internet.
            HttpClientHandler handler = new HttpClientHandler();
            handler.AllowAutoRedirect = false;
            handler.AutomaticDecompression = DecompressionMethods.All;
            HttpClient client = new HttpClient(handler);
            client.DefaultRequestHeaders.Add("User-Agent", USER_AGENT);
            client.Timeout = TimeSpan.FromSeconds(5);
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
                catch (TaskCanceledException exception)
                {
                    // The request probably timed out.
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

            return new Tuple<string, string>(url, pageContent);
        }

        // Download and store an image with the provided URL. Returns the name
        // of the image file downloaded.
        private static string DownloadImage(string url)
        {
            return DownloadImage(url, url);
        }

        // Download an image using a short URL and a long URL. The short URL is
        // a truncated version of the long URL if it is too long for a file name.
        // Returns the name of the image file downloaded.        
        private static string DownloadImage(string shortUrl, string longUrl)
        {
            string newFileName = Guid.NewGuid().ToString() + "_" + System.IO.Path.GetFileName(shortUrl);
            string localImagePath = "wwwroot/images/bookmarks/" + newFileName;

            // Download the image.
            try
            {
                WebClient webClient = new CustomWebClient();
                webClient.Headers.Add("User-Agent", USER_AGENT);
                webClient.DownloadFile(longUrl, localImagePath);
            }
            catch (WebException exception)
            {
                // Possibly a 404 error. Final catch-all if the website is finicky.
                Console.Error.WriteLine($"Unable to get image from {longUrl}");
                Console.Error.WriteLine(exception);
                return null;
            }

            return newFileName;
        }

        // Given a page URL and an image URL, combine them to generate a direct link
        // to the image. The page URL is a base that may or may not be prepended to
        // the image URL. The image URL may or may not be relative to the page it is on.
        // Expects pageUrl to end with "/".
        // Example:
        //     Input: "https://www.google.com/", "/static/assets/image.jpg"
        //     Output: "https://www.google.com/static/assets/image.jpg"
        // Example:
        //     Input: "https://www.example.com/", "//amazon.com/images/image.png"
        //     Output: "http://amazon.com/images/image.png"
        private static string GenerateImageUrl(string pageUrl, string imageUrl)
        {
            string result;

            if (imageUrl.StartsWith("http://") ||
                imageUrl.StartsWith("https://"))
            {
                result = imageUrl;
            }
            else if (imageUrl.StartsWith("//"))
            {
                result = $"http:{imageUrl}";
            }
            else if (imageUrl.StartsWith("/"))
            {
                result = $"{pageUrl}{imageUrl.Split("/", 2)[1]}";
            }
            else
            {
                result = $"{pageUrl}{imageUrl}";
            }

            return result;
        }

        // Takes as input a (resolved) page URL and the HTML contents of a page, and
        // downloads the first image in the page. Returns the name of the saved image.
        private static string FetchImageFromUrlUsingPage(string url, string pageContent)
        {
            if (pageContent == null) return null;

            // Parse the retrieved HTML.
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(pageContent);

            // Find all <img> tags.
            HtmlNodeCollection images = doc.DocumentNode.SelectNodes("//img");
            if (images == null) return null;

            // Go through all the <img> tags and find the first reasonable-looking image link.
            string newFileName = null;
            foreach (HtmlNode node in images)
            {
                // Skip this image if it isn't wanted.
                if (!node.Attributes.Contains("src") || !IsSupportedFile(node.Attributes["src"].Value))
                {
                    continue;
                }

                // Generate the full URL to the image.
                string imageUrl = GenerateImageUrl(url, node.Attributes["src"].Value);

                // Download the image using a unique identifier.
                string strippedImageUrl = (imageUrl.Contains("?")) ? imageUrl.Split("?")[0] : imageUrl;

                newFileName = DownloadImage(strippedImageUrl, imageUrl);
                if (newFileName != null) break;
            }           

            return newFileName;
        }

        // Takes as input a (resolved) page URL and downloads a favicon from that page.
        // Returns the name of the saved image.
        private static string FetchImageFromUrlUsingFavicon(string url, string pageContent)
        {
            Uri uri = new Uri(url);

            // First using the simplest approach: Find favicon.ico relative to the domain
            // name of the URL.
            string domain = uri.GetLeftPart(UriPartial.Authority);
            string faviconUrl = domain + "/favicon.ico";

            string newFileName = DownloadImage(faviconUrl);

            // If that doesn't work out, find the HTML tag that specifies an icon.
            if (newFileName == null)
            {
                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(pageContent);

                HtmlNode iconElement = doc.DocumentNode.SelectSingleNode("//link[@rel=\"shortcut icon\"]");
                if (iconElement != null)
                {
                    faviconUrl = GenerateImageUrl(domain + "/", iconElement.Attributes["href"].Value);
                    newFileName = DownloadImage(faviconUrl);
                }
            }
            
            // Try the previous method, but using a slightly different tag.
            if (newFileName == null)
            {
                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(pageContent);

                HtmlNode iconElement = doc.DocumentNode.SelectSingleNode("//link[@rel=\"icon\"]");
                if (iconElement != null)
                {
                    faviconUrl = GenerateImageUrl(domain + "/", iconElement.Attributes["href"].Value);
                    newFileName = DownloadImage(faviconUrl);
                }
                else
                {
                    return null;
                }
            }

            return newFileName;
        }

        // Check if a file name has a supported file extension and isn't a sprite sheet.
        private static bool IsSupportedFile(string fileName)
        {
            if (fileName.Contains("sprite"))
            {
                return false;
            }
            else if (fileName.EndsWith(".png") ||
                fileName.EndsWith(".jpeg") ||
                fileName.EndsWith(".jpg") ||
                fileName.EndsWith(".svg") ||
                fileName.EndsWith(".ico"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    class CustomWebClient : WebClient
    {
        protected override WebRequest GetWebRequest(Uri address)
        {
            HttpWebRequest request = base.GetWebRequest(address) as HttpWebRequest;
            request.AutomaticDecompression = DecompressionMethods.All;
            return request;
        }

    }
}