﻿using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ZstdSharp.Unsafe;
using DataFormat = RestSharp.DataFormat;

namespace RevitData.TestConsole
{
    public class APICall
    {
        public static bool useCloudServer = false;
        const string baseUrlLocal = "http://localhost:7053/";
        const string baseUrlCloud = "https://revitdataapi.azurewebsites.net/";

        public static string RestAPIBaseUrl
        {
            get
            {
                return useCloudServer ? baseUrlCloud : baseUrlLocal;
            }
        }

        public static T GetT<T>(string collectionName)
        {
            var client = new RestClient(RestAPIBaseUrl);
            var request = new RestRequest("/api" + "/" + collectionName, Method.Get);
            var response = client.Execute<T>(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return response.Data;
            }
            return default(T);
        }

        public static async Task<(HttpStatusCode StatusCode, string Content, string ErrorMessage)> PostBatch(
            string collectionName,
            string json
            )
        {
            var client = new RestClient(RestAPIBaseUrl);
            var request = new RestRequest("/api/DbAccess", Method.Post);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(json);
            var response = await client.ExecuteAsync(request);
            return (response.StatusCode, response.Content, response.ErrorMessage);
        }
    }
}
