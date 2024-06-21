using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace _22520853_Lab06
{
    public partial class Bai3_Server : Form
    {
        private List<Socket> listClient;
        private IPEndPoint ipepServer;
        private Socket listenerSocket;
        private Thread listenThread;

        public Bai3_Server()
        {
            InitializeComponent();
        }

        private static readonly byte[] Key = Encoding.UTF8.GetBytes("0123456789ABCDEF0123456789ABCDEF");
        private static readonly byte[] IV = Encoding.UTF8.GetBytes("ABCDEF9876543210");

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

        private void btn_Listen_Click(object sender, EventArgs e)
        {
            StartListening();
        }

        private void StartListening()
        {
            if (listenThread == null || !listenThread.IsAlive)
            {
                listenThread = new Thread(ListenThread);
                listenThread.Start();
                btn_Listen.Enabled = false;
                btn_Listen.Text = "Listening...";
            }
        }

        private void ListenThread()
        {
            try
            {
                listClient = new List<Socket>();
                listenerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                ipepServer = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8080);
                listenerSocket.Bind(ipepServer);
                listenerSocket.Listen(10);

                Invoke(new Action(() =>
                {
                    lv_ListLog.Items.Add("Listening on : " + ipepServer.ToString());
                }));

                while (true)
                {
                    Socket clientSocket = listenerSocket.Accept();
                    listClient.Add(clientSocket);
                    string welcomeMsg = "Message From Server: Hi, Welcome to Room Chat!";
                    byte[] encryptedWelcome = Encrypt(welcomeMsg);
                    clientSocket.Send(encryptedWelcome);
                    Invoke(new Action(() =>
                    {
                        lv_ListLog.Items.Add("New Client Connected: " + clientSocket.RemoteEndPoint.ToString());
                    }));

                    Thread receiver = new Thread(() => ReceiveDataThread(clientSocket));
                    receiver.Start();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void ReceiveDataThread(Socket clientSocket)
        {
            try
            {
                byte[] recv = new byte[1024];
                while (true)
                {
                    int bytesReceived = clientSocket.Receive(recv);
                    if (bytesReceived == 0)
                    {
                        CloseClientConnection(clientSocket);
                        return;
                    }
                    byte[] receivedData = new byte[bytesReceived];
                    Array.Copy(recv, receivedData, bytesReceived);
                    string msg = Decrypt(receivedData);
                    string listViewString = clientSocket.RemoteEndPoint.ToString() + ": " + msg;
                    Invoke(new Action(() =>
                    {
                        lv_ListLog.Items.Add(listViewString);
                    }));
                    Broadcast(msg);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void CloseClientConnection(Socket clientSocket)
        {
            clientSocket.Close();
            listClient.Remove(clientSocket);
            Invoke(new Action(() =>
            {
                lv_ListLog.Items.Add("Client Disconnected: " + clientSocket.RemoteEndPoint.ToString());
            }));
        }

        private void Broadcast(string msg)
        {
            foreach (var item in listClient)
            {
                byte[] data = Encrypt(msg);
                item.Send(data);
            }
        }

        private void Task_3_Server_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (listenerSocket != null && listenerSocket.Connected)
            {
                listenerSocket.Close();
            }
            foreach (var client in listClient)
            {
                if (client != null && client.Connected)
                {
                    client.Close();
                }
            }
        }
    }
}
