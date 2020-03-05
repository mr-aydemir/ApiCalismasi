using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System.Net.Http;
using System.IO;
using Microsoft.Win32.SafeHandles;
using System.Net.Http.Headers;

namespace VatanAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImagesController : ControllerBase
    {

        private readonly SafeFileHandle filePath;
        public ImagesController(SafeFileHandle safeFileHandle)
        {
            safeFileHandle = filePath;
        }
        [HttpGet]

        public HttpResponseMessage Get()
        {
            using(FileStream fs= new FileStream(filePath, FileMode.Open))
            {
                HttpResponseMessage response = new HttpResponseMessage();
                response.Content = new StreamContent(fs);
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");
                return response;
            }
        }
    }
}