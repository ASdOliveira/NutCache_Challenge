using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace PeopleManagement.Client.Entities
{
    public class CommunicationResponse
    {
        public string Response { get; protected set; }
        public HttpStatusCode Statuscode {get; protected set;}

        public CommunicationResponse(string response, HttpStatusCode statusCode)
        {
            Response = response;
            Statuscode = statusCode;
        }
    }
}
