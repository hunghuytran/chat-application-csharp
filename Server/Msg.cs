using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    /*
     @dev class for storing objects according to constructor.
     contains int type and string text variable.
    */
    public class Msg
    {
        //@variables.
        public int type;
        public string firstName;
        public string lastName;
        public string username;
        public List<UserInfo> userList;
        public string receiver;
        public string message;

        //@constructor empty.
        public Msg() { }

        //@constructor with int type and string text.
        public Msg(int type, string firstName, string lastName, string username, List<UserInfo>userList, string receiver, string message)
        {
            this.type = type;
            this.firstName = firstName;
            this.lastName = lastName;
            this.username = username;
            this.userList = userList;
            this.receiver = receiver;
            this.message = message;
        }
    }
}
