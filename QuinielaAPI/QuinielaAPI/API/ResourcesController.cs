using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web;
using QuinielaAPI.Models;
using System.Web.Http.Cors;
using Newtonsoft.Json;

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

        [HttpPost, EnableCors("*","*","*")]
        public HttpResponseMessage Set()
        {
            
            HttpResponseMessage response = null;
            var httpRequest = HttpContext.Current.Request;
            if (httpRequest.Files.Count > 0)
            {
                var postedFile = httpRequest.Files[0];
                //Good to use an updated name always, since many can use the same file name to upload.
                string fileName = postedFile.FileName;

                var filePath = HttpContext.Current.Server.MapPath("~/Content/Images/" + fileName);
                postedFile.SaveAs(filePath);
                var virtualPath = Request.RequestUri;
                var data = new ResourceResponse { Path = virtualPath.ToString(), Name = fileName.Split('.')[0] };
                var jsonText = JsonConvert.SerializeObject(data);
                response = new HttpResponseMessage { Content = new StringContent(jsonText) };
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                //response = Request.CreateResponse(HttpStatusCode.Created, json);
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            return response;
        }
    }
}
