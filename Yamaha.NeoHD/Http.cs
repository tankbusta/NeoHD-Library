namespace Yamaha.NeoHD
{
    using System;
    using System.Net;
    using System.Text;
    using System.IO;

    class Http
    {
        public bool HttpPost(string uri, string parameters)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);

            request.KeepAlive = false;
            request.UserAgent = "NeoHDApp/1.0 CFNetwork/485.13.9 Darwin/11.0.0"; //Mimic this as the NeoHD app for iOS
            request.ProtocolVersion = HttpVersion.Version11; //HTTP 1.1 Support
            request.Method = "POST"; //We're posting...

            string command = parameters;

            byte[] postBytes = Encoding.ASCII.GetBytes(command);
            request.ContentType = "text/xml";
            request.ContentLength = postBytes.Length;

            Stream reqStream = request.GetRequestStream();

            reqStream.Write(postBytes, 0, postBytes.Length);
            reqStream.Close();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
