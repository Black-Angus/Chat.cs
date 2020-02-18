namespace ClientSide
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.namebox = new System.Windows.Forms.TextBox();
            this.psbox = new System.Windows.Forms.TextBox();
            this.loginbut = new System.Windows.Forms.Button();
            this.Info = new System.Windows.Forms.Label();
            this.Register = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Username";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Password";
            // 
            // namebox
            // 
            this.namebox.Location = new System.Drawing.Point(73, 34);
            this.namebox.Name = "namebox";
            this.namebox.Size = new System.Drawing.Size(100, 20);
            this.namebox.TabIndex = 3;
            // 
            // psbox
            // 
            this.psbox.Location = new System.Drawing.Point(73, 60);
            this.psbox.Name = "psbox";
            this.psbox.Size = new System.Drawing.Size(100, 20);
            this.psbox.TabIndex = 4;
            this.psbox.TextChanged += new System.EventHandler(this.psbox_TextChanged);
            // 
            // loginbut
            // 
            this.loginbut.Location = new System.Drawing.Point(73, 86);
            this.loginbut.Name = "loginbut";
            this.loginbut.Size = new System.Drawing.Size(75, 23);
            this.loginbut.TabIndex = 5;
            this.loginbut.Text = "Login";
            this.loginbut.UseVisualStyleBackColor = true;
            this.loginbut.Click += new System.EventHandler(this.loginbut_Click);
            // 
            // Info
            // 
            this.Info.AutoSize = true;
            this.Info.Location = new System.Drawing.Point(12, 9);
            this.Info.Name = "Info";
            this.Info.Size = new System.Drawing.Size(25, 13);
            this.Info.TabIndex = 6;
            this.Info.Text = "Info";
            this.Info.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Register
            // 
            this.Register.Location = new System.Drawing.Point(73, 115);
            this.Register.Name = "Register";
            this.Register.Size = new System.Drawing.Size(75, 23);
            this.Register.TabIndex = 7;
            this.Register.Text = "Register";
            this.Register.UseVisualStyleBackColor = true;
            this.Register.Click += new System.EventHandler(this.Register_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(208, 155);
            this.ControlBox = false;
            this.Controls.Add(this.Register);
            this.Controls.Add(this.Info);
            this.Controls.Add(this.loginbut);
            this.Controls.Add(this.psbox);
            this.Controls.Add(this.namebox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox namebox;
        private System.Windows.Forms.TextBox psbox;
        private System.Windows.Forms.Button loginbut;
        private System.Windows.Forms.Label Info;
        private System.Windows.Forms.Button Register;
    }
}

