using Bank_System.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Xml.Serialization;
using System.Xml.Schema;
using System.IO;


namespace Bank_System.Service
{
    public class CurrencyService
    {
        public CurrencyResponse currency;
        public async Task<CurrencyResponse> GetCurrency()
        {
            HttpResponseMessage responseMessage;

            using (var client = new HttpClient())
            {
                
                 responseMessage = await client.GetAsync("https://www.cbr-xml-daily.ru/daily_json.js");
                responseMessage.EnsureSuccessStatusCode();
                string serializeMessage = await responseMessage.Content.ReadAsStringAsync();
                currency = JsonConvert.DeserializeObject<CurrencyResponse>(serializeMessage);  
            }

            return currency;
        }
    }
}