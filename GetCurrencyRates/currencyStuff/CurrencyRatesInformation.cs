using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace GetCurrencyRates
{
    /// <summary>
    /// Class to get currency rates information according to Narodowy Bank Polski
    /// </summary>
    public class CurrencyRatesInformation
    {
        private CurrencyRatesInformation() { }

        public static string getCurrencyRate(string currencyCode)
        {
            try
            {
                CurrencyInformation currentCurrency = new CurrencyInformation();
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://api.nbp.pl/api/exchangerates/rates/A/" + currencyCode);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader streamReader = new StreamReader(response.GetResponseStream());
                DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(CurrencyInformation));
                currentCurrency = (CurrencyInformation)jsonSerializer.ReadObject(response.GetResponseStream());
                return currentCurrency.Rates[0].Mid.ToString();
            }
            catch (WebException)
            {
                return "check your internet connection";
            }
        }
    }
}
