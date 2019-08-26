using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Xml;
using System.Xml.Linq;

namespace Server2.Controllers
{
    public class CurrencyController : ApiController
    {
        [Route("api/currency/{code}")]
        public double Get(string code)
        {
              //String URLString = "https://www.boi.org.il/currency.xml";
            string URLString = HttpContext.Current.Server.MapPath("../../" + "App_Data/currency.xml");
            //String URLString;
            try
            {
                XDocument doc = XDocument.Load(URLString);
                XElement element = doc.Root.Elements("CURRENCY").FirstOrDefault(e => e.Element("CURRENCYCODE").Value.Trim().ToUpper() == code.ToUpper());
                if (element != null)
                {
                    return double.Parse(element.Element("RATE").Value);
                }

                
                return 1;
            }
            catch (Exception ex)
            {
                return 1;
            }
        }
    }
}
