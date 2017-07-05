using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace QuinielaAPI.API
{
    public class ResourcesController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage Get(string id)
        {
            var path = System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath + @"Content\Images";
            string fileName = string.Format(@"{0}\{1}.png", path, id);
            if (!File.Exists(fileName))
                throw new HttpResponseException(HttpStatusCode.NotFound);

            FileStream fileStream = File.Open(fileName, FileMode.Open);
            HttpResponseMessage response = new HttpResponseMessage { Content = new StreamContent(fileStream) };
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("image/png");
            response.Content.Headers.ContentLength = fileStream.Length;
            return response;
        }
    }
}
