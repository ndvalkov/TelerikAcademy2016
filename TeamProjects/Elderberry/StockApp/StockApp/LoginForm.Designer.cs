namespace StockApp
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.UserNameEdit = new System.Windows.Forms.TextBox();
            this.PasswordEdit = new System.Windows.Forms.TextBox();
            this.LoginBtn = new System.Windows.Forms.Label();
            this.ExitBtn = new System.Windows.Forms.Label();
            this.SignUpBtn = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.UsernameLabel.Cursor = System.Windows.Forms.Cursors.Default;
            this.UsernameLabel.Font = new System.Drawing.Font("Segoe Script", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UsernameLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.UsernameLabel.Location = new System.Drawing.Point(33, 18);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Padding = new System.Windows.Forms.Padding(5);
            this.UsernameLabel.Size = new System.Drawing.Size(123, 40);
            this.UsernameLabel.TabIndex = 0;
            this.UsernameLabel.Text = "Username";
            this.UsernameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.PasswordLabel.Cursor = System.Windows.Forms.Cursors.Default;
            this.PasswordLabel.Font = new System.Drawing.Font("Segoe Script", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PasswordLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.PasswordLabel.Location = new System.Drawing.Point(313, 18);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Padding = new System.Windows.Forms.Padding(5);
            this.PasswordLabel.Size = new System.Drawing.Size(123, 40);
            this.PasswordLabel.TabIndex = 1;
            this.PasswordLabel.Text = "Password";
            this.PasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UserNameEdit
            // 
            this.UserNameEdit.Font = new System.Drawing.Font("Consolas", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UserNameEdit.Location = new System.Drawing.Point(173, 18);
            this.UserNameEdit.Name = "UserNameEdit";
            this.UserNameEdit.Size = new System.Drawing.Size(123, 41);
            this.UserNameEdit.TabIndex = 2;
            // 
            // PasswordEdit
            // 
            this.PasswordEdit.Font = new System.Drawing.Font("Consolas", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PasswordEdit.Location = new System.Drawing.Point(453, 18);
            this.PasswordEdit.Name = "PasswordEdit";
            this.PasswordEdit.Size = new System.Drawing.Size(123, 41);
            this.PasswordEdit.TabIndex = 3;
            // 
            // LoginBtn
            // 
            this.LoginBtn.BackColor = System.Drawing.Color.Orange;
            this.LoginBtn.Cursor = System.Windows.Forms.Cursors.Default;
            this.LoginBtn.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LoginBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LoginBtn.Location = new System.Drawing.Point(12, 270);
            this.LoginBtn.Name = "LoginBtn";
            this.LoginBtn.Padding = new System.Windows.Forms.Padding(5);
            this.LoginBtn.Size = new System.Drawing.Size(123, 40);
            this.LoginBtn.TabIndex = 4;
            this.LoginBtn.Text = "Login";
            this.LoginBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LoginBtn.Click += new System.EventHandler(this.LoginBtn_Click);
            // 
            // ExitBtn
            // 
            this.ExitBtn.BackColor = System.Drawing.Color.Beige;
            this.ExitBtn.Cursor = System.Windows.Forms.Cursors.Default;
            this.ExitBtn.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ExitBtn.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.ExitBtn.Location = new System.Drawing.Point(468, 270);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Padding = new System.Windows.Forms.Padding(5);
            this.ExitBtn.Size = new System.Drawing.Size(123, 40);
            this.ExitBtn.TabIndex = 5;
            this.ExitBtn.Text = "Exit";
            this.ExitBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ExitBtn.Click += new System.EventHandler(this.label3_Click);
            // 
            // SignUpBtn
            // 
            this.SignUpBtn.BackColor = System.Drawing.Color.Orange;
            this.SignUpBtn.Cursor = System.Windows.Forms.Cursors.Default;
            this.SignUpBtn.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SignUpBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.SignUpBtn.Location = new System.Drawing.Point(12, 219);
            this.SignUpBtn.Name = "SignUpBtn";
            this.SignUpBtn.Padding = new System.Windows.Forms.Padding(5);
            this.SignUpBtn.Size = new System.Drawing.Size(123, 40);
            this.SignUpBtn.TabIndex = 6;
            this.SignUpBtn.Text = "Signup";
            this.SignUpBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.SignUpBtn.Click += new System.EventHandler(this.label4_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(603, 319);
            this.Controls.Add(this.SignUpBtn);
            this.Controls.Add(this.ExitBtn);
            this.Controls.Add(this.LoginBtn);
            this.Controls.Add(this.PasswordEdit);
            this.Controls.Add(this.UserNameEdit);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.UsernameLabel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Login";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label UsernameLabel;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.TextBox UserNameEdit;
        private System.Windows.Forms.TextBox PasswordEdit;
        private System.Windows.Forms.Label LoginBtn;
        private System.Windows.Forms.Label ExitBtn;
        private System.Windows.Forms.Label SignUpBtn;
    }
}

