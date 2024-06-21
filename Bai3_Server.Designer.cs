using static System.Net.Mime.MediaTypeNames;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;

namespace _22520853_Lab06
{
    partial class Bai3_Server
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
            this.btn_Listen = new System.Windows.Forms.Button();
            this.lv_ListLog = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // btn_Listen
            // 
            this.btn_Listen.Location = new System.Drawing.Point(473, 18);
            this.btn_Listen.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Listen.Name = "btn_Listen";
            this.btn_Listen.Size = new System.Drawing.Size(94, 23);
            this.btn_Listen.TabIndex = 1;
            this.btn_Listen.Text = "Listen";
            this.btn_Listen.UseVisualStyleBackColor = true;
            this.btn_Listen.Click += new System.EventHandler(this.btn_Listen_Click);
            // 
            // lv_ListLog
            // 
            this.lv_ListLog.HideSelection = false;
            this.lv_ListLog.Location = new System.Drawing.Point(12, 54);
            this.lv_ListLog.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lv_ListLog.Name = "lv_ListLog";
            this.lv_ListLog.Size = new System.Drawing.Size(555, 278);
            this.lv_ListLog.TabIndex = 2;
            this.lv_ListLog.UseCompatibleStateImageBehavior = false;
            this.lv_ListLog.View = System.Windows.Forms.View.List;
            // 
            // Bai3_Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 348);
            this.Controls.Add(this.lv_ListLog);
            this.Controls.Add(this.btn_Listen);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Bai3_Server";
            this.Text = "Bai3_Server";
            this.ResumeLayout(false);

        }

        #endregion
        private Button btn_Listen;
        private ListView lv_ListLog;
    }
}