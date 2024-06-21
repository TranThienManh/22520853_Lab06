using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _22520853_Lab06
{
    public partial class Bai3 : Form
    {
        public Bai3()
        {
            InitializeComponent();
        }

        private void btn_Server_Click(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            Thread ServerThrd = new Thread(ServerThread);
            ServerThrd.Start();
            Thread isServerAli = new Thread(() => isServerAlive(ServerThrd));
            isServerAli.Start();
        }

        private void ServerThread()
        {
            Bai3_Server ChatServer = new Bai3_Server();
            ChatServer.ShowDialog();
        }

        private void isServerAlive(Thread ServerThread)
        {
            while (true)
            {
                if (ServerThread.IsAlive)
                {
                    btn_Server.Enabled = false;
                }
                else
                {
                    btn_Server.Enabled = true;
                    break;
                }
            }
        }

        private List<Bai3_Client> clientForms = new List<Bai3_Client>(); // Track client forms

        private void btn_Client_Click(object sender, EventArgs e)
        {
            Bai3_Client chatClientForm = new Bai3_Client();
            chatClientForm.Show();
            btn_Client.Enabled = true;
        }
    }
}
