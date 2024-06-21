using System;
using System.Windows.Forms;

namespace _22520853_Lab06
{
    public partial class Bai2 : Form
    {
        public Bai2()
        {
            InitializeComponent();
        }

        private void encryptButton_Click(object sender, EventArgs e)
        {
            string key = keyTextBox.Text;
            if (string.IsNullOrEmpty(key))
            {
                MessageBox.Show("Vui lòng nhập key.");
                return;
            }

            string input = inputTextBox.Text;
            bt_Encrypt.Text = Encrypt(input, key);
        }

        private void decryptButton_Click(object sender, EventArgs e)
        {
            string key = keyTextBox.Text;
            if (string.IsNullOrEmpty(key))
            {
                MessageBox.Show("Vui lòng nhập key.");
                return;
            }
            string input = bt_Encrypt.Text; // Giả sử bt_Encrypt là TextBox hiển thị văn bản đã mã hóa
            tb_Decrypt.Text = Decrypt(input, key);
        }

        private string Encrypt(string text, string key)
        {
            string result = "";
            int keyIndex = 0;
            foreach (char c in text)
            {
                if (char.IsLetter(c))
                {
                    char offset = char.IsUpper(c) ? 'A' : 'a';
                    int k = (char.IsUpper(key[keyIndex % key.Length]) ? key[keyIndex % key.Length] - 'A' : key[keyIndex % key.Length] - 'a');
                    result += (char)((((c - offset) + k) % 26) + offset);
                    keyIndex++;
                }
                else
                {
                    result += c;
                }
            }
            return result;
        }

        private string Decrypt(string text, string key)
        {
            string result = "";
            int keyIndex = 0;
            foreach (char c in text)
            {
                if (char.IsLetter(c))
                {
                    char offset = char.IsUpper(c) ? 'A' : 'a';
                    int k = (char.IsUpper(key[keyIndex % key.Length]) ? key[keyIndex % key.Length] - 'A' : key[keyIndex % key.Length] - 'a');
                    // Sửa công thức giải mã:
                    int temp = (c - offset - k + 26) % 26;
                    result += (char)(temp + offset);
                    keyIndex++;
                }
                else
                {
                    result += c;
                }
            }
            return result;
        }

        
    }
}
