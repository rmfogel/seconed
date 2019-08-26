using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using xserver;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Server2.Controllers
{
    public class ValuesController : ApiController
    {
        public ValuesController()
        {

        }


        [HttpGet]
        public HttpResponseMessage Get()
        {
            using (MemoryStream ms = new MemoryStream())
            {
                string fileName = "KerenTorah.xlsx";

                using (FileStream file = new FileStream(System.Web.Hosting.HostingEnvironment.MapPath("~/" + fileName), FileMode.Open, FileAccess.Read))
                {
                    byte[] bytes = new byte[file.Length];
                    file.Read(bytes, 0, (int)file.Length);
                    ms.Write(bytes, 0, (int)file.Length);

                    HttpResponseMessage httpResponseMessage = new HttpResponseMessage();
                    httpResponseMessage.Content = new ByteArrayContent(ms.GetBuffer());
                    httpResponseMessage.Content.Headers.Add("x-filename", fileName);
                    httpResponseMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
                    httpResponseMessage.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
                    httpResponseMessage.Content.Headers.ContentDisposition.FileName = fileName;
                    httpResponseMessage.Content.Headers.ContentLength = file.Length;
                    httpResponseMessage.StatusCode = HttpStatusCode.OK;
                    return httpResponseMessage;
                }
            }
        }

        public void Options() { }





    }
}




//public string[] Get()
//{
//    return new[] { "Hello", "World" };
//}







