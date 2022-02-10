using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace VK1.SCGE.Safety.Mvc {
    public class LineNotify : ILog {
        private const string URL = "https://notify-api.line.me/api/notify";
        private readonly IConfiguration config;

        public LineNotify(IConfiguration config) {
            this.config = config;
        }

        public async Task WriteAsync(string s) {
            await Notify(s);
        }

        private async Task<string> Notify(string message) {
            var token = config["LineToken"];

            if (string.IsNullOrEmpty(token)) return "";

            using (var client = new HttpClient()) {
                var url = URL;
                var content = new FormUrlEncodedContent(new[] {
                    new KeyValuePair<string,string>("message",message)
                });

                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

                var result = await client.PostAsync(url, content);

                string resultContent = await result.Content.ReadAsStringAsync();

                return resultContent;
            }
        }
    }
}
