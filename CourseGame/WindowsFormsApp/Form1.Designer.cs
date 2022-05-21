
namespace WindowsFormsApp
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
            this.button1 = new System.Windows.Forms.Button();
            this.BluePlayerHealth = new System.Windows.Forms.TextBox();
            this.RedPlayerHealth = new System.Windows.Forms.TextBox();
            this.BPCountBullets = new System.Windows.Forms.TextBox();
            this.RPCountBullets = new System.Windows.Forms.TextBox();
            this.WinPlayer = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(242, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // BluePlayerHealth
            // 
            this.BluePlayerHealth.Location = new System.Drawing.Point(30, 25);
            this.BluePlayerHealth.Name = "BluePlayerHealth";
            this.BluePlayerHealth.Size = new System.Drawing.Size(100, 20);
            this.BluePlayerHealth.TabIndex = 1;
            this.BluePlayerHealth.Text = "1";
            // 
            // RedPlayerHealth
            // 
            this.RedPlayerHealth.Location = new System.Drawing.Point(31, 55);
            this.RedPlayerHealth.Name = "RedPlayerHealth";
            this.RedPlayerHealth.Size = new System.Drawing.Size(100, 20);
            this.RedPlayerHealth.TabIndex = 2;
            this.RedPlayerHealth.Text = "1";
            // 
            // BPCountBullets
            // 
            this.BPCountBullets.Location = new System.Drawing.Point(136, 25);
            this.BPCountBullets.Name = "BPCountBullets";
            this.BPCountBullets.Size = new System.Drawing.Size(100, 20);
            this.BPCountBullets.TabIndex = 3;
            // 
            // RPCountBullets
            // 
            this.RPCountBullets.Location = new System.Drawing.Point(137, 55);
            this.RPCountBullets.Name = "RPCountBullets";
            this.RPCountBullets.Size = new System.Drawing.Size(100, 20);
            this.RPCountBullets.TabIndex = 4;
            // 
            // WinPlayer
            // 
            this.WinPlayer.AutoSize = true;
            this.WinPlayer.Location = new System.Drawing.Point(130, 67);
            this.WinPlayer.Name = "WinPlayer";
            this.WinPlayer.Size = new System.Drawing.Size(0, 13);
            this.WinPlayer.TabIndex = 6;
            this.WinPlayer.Click += new System.EventHandler(this.WinPlayer_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(170, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Пули";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "XP";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "1";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 85);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.WinPlayer);
            this.Controls.Add(this.RPCountBullets);
            this.Controls.Add(this.BPCountBullets);
            this.Controls.Add(this.RedPlayerHealth);
            this.Controls.Add(this.BluePlayerHealth);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox BluePlayerHealth;
        private System.Windows.Forms.TextBox RedPlayerHealth;
        private System.Windows.Forms.TextBox BPCountBullets;
        private System.Windows.Forms.TextBox RPCountBullets;
        private System.Windows.Forms.Label WinPlayer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}