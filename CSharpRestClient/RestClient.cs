using System;
using System.Net;
using System.IO;

namespace CSharpRestClient
{
    public enum httpverb
    {
        GET,
        POST,
        PUT,
        DELETE
    }

    class RestClient
    {
        public string endpoint { get; set; }
        public httpverb httpmethod { get; set; }

        public RestClient()
        {
            endpoint = string.Empty;
            httpmethod = httpverb.GET;

        }
        public string makeRequest()
        {
            string strResponseValue = string.Empty;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(endpoint);

            request.Method = httpmethod.ToString();

            HttpWebResponse response = null;

            try
            {
                response = (HttpWebResponse)request.GetResponse();


                //Proecess the resppnse stream... (could be JSON, XML or HTML etc..._

                using (Stream responseStream = response.GetResponseStream())
                {
                    if (responseStream != null)
                    {
                        using (StreamReader reader = new StreamReader(responseStream))
                        {
                            strResponseValue = reader.ReadToEnd();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                strResponseValue = "{\"errorMessages\":[\"" + ex.Message.ToString() + "\"],\"errors\":{}}";
            }
            finally
            {
                if (response != null)
                {
                    ((IDisposable)response).Dispose();
                }
            }

            return strResponseValue;
        }

        
    }
}
