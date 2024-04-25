namespace toyproject_portfolio
{
    partial class FrmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            groupBox1 = new GroupBox();
            lblOut1 = new Label();
            lblin1 = new Label();
            BtnFind = new Button();
            groupBox2 = new GroupBox();
            lblParkingFee = new Label();
            BtnOut = new Button();
            BtnIn = new Button();
            panel1 = new Panel();
            lblNowTime = new Label();
            label4 = new Label();
            TxtPrice = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            TxtTime = new TextBox();
            timerMain = new System.Windows.Forms.Timer(components);
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblOut1);
            groupBox1.Controls.Add(lblin1);
            groupBox1.Controls.Add(BtnFind);
            groupBox1.Controls.Add(groupBox2);
            groupBox1.Controls.Add(BtnOut);
            groupBox1.Controls.Add(BtnIn);
            groupBox1.Location = new Point(0, 77);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(582, 170);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "조회";
            // 
            // lblOut1
            // 
            lblOut1.AutoSize = true;
            lblOut1.Location = new Point(186, 84);
            lblOut1.Name = "lblOut1";
            lblOut1.Size = new Size(39, 15);
            lblOut1.TabIndex = 6;
            lblOut1.Text = "label6";
            // 
            // lblin1
            // 
            lblin1.AutoSize = true;
            lblin1.Location = new Point(186, 31);
            lblin1.Name = "lblin1";
            lblin1.Size = new Size(39, 15);
            lblin1.TabIndex = 5;
            lblin1.Text = "label5";
            // 
            // BtnFind
            // 
            BtnFind.Location = new Point(392, 16);
            BtnFind.Name = "BtnFind";
            BtnFind.Size = new Size(75, 38);
            BtnFind.TabIndex = 3;
            BtnFind.Text = "정산";
            BtnFind.UseVisualStyleBackColor = true;
            BtnFind.Click += BtnFind_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(lblParkingFee);
            groupBox2.Location = new Point(392, 64);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(178, 100);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "현재 금액";
            // 
            // lblParkingFee
            // 
            lblParkingFee.AutoSize = true;
            lblParkingFee.Location = new Point(71, 46);
            lblParkingFee.Name = "lblParkingFee";
            lblParkingFee.Size = new Size(39, 15);
            lblParkingFee.TabIndex = 0;
            lblParkingFee.Text = "label5";
            // 
            // BtnOut
            // 
            BtnOut.Location = new Point(19, 75);
            BtnOut.Name = "BtnOut";
            BtnOut.Size = new Size(75, 32);
            BtnOut.TabIndex = 1;
            BtnOut.Text = "출고";
            BtnOut.UseVisualStyleBackColor = true;
            BtnOut.Click += BtnOut_Click;
            // 
            // BtnIn
            // 
            BtnIn.Location = new Point(19, 22);
            BtnIn.Name = "BtnIn";
            BtnIn.Size = new Size(75, 32);
            BtnIn.TabIndex = 0;
            BtnIn.Text = "입고";
            BtnIn.UseVisualStyleBackColor = true;
            BtnIn.Click += BtnIn_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(lblNowTime);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(TxtPrice);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(TxtTime);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(582, 71);
            panel1.TabIndex = 1;
            // 
            // lblNowTime
            // 
            lblNowTime.AutoSize = true;
            lblNowTime.Location = new Point(463, 28);
            lblNowTime.Name = "lblNowTime";
            lblNowTime.Size = new Size(39, 15);
            lblNowTime.TabIndex = 6;
            lblNowTime.Text = "label5";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(392, 28);
            label4.Name = "label4";
            label4.Size = new Size(19, 15);
            label4.TabIndex = 5;
            label4.Text = "원";
            // 
            // TxtPrice
            // 
            TxtPrice.Location = new Point(283, 25);
            TxtPrice.Name = "TxtPrice";
            TxtPrice.Size = new Size(100, 23);
            TxtPrice.TabIndex = 4;
            TxtPrice.Text = "1,000";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(246, 28);
            label3.Name = "label3";
            label3.Size = new Size(31, 15);
            label3.TabIndex = 3;
            label3.Text = "금액";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(186, 28);
            label2.Name = "label2";
            label2.Size = new Size(19, 15);
            label2.TabIndex = 2;
            label2.Text = "분";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(19, 28);
            label1.Name = "label1";
            label1.Size = new Size(55, 15);
            label1.TabIndex = 1;
            label1.Text = "단위시간";
            // 
            // TxtTime
            // 
            TxtTime.Location = new Point(80, 25);
            TxtTime.Name = "TxtTime";
            TxtTime.Size = new Size(100, 23);
            TxtTime.TabIndex = 0;
            TxtTime.Text = "60";
            // 
            // timerMain
            // 
            timerMain.Interval = 1000;
            timerMain.Tick += timerMain_Tick;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(582, 259);
            Controls.Add(panel1);
            Controls.Add(groupBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "주차관리시스템";
            Load += FrmMain_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Panel panel1;
        private GroupBox groupBox2;
        private Button BtnOut;
        private Button BtnIn;
        private Label label4;
        private TextBox TxtPrice;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox TxtTime;
        private Button BtnFind;
        private System.Windows.Forms.Timer timerMain;
        private Label lblOut1;
        private Label lblin1;
        private Label lblNowTime;
        private Label lblParkingFee;
    }
}
