using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Service.Models
{
    public class UserInfo
    {
        public string userName;
        public string firstName;
        public string lastName;

        public UserInfo(string userName, string firstName, string lastName)
        {
            this.userName = userName;
            this.firstName = firstName;
            this.lastName = lastName;
        }
    }
}