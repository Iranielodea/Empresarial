using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Empresarial.TesteTela
{
    public class Teste
    {
        public string Retorno(object model)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var serializedObj = JsonConvert.SerializeObject(model);
                    var content = new StringContent(serializedObj, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = client.PostAsync("http://localhost:5000/api/pais/incluir", content).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var retorno = response.Content.ReadAsStringAsync().Result;
                        //return JsonConvert.DeserializeObject<T[]>(retorno);
                        return retorno.ToString();
                    }
                    else
                        throw new Exception($"Status: {response.StatusCode} : {response.Content.ReadAsStringAsync().Result}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
                return "";
            }
        }
    }
}
