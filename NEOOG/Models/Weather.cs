using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;

namespace NEOOG.Models
{
    public class Weather
    {

            public Object getWeatherForcast()
            {
                string url = "http://api.openweathermap.org/data/2.5/weather?q=Cleveland&APPID=a267756a7d1dbd95015007affb054e19&units=imperial";

                var client = new WebClient();
                var content = client.DownloadString(url);
                var serializer = new JavaScriptSerializer();
                var jsonContent = serializer.Deserialize<Object>(content);
                return jsonContent;
            }
        }
    }
