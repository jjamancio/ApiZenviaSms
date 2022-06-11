using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace EnvioSMS
{

    public class ZenviaRequest
    {
        public string Telefone { get; set; }
        public string Mensagem { get; set; }
        public string TOKEN { get; set; }



    }
    public class EnvioSMSServices
    {

        public string EnviarSMS(ZenviaRequest zenviaRequest)
        {

            string adicionar = "\"";
            string To = adicionar + zenviaRequest.Telefone + adicionar;
            string TOKEN = "";
            string conteudo = adicionar + zenviaRequest.Mensagem + adicionar;

            // https://docs.microsoft.com/en-us/aspnet/core/fundamentals/http-requests
            // https://www.aspnetmonsters.com/2016/08/2016-08-27-httpclientwrong/
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://api.zenvia.com/v2/channels/sms/messages"))
                {
                    request.Headers.TryAddWithoutValidation("X-API-TOKEN", TOKEN);

                    string dados = "{\"from\":\"paper-child\",\"to\":" + To + ",\"contents\":[{\"type\":\"text\",\"text\":" + conteudo + "}]}";
                    request.Content = new StringContent(dados);
                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

                    var response = httpClient.SendAsync(request).Result;

                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        return "Menssagem enviada com sucesso!";
                    else
                        return "Não foi possivel enviar msg :" + request.Content;
                }

            }
        }
    }
}
