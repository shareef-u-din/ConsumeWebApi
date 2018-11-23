using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ConsumeWebApi.Helper
{
    public class DataHelper
    {

        public static IEnumerable<T> GetDataFromApi<T>(string url,string controllerAndOrAction)
        {
            IEnumerable<T> list = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                //HTTP GET
                //client
                var responseTask = client.GetAsync(controllerAndOrAction);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<T>>();
                    readTask.Wait();

                    list = readTask.Result;
                }
                else //web api sent error response
                {
                    //log response status here..

                    list = Enumerable.Empty<T>();
                }
            }
                return list;
        }
        public static bool Add<T>(T passObject, string url, string controllerAndOrAction) {
            using (var client=new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                //HTTP  Post
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage httpResponseMessage = client.PostAsJsonAsync(url+controllerAndOrAction,passObject).Result;
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }

        }


    }
}