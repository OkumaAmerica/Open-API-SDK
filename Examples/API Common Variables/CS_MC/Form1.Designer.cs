namespace CS_MC
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
            this.btnRefresh = new System.Windows.Forms.Button();
            this.tbNo2 = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.tbNo1 = new System.Windows.Forms.TextBox();
            this.btnWrite = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackgroundImage = global::CS_MC.Properties.Resources.Data_Synchronize;
            this.btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRefresh.Location = new System.Drawing.Point(18, 126);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(72, 72);
            this.btnRefresh.TabIndex = 48;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // tbNo2
            // 
            this.tbNo2.Location = new System.Drawing.Point(113, 87);
            this.tbNo2.Name = "tbNo2";
            this.tbNo2.Size = new System.Drawing.Size(100, 20);
            this.tbNo2.TabIndex = 43;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.BackColor = System.Drawing.SystemColors.Window;
            this.Label4.Location = new System.Drawing.Point(72, 90);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(35, 13);
            this.Label4.TabIndex = 47;
            this.Label4.Text = "NO. 2";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.BackColor = System.Drawing.SystemColors.Window;
            this.Label3.Location = new System.Drawing.Point(72, 63);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(35, 13);
            this.Label3.TabIndex = 46;
            this.Label3.Text = "NO. 1";
            // 
            // btnExit
            // 
            this.btnExit.BackgroundImage = global::CS_MC.Properties.Resources.Fire_Exit;
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(227, 126);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(72, 72);
            this.btnExit.TabIndex = 45;
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // tbNo1
            // 
            this.tbNo1.Location = new System.Drawing.Point(113, 60);
            this.tbNo1.Name = "tbNo1";
            this.tbNo1.Size = new System.Drawing.Size(100, 20);
            this.tbNo1.TabIndex = 42;
            // 
            // btnWrite
            // 
            this.btnWrite.BackgroundImage = global::CS_MC.Properties.Resources.Data_Edit;
            this.btnWrite.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnWrite.Location = new System.Drawing.Point(124, 126);
            this.btnWrite.Name = "btnWrite";
            this.btnWrite.Size = new System.Drawing.Size(72, 72);
            this.btnWrite.TabIndex = 44;
            this.btnWrite.UseVisualStyleBackColor = true;
            this.btnWrite.Click += new System.EventHandler(this.btnWrite_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.BackgroundImage = global::CS_MC.Properties.Resources.Background;
            this.ClientSize = new System.Drawing.Size(320, 210);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.tbNo2);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.tbNo1);
            this.Controls.Add(this.btnWrite);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CV Example";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRefresh;
        internal System.Windows.Forms.TextBox tbNo2;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label3;
        private System.Windows.Forms.Button btnExit;
        internal System.Windows.Forms.TextBox tbNo1;
        private System.Windows.Forms.Button btnWrite;


    }
}

