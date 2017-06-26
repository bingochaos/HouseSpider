
using NSoup.Select;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HttpSample
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "https://hz.lianjia.com/ershoufang/binjiang/pg2/";
           

            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                // 请求成功的状态码：200
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    using (Stream stream = response.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(stream))
                        {
                            string html = reader.ReadToEnd();
                            NSoup.Nodes.Document doc = NSoup.NSoupClient.Parse(html);
                           var divs =  doc.GetElementsByClass("clear");
                            foreach (var div in divs)
                            {
                                Elements element0 = div.GetElementsByClass("lj-lazy");
                                Elements element1 = div.GetElementsByClass("info-clear");
                                Console.WriteLine(element0.Attr("alt") + " " +  element1.Text);
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("服务器返回错误：{0}", response.StatusCode);
                }
            }

            Console.ReadLine();
        }
    }
}
