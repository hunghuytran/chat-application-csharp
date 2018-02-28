using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace Server
{
    public partial class ServerUI : Form
    {
        Dictionary<string, Socket> userSockets = new Dictionary<string, Socket>();
        List<UserInfo> userInfos = new List<UserInfo>();
  

        public ServerUI()
        {
            InitializeComponent();
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            //@dev specify the ip address for the server.
            IPAddress ipAddr = IPAddress.Parse("127.0.0.1");

            //@dev set the ip and port number for socket and start 
            TcpListener tcpL = new TcpListener(ipAddr, 8001);
            tcpL.Start(); 

            while (true)
            {
                //@dev check for incoming connections, use this to avoid memory problem.
                if (tcpL.Pending())
                {
                    //@dev starts a new thread when a new client comes in.
                    Thread th = new Thread(() => clientSession(tcpL.AcceptSocket()));
                    th.Start();
                }
            }
        }

        //@dev converts all data received to a Msg object.
        private Msg receiveData(Socket socket)
        {
            byte[] binData = new byte[100];

            //@dev receive data from clients socket.
            socket.Receive(binData);

            //@dev convert data to readable string.
            string stringData = System.Text.Encoding.Default.GetString(binData);

            //@dev replace all the \0 with empty.
            stringData = stringData.Replace("\0", string.Empty);

            //@dev convert Json to a Msg object.
            JavaScriptSerializer js = new JavaScriptSerializer();
            Msg msg = js.Deserialize<Msg>(stringData);
            return msg;
        }

        //@dev read all incoming messages from user.
        private void clientSession(Socket clientSocket)
        {
            while (true)
            {
                byte[] binData = new byte[400];

                //@dev receive data from clients socket.
                clientSocket.Receive(binData);

                //@dev convert data to readable string.
                string stringData = System.Text.Encoding.Default.GetString(binData);

                //@dev replace all the \0 with empty.
                stringData = stringData.Replace("\0", string.Empty);

                //@dev convert Json to a Msg object.
                JavaScriptSerializer js = new JavaScriptSerializer();
                Msg data = js.Deserialize<Msg>(stringData);

                
                if (data.type == 1)
                {
                    //@dev login connect to our api and gets information from there.
                    LoginRequest(js, clientSocket, data.username);
                }
                
                if (data.type == 2)
                {
                    foreach(UserInfo i in userInfos.ToList<UserInfo>())
                    {
                        if(i.userName == data.username)
                        {
                            userInfos.Remove(i);
                        }
                        
                    }
                    Online();
                    userSockets.Remove(data.username);
                    break;
                }

                //@dev registering function.
                if (data.type == 3)
                {
                    UserInfo userInfo = new UserInfo(data.username, data.firstName, data.lastName);
                    String jsonPost = js.Serialize(userInfo);
                    PostRequest(jsonPost);
                }

                if (data.type == 5)
                {
                    userSockets[data.receiver].Send(binData);
                }
            }
        }

        private void Online()
        {
            Msg userList = new Msg(4, null, null, null, userInfos, null, null);
            JavaScriptSerializer js = new JavaScriptSerializer();
            string jsonData = js.Serialize(userList);
            ASCIIEncoding aEnc = new ASCIIEncoding();
            byte[] bytes = aEnc.GetBytes(jsonData);
            foreach (UserInfo i in userInfos)
                {
                userSockets[i.userName].Send(bytes);
                }
            }

        private async Task PostRequest(String jsonPost)
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.PostAsync("http://restserviceyummy.azurewebsites.net/api/User", new StringContent(jsonPost));

                String text = await response.Content.ReadAsStringAsync();
                MessageBox.Show("Added to database.");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        //@dev should send string from the field!
        private async Task LoginRequest(JavaScriptSerializer js, Socket clientSocket, string query)
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync("http://restserviceyummy.azurewebsites.net/api/User/"+query);
                HttpContent content = response.Content;
                String jsonString = await content.ReadAsStringAsync();
                login(jsonString, js, clientSocket);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void login(string jsonString, JavaScriptSerializer js, Socket clientSocket)
        {
            UserInfo user = new UserInfo();
            user = js.Deserialize<UserInfo>(jsonString);
            userSockets.Add(user.userName, clientSocket);
            userInfos.Add(new UserInfo(user.userName, user.firstName, user.lastName));
            Online();
        }
    }
}
