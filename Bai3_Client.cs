using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace _22520853_Lab06
{
    public partial class Bai3_Client : Form
    {
        private static readonly byte[] Key = Encoding.UTF8.GetBytes("0123456789ABCDEF0123456789ABCDEF");
        private static readonly byte[] IV = Encoding.UTF8.GetBytes("ABCDEF9876543210");
        private TcpClient tcpClient;
        private NetworkStream ns;
        private string clientName;

        public Bai3_Client()
        {
            InitializeComponent();
        }

        private byte[] Encrypt(string plainText)
        {
            using (var aes = Aes.Create())
            {
                aes.Key = Key;
                aes.IV = IV;
                var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (var ms = new MemoryStream())
                {
                    using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    using (var sw = new StreamWriter(cs))
                    {
                        sw.Write(plainText);
                    }
                    return ms.ToArray();
                }
            }
        }

        private string Decrypt(byte[] cipherText)
        {
            using (var aes = Aes.Create())
            {
                aes.Key = Key;
                aes.IV = IV;
                var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (var ms = new MemoryStream(cipherText))
                using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                using (var sr = new StreamReader(cs))
                {
                    return sr.ReadToEnd();
                }
            }
        }

        private void btn_Connect_Click(object sender, EventArgs e)
        {
            ConnectToServer();
        }

        private void ConnectToServer()
        {
            try
            {
                tcpClient = new TcpClient();
                tcpClient.Connect(IPAddress.Parse("127.0.0.1"), 8080);
                ns = tcpClient.GetStream();
                Thread receiver = new Thread(ReceiveFromServer);
                receiver.Start();
                btn_Connect.Enabled = false;
                clientName = tb_NameOfClient.Text.Trim();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void ReceiveFromServer()
        {
            try
            {
                byte[] recv = new byte[1024];
                while (true)
                {
                    int bytesReceived = ns.Read(recv, 0, recv.Length);
                    if (bytesReceived == 0)
                    {
                        MessageBox.Show("Server disconnected");
                        CloseClient();
                        return;
                    }
                    byte[] receivedData = new byte[bytesReceived];
                    Array.Copy(recv, receivedData, bytesReceived);
                    string decryptedText = Decrypt(receivedData);
                    UpdateUIThread(decryptedText);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                CloseClient();
            }
        }

        private void UpdateUIThread(string text)
        {
            if (lv_messageLog.InvokeRequired)
            {
                lv_messageLog.Invoke(new Action<string>(UpdateUIThread), text);
            }
            else
            {
                lv_messageLog.Items.Add(text);
            }
        }

        private void btn_SendMessage_Click(object sender, EventArgs e)
        {
            SendMess(tb_Message.Text);
        }

        private void SendMess(string text)
        {
            string fullMessage = clientName + ": " + text;
            byte[] data = Encrypt(fullMessage);
            ns.Write(data, 0, data.Length);
            tb_Message.Text = ""; // Clear the message textbox
        }

        private void CloseClient()
        {
            if (tcpClient != null)
            {
                tcpClient.Close();
            }
        }

        private void Task_3_Client_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseClient();
        }
    }
}
