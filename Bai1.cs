using System;
using System.Windows.Forms;

namespace _22520853_Lab06
{
    public partial class Bai1 : Form
    {
        public Bai1()
        {
            InitializeComponent();
        }

        private void encryptButton_Click(object sender, EventArgs e)
        {
            int shift;
            if (int.TryParse(shiftTextBox.Text, out shift))
            {
                string input = inputTextBox.Text;
                bt_Encrypt.Text = Encrypt(input, shift);
            }
            else
            {
                MessageBox.Show("Vui lòng nhập một số hợp lệ cho dịch chuyển (Shift).");
            }
        }

        private void decryptButton_Click(object sender, EventArgs e)
        {
            int shift;
            if (int.TryParse(shiftTextBox.Text, out shift))
            {
                string input = bt_Encrypt.Text;
                tb_Decrypt.Text = Decrypt(input, shift); // Fix here: Changed textBox1.Text to outputTextBox.Text
            }
            else
            {
                MessageBox.Show("Vui lòng nhập một số hợp lệ cho dịch chuyển (Shift).");
            }
        }

        private string Encrypt(string text, int shift)
        {
            string result = "";
            foreach (char c in text)
            {
                if (char.IsLetter(c))
                {
                    char offset = char.IsUpper(c) ? 'A' : 'a';
                    result += (char)(((c + shift - offset) % 26) + offset);
                }
                else
                {
                    result += c;
                }
            }
            return result;
        }

        private string Decrypt(string text, int shift)
        {
            // Thực hiện giải mã với dịch chuyển ngược lại
            return Encrypt(text, 26 - shift);
        }
    }
}
