using PeopleManagement.Client.Entities;
using PeopleManagement.Common.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace PeopleManagement.Client.Communication
{
    public abstract class CommunicationBase<T> where T : Entity
    {
        public CommunicationResponse HttpGet(string url)
        {
            var httpRequest = WebRequest.CreateHttp(url);
            httpRequest.Method = "GET";
            
            return makeRequest(httpRequest);
        }

        //public abstract void Post();
        //public abstract void Delete();
        //public abstract void Put();

        private CommunicationResponse makeRequest(HttpWebRequest httpRequest)
        {
            string result = "";
            HttpStatusCode statusCode = HttpStatusCode.OK;

            try
            {
                var response = httpRequest.GetResponse() as HttpWebResponse;
                using (var streamReader = new StreamReader(response.GetResponseStream()))
                {
                    result = streamReader.ReadToEnd();
                }
                statusCode = response.StatusCode;

                return new CommunicationResponse(result, statusCode);
            }
            catch (Exception)
            {
                //Implmement
                throw;
            }
        }
    }
}
