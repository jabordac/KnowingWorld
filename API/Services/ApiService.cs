using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using API.Models;
using System.Net.Http.Headers;

public class ApiService
{
    public async Task<Response> GetCountriesAsync<T>(string urlBase, string controller, string serviceSufix, string nameKey, string valueKey)
    {
        try
        {
            ////var client = new RestClient(urlBase);
            ////var request = new RestRequest(Method.GET);
            ////request.AddHeader("x-rapidapi-key", "24f8cc5869msh5b87656d6e615f1p1cf334jsn0c1d83fdb12d");
            ////request.AddHeader("x-rapidapi-host", "restcountries-v1.p.rapidapi.com");
            ////IRestResponse response = client.Execute(request);


            //var request = new HttpRequestMessage
            //{
            //    Method = HttpMethod.Get,
            //    RequestUri = new Uri($"{urlBase}{controller}"),
            //    Headers =
            //    {
            //        { "x-rapidapi-key", "24f8cc5869msh5b87656d6e615f1p1cf334jsn0c1d83fdb12d" },
            //        { "x-rapidapi-host", "restcountries-v1.p.rapidapi.com" },
            //    },
            //};

            //using (var response = await client.SendAsync(request))
            //{
            //    response.EnsureSuccessStatusCode();
            //    var body = await response.Content.ReadAsStringAsync();
            //    Console.WriteLine(body);
            //}


            var client = new HttpClient
            {
                BaseAddress = new Uri(urlBase)
            };

            client.DefaultRequestHeaders.Add(nameKey, valueKey);
            //client.DefaultRequestHeaders.Add("x-rapidapi-host", "restcountries-v1.p.rapidapi.com");

            //.Authorization = new AuthenticationHeaderValue(tokenType, accessToken);

            var url = $"{controller}";
            var response = await client.GetAsync(url);
            var result = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = result,
                };
            }

            var list = JsonConvert.DeserializeObject<List<T>>(result);

            return new Response
            {
                IsSuccess = true,
                Result = list
            };
        }
        catch (Exception ex)
        {
            return new Response
            {
                IsSuccess = false,
                Message = ex.Message
            };
        }
    }
}
