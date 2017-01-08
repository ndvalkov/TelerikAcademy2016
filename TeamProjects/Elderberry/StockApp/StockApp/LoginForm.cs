using System;
using System.Windows.Forms;
using Firebase.Auth;
using StockApp.Utils;

namespace StockApp
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // StockInfoProvider.Start();
            StockInfoProv.Start();
            // Bloomberg.Start();

            // "ndvalkov@abv.bg", "nicke23"
            // new Profile.User().SignUp("ndvalkov@abv.bg", "nicke23");
            // new Profile.User().SignUp("ndvalkos", "nicke23");

            // new Profile.User().SignIn("ndvalkos@ss.aa", "ddssss");

            // new Profile.User().SignIn("ndvalkov@abv.bg", "nicke23");

        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            string userName = this.UserNameEdit.Text.Trim();
            string password = this.PasswordEdit.Text.Trim();
            new Profile.User().SignUp(userName, password);
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            string userName = this.UserNameEdit.Text.Trim();
            string password = this.PasswordEdit.Text.Trim();
            new Profile.User().SignIn(userName, password);
        }
    }
}
