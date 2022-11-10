using PeopleManagement.Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using PeopleManagement.Client.Entities;

namespace PeopleManagement.Client.Communication
{
    public class EmployeeCommunication : CommunicationBase<Employee>
    {
        //public override void Delete()
        //{
        //    throw new NotImplementedException();
        //}

        public CommunicationResponse Get(string url)
        {
            return HttpGet(url);
        }

        //public override void Post()
        //{
        //    throw new NotImplementedException();
        //}

        //public override void Put()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
