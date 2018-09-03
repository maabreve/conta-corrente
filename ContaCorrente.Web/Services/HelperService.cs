using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace ContaCorrente.Web.Services
{
    public static class HelperService
    {
        public static async Task<Decimal> getExchangeRateDolarUol()
        {
            var url = "https://economia.uol.com.br/";
            var httpClient = new HttpClient();
            var html = await httpClient.GetStringAsync(url);
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);
            var node = htmlDocument.DocumentNode;

            return Convert.ToDecimal(htmlDocument.DocumentNode.SelectNodes("//section[@class='currencies']//a[contains(@href,'dolar-comercial-estados-unidos')]//span[@class='value bra']").FirstOrDefault().InnerHtml);
        }
    }
}