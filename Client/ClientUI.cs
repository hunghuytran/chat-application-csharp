using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server;
using System.Windows.Forms;
using System.Web.Script.Serialization;
using System.IO;
using System.Threading;
using System.Net.Sockets;

namespace Client
{
    public partial class ClientUI : Form
    {
        Stream stream;


        public ClientUI()
        {

            InitializeComponent();
            onlineList.Click += new EventHandler(listBox_listener);
        }

        /*
        @dev function sends a message when it is being pressed.
        we have to first define the object class then serialize it to JSON.
        afterwards we send it to the server.
        */ 
        private void sendBtn_Click(object sender, EventArgs e)
        {
            Msg chatMsg = new Msg(5, null, null, userField.Text, null, receiverField.Text, msgField.Text);
            transmitData(chatMsg);
        }

        /*
        @dev function that logouts the user by sending information.
        */
        private void logoutBtn_Click(object sender, EventArgs e)
        {
            Msg logoutMsg = new Msg(2, null, null, userField.Text, null, null, null);
            transmitData(logoutMsg);
            onlineList.BeginInvoke((MethodInvoker)delegate () {

                onlineList.Items.Clear();
                
            });
        }

        /*
        @dev function that login the user by sending information.
        */
        private void loginBtn_Click(object sender, EventArgs e)
        {
            //@dev activates a thread which will update and run all the time in a loop until disconnect.
            //creates a new TcpClient which will put on global variable tcpClient for future use.
            Thread thread = new Thread(() => connectToSession(new TcpClient()));
            thread.Start();
        }



        private void connectToSession(TcpClient tcpClient)
        {
            //@dev connect to the server through this two lines here.
            tcpClient.Connect("127.0.0.1", 8001);
            //@dev get incoming streams from tcpClient.
            stream = tcpClient.GetStream();

            //@dev send login message by transmitData which sends through stream.
            Msg loginMsg = new Msg(1, null, null, userField.Text, null, null, null);
            transmitData(loginMsg);
            
            while(true)
            {
                Msg data = readIncData();

                //@dev get a list of user and update it.
                if(data.type == 4)
                {

                    /*
                    @dev this is the only way to update the UI that is run in a thread.
                    so here we are displaying only the username value in our listBox.
                    clear the list and then add again from the data we receive.
                    the listBox items have this event handler also.
                    */ 
                    onlineList.BeginInvoke((MethodInvoker)delegate () {
                        onlineList.DisplayMember = "USER";
                        onlineList.Items.Clear();
                        foreach (UserInfo i in data.userList)
                        {
                            onlineList.Items.Add(i);
                        }
                    });
                    
                }

                //@dev if the data is a message then update the chatField.
                if (data.type == 5)
                {
                    chatField.BeginInvoke((MethodInvoker)delegate () { chatField.Text = data.username + ": " + data.message; });
                }
            }
        }


        private void listBox_listener(object sender, EventArgs e)
        {
            UserInfo user = (UserInfo) onlineList.SelectedItem;
            MessageBox.Show("First name: " + user.firstName + " Last name: " + user.lastName);
        }

        /*
        @dev function that reads all incoming data to the tcpClient.
        */
        private Msg readIncData()
        {
            byte[] binData = new byte[400];

            //@dev receive data from server.
            stream.Read(binData, 0, binData.Length);

            //@dev convert data to readable string.
            string stringData = System.Text.Encoding.Default.GetString(binData);

            //@dev replace all the \0 with empty.
            stringData = stringData.Replace("\0", string.Empty);

            //@dev convert Json to a Msg object.
            JavaScriptSerializer js = new JavaScriptSerializer();
            Msg msg = js.Deserialize<Msg>(stringData);

            return msg;
        }

        /*
        @dev function register the user by sending data.
        */
        private void regBtn_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            register.Show();
            //@dev windows pop up when being pressed. register window contains user, name, last.
            //Msg regMsg = new Msg(3, null, null, null, null, null, msgField.Text);
            //transmitData(regMsg);
        }

        /*
        @dev function that converts Msg class object to Json then encode it to bytes.
        the bytes is then send through stream to our server. pre-requirements is to be
        connected to the server.
        */
        private void transmitData(Msg msg)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            string jsonData = js.Serialize(msg);
            ASCIIEncoding aEnc = new ASCIIEncoding();
            byte[] bytes = aEnc.GetBytes(jsonData);
            stream.Write(bytes, 0, bytes.Length);
        }
    }
}
