using static System.Net.Mime.MediaTypeNames;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;

namespace _22520853_Lab06
{
    partial class Bai3_Client
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tb_NameOfClient = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Connect = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_Message = new System.Windows.Forms.TextBox();
            this.btn_SendMessage = new System.Windows.Forms.Button();
            this.lv_messageLog = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // tb_NameOfClient
            // 
            this.tb_NameOfClient.Location = new System.Drawing.Point(26, 310);
            this.tb_NameOfClient.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_NameOfClient.Name = "tb_NameOfClient";
            this.tb_NameOfClient.Size = new System.Drawing.Size(160, 22);
            this.tb_NameOfClient.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 292);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Your name ";
            // 
            // btn_Connect
            // 
            this.btn_Connect.BackColor = System.Drawing.Color.Silver;
            this.btn_Connect.Location = new System.Drawing.Point(211, 309);
            this.btn_Connect.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Connect.Name = "btn_Connect";
            this.btn_Connect.Size = new System.Drawing.Size(94, 23);
            this.btn_Connect.TabIndex = 3;
            this.btn_Connect.Text = "Connect";
            this.btn_Connect.UseVisualStyleBackColor = false;
            this.btn_Connect.Click += new System.EventHandler(this.btn_Connect_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 342);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Message";
            // 
            // tb_Message
            // 
            this.tb_Message.Location = new System.Drawing.Point(26, 360);
            this.tb_Message.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_Message.Name = "tb_Message";
            this.tb_Message.Size = new System.Drawing.Size(490, 22);
            this.tb_Message.TabIndex = 5;
            // 
            // btn_SendMessage
            // 
            this.btn_SendMessage.BackColor = System.Drawing.Color.Silver;
            this.btn_SendMessage.Location = new System.Drawing.Point(541, 358);
            this.btn_SendMessage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_SendMessage.Name = "btn_SendMessage";
            this.btn_SendMessage.Size = new System.Drawing.Size(94, 23);
            this.btn_SendMessage.TabIndex = 6;
            this.btn_SendMessage.Text = "Send";
            this.btn_SendMessage.UseVisualStyleBackColor = false;
            this.btn_SendMessage.Click += new System.EventHandler(this.btn_SendMessage_Click);
            // 
            // lv_messageLog
            // 
            this.lv_messageLog.HideSelection = false;
            this.lv_messageLog.Location = new System.Drawing.Point(26, 20);
            this.lv_messageLog.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lv_messageLog.Name = "lv_messageLog";
            this.lv_messageLog.Size = new System.Drawing.Size(609, 270);
            this.lv_messageLog.TabIndex = 7;
            this.lv_messageLog.UseCompatibleStateImageBehavior = false;
            this.lv_messageLog.View = System.Windows.Forms.View.List;
            // 
            // Bai3_Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(676, 415);
            this.Controls.Add(this.lv_messageLog);
            this.Controls.Add(this.btn_SendMessage);
            this.Controls.Add(this.tb_Message);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_Connect);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_NameOfClient);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Bai3_Client";
            this.Text = "Bai3_Client";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MaskedTextBox tb_NameOfClient;
        private Label label1;
        private Button btn_Connect;
        private Label label2;
        private TextBox tb_Message;
        private Button btn_SendMessage;
        private ListView lv_messageLog;
    }
}