using Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace Client
{
    public partial class Register : Form
    {
        Stream stream;

        public Register()
        {
            InitializeComponent();
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            TcpClient tcpClient = new TcpClient();

            //@dev connect to the server through this two lines here.
            tcpClient.Connect("127.0.0.1", 8001);
            //@dev get incoming streams from tcpClient.
            stream = tcpClient.GetStream();

            //@dev send login message by transmitData which sends through stream.
            Msg regMsg = new Msg(3, firstNameField.Text, lastNameField.Text, userField.Text, null, null, null);
            transmitData(regMsg);

            this.Close();
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
