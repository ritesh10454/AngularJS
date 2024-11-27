using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace LCM.Controllers
{
    public class MyUploadController : ApiController
    {

        [HttpPost]
        [Route("api/UploadFiles")]
        public async Task<HttpResponseMessage> Post()
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            var root = HttpContext.Current.Server.MapPath("~/App_Data/Uploadfiles");
            Directory.CreateDirectory(root);
            var provider = new MultipartFormDataStreamProvider(root);
            var result = await Request.Content.ReadAsMultipartAsync(provider);

            var model = result.FormData["jsonData"];
            if (model == null)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            //TODO: Do something with the JSON data.  

            //get the posted files  
            foreach (var file in result.FileData)
            {
                //TODO: Do something with uploaded file.  
            }

            return Request.CreateResponse(HttpStatusCode.OK, "success!");
        }
    }
}