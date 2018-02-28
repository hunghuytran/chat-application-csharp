namespace Server
{
    /*
    @dev class constructor to store UserInfo.
    */ 
    public class UserInfo
    {
        public string userName;
        public string firstName;
        public string lastName;

        public UserInfo(string userName, string firstName, string lastName) {
            this.userName = userName;
            this.firstName = firstName;
            this.lastName = lastName;
        }
    }
}