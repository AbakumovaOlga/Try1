﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SweetShopWPF
{
  public static class APICustomer
    {
        private static HttpClient customer = new HttpClient();

        public static void Connect()
        {
            customer.BaseAddress = new Uri(ConfigurationManager.AppSettings["IPAddress"]);
            customer.DefaultRequestHeaders.Accept.Clear();
            customer.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static Task<HttpResponseMessage> GetRequest(string requestUrl)
        {
            return customer.GetAsync(requestUrl);
        }

        public static Task<HttpResponseMessage> PostRequest<T>(string requestUrl, T model)
        {
            return customer.PostAsJsonAsync(requestUrl, model);
        }

        public static T GetElement<T>(Task<HttpResponseMessage> response)
        {
            return response.Result.Content.ReadAsAsync<T>().Result;
        }

        public static string GetError(Task<HttpResponseMessage> response)
        {
            return response.Result.Content.ReadAsStringAsync().Result;
        }
    }
}
