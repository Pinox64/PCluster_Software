
using System.Windows.Forms;

namespace PCluster_PC_Utility
{
  partial class Form1
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
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
      this.comboBox1 = new System.Windows.Forms.ComboBox();
      this.comboBox2 = new System.Windows.Forms.ComboBox();
      this.comboBox3 = new System.Windows.Forms.ComboBox();
      this.comboBox4 = new System.Windows.Forms.ComboBox();
      this.comboBox5 = new System.Windows.Forms.ComboBox();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.trackBar1 = new System.Windows.Forms.TrackBar();
      this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
      this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.exitMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
      this.exitMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
      this.statusStrip1 = new System.Windows.Forms.StatusStrip();
      this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
      this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
      this.buttonBootloader = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
      this.contextMenuStrip.SuspendLayout();
      this.statusStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // comboBox1
      // 
      this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.comboBox1.FormattingEnabled = true;
      this.comboBox1.Items.AddRange(new object[] {
            "OFF",
            "CPU Usage",
            "CPU Temp",
            "Memory Usage",
            "GPU Usage",
            "GPU Temp",
            "Disk Speed",
            "Disk Usage",
            "Internet Speed"});
      this.comboBox1.Location = new System.Drawing.Point(70, 63);
      this.comboBox1.Name = "comboBox1";
      this.comboBox1.Size = new System.Drawing.Size(121, 21);
      this.comboBox1.TabIndex = 2;
      this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
      // 
      // comboBox2
      // 
      this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.comboBox2.FormattingEnabled = true;
      this.comboBox2.Items.AddRange(new object[] {
            "OFF",
            "CPU Usage",
            "CPU Temp",
            "Memory Usage",
            "GPU Usage",
            "GPU Temp",
            "Disk Speed",
            "Disk Usage",
            "Internet Speed"});
      this.comboBox2.Location = new System.Drawing.Point(197, 63);
      this.comboBox2.Name = "comboBox2";
      this.comboBox2.Size = new System.Drawing.Size(121, 21);
      this.comboBox2.TabIndex = 3;
      this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
      // 
      // comboBox3
      // 
      this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.comboBox3.FormattingEnabled = true;
      this.comboBox3.Items.AddRange(new object[] {
            "OFF",
            "CPU Usage",
            "CPU Temp",
            "Memory Usage",
            "GPU Usage",
            "GPU Temp",
            "Disk Speed",
            "Disk Usage",
            "Internet Speed"});
      this.comboBox3.Location = new System.Drawing.Point(324, 63);
      this.comboBox3.Name = "comboBox3";
      this.comboBox3.Size = new System.Drawing.Size(121, 21);
      this.comboBox3.TabIndex = 4;
      this.comboBox3.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
      // 
      // comboBox4
      // 
      this.comboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.comboBox4.FormattingEnabled = true;
      this.comboBox4.Items.AddRange(new object[] {
            "OFF",
            "CPU Usage",
            "CPU Temp",
            "Memory Usage",
            "GPU Usage",
            "GPU Temp",
            "Disk Speed",
            "Disk Usage",
            "Internet Speed"});
      this.comboBox4.Location = new System.Drawing.Point(451, 63);
      this.comboBox4.Name = "comboBox4";
      this.comboBox4.Size = new System.Drawing.Size(121, 21);
      this.comboBox4.TabIndex = 5;
      this.comboBox4.SelectedIndexChanged += new System.EventHandler(this.comboBox4_SelectedIndexChanged);
      // 
      // comboBox5
      // 
      this.comboBox5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.comboBox5.FormattingEnabled = true;
      this.comboBox5.Items.AddRange(new object[] {
            "OFF",
            "Solid",
            "Gradual",
            "Rainbow"});
      this.comboBox5.Location = new System.Drawing.Point(578, 63);
      this.comboBox5.Name = "comboBox5";
      this.comboBox5.Size = new System.Drawing.Size(121, 21);
      this.comboBox5.TabIndex = 6;
      this.comboBox5.SelectedIndexChanged += new System.EventHandler(this.comboBox5_SelectedIndexChanged);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(67, 47);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(47, 13);
      this.label1.TabIndex = 7;
      this.label1.Text = "Display1";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(194, 47);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(47, 13);
      this.label2.TabIndex = 8;
      this.label2.Text = "Display2";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(321, 47);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(47, 13);
      this.label3.TabIndex = 9;
      this.label3.Text = "Display3";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(448, 47);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(47, 13);
      this.label4.TabIndex = 10;
      this.label4.Text = "Display4";
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(575, 47);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(30, 13);
      this.label5.TabIndex = 11;
      this.label5.Text = "Light";
      // 
      // trackBar1
      // 
      this.trackBar1.Location = new System.Drawing.Point(578, 90);
      this.trackBar1.Name = "trackBar1";
      this.trackBar1.Size = new System.Drawing.Size(121, 45);
      this.trackBar1.TabIndex = 13;
      this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
      // 
      // notifyIcon1
      // 
      this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip;
      this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
      this.notifyIcon1.Text = this.Text;
      this.notifyIcon1.Visible = true;
      this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
      // 
      // contextMenuStrip
      // 
      this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitMenuItem1,
            this.exitMenuItem2});
      this.contextMenuStrip.Name = "contextMenuStrip";
      this.contextMenuStrip.Size = new System.Drawing.Size(151, 48);
      // 
      // exitMenuItem1
      // 
      this.exitMenuItem1.Name = "exitMenuItem1";
      this.exitMenuItem1.Size = new System.Drawing.Size(150, 22);
      this.exitMenuItem1.Text = "Exit";
      this.exitMenuItem1.Click += new System.EventHandler(this.exitMenuItem1_Click_1);
      // 
      // exitMenuItem2
      // 
      this.exitMenuItem2.Name = "exitMenuItem2";
      this.exitMenuItem2.Size = new System.Drawing.Size(150, 22);
      this.exitMenuItem2.Text = "Show Window";
      this.exitMenuItem2.Click += new System.EventHandler(this.exitMenuItem2_Click_1);
      // 
      // statusStrip1
      // 
      this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
      this.statusStrip1.Location = new System.Drawing.Point(0, 148);
      this.statusStrip1.Name = "statusStrip1";
      this.statusStrip1.Size = new System.Drawing.Size(800, 22);
      this.statusStrip1.TabIndex = 14;
      this.statusStrip1.Text = "statusStrip1";
      // 
      // toolStripStatusLabel1
      // 
      this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
      this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
      // 
      // toolStripStatusLabel2
      // 
      this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
      this.toolStripStatusLabel2.Size = new System.Drawing.Size(117, 17);
      this.toolStripStatusLabel2.Text = "Device Disconnected";
      // 
      // buttonBootloader
      // 
      this.buttonBootloader.Location = new System.Drawing.Point(70, 111);
      this.buttonBootloader.Name = "buttonBootloader";
      this.buttonBootloader.Size = new System.Drawing.Size(121, 24);
      this.buttonBootloader.TabIndex = 15;
      this.buttonBootloader.Text = "BootLoader";
      this.buttonBootloader.UseVisualStyleBackColor = true;
      this.buttonBootloader.Click += new System.EventHandler(this.buttonBootloader_Click);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 170);
      this.Controls.Add(this.buttonBootloader);
      this.Controls.Add(this.statusStrip1);
      this.Controls.Add(this.trackBar1);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.comboBox5);
      this.Controls.Add(this.comboBox4);
      this.Controls.Add(this.comboBox3);
      this.Controls.Add(this.comboBox2);
      this.Controls.Add(this.comboBox1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "Form1";
      this.Text = "PCluster";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
      this.Load += new System.EventHandler(this.Form1_Load);
      this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
      ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
      this.contextMenuStrip.ResumeLayout(false);
      this.statusStrip1.ResumeLayout(false);
      this.statusStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.ComboBox comboBox1;
    private System.Windows.Forms.ComboBox comboBox2;
    private System.Windows.Forms.ComboBox comboBox3;
    private System.Windows.Forms.ComboBox comboBox4;
    private System.Windows.Forms.ComboBox comboBox5;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
    private ContextMenuStrip contextMenuStrip;
    private ToolStripMenuItem exitMenuItem1;
    private ToolStripMenuItem exitMenuItem2;
    private StatusStrip statusStrip1;
    private ToolStripStatusLabel toolStripStatusLabel1;
    private ToolStripStatusLabel toolStripStatusLabel2;
        private Button buttonBootloader;
    }
}

