using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace UIClient.Services
{
    public static class Exstensions
    {
        public static string ConvertToJson(this string xmlResponse)
        {
            if (string.IsNullOrEmpty(xmlResponse)) return null;

            var xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(xmlResponse.Replace("xsi:nil=\"true\"", ""));
            return  JsonConvert.SerializeXmlNode(xmlDocument);
        }
    }
}