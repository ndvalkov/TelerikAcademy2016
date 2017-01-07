using System;
using System.Windows.Forms;
using StockApp.Utils;

namespace StockApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // StockInfoProvider.Start();
            StockInfoProv.Start();

            // "ndvalkov@abv.bg", "nicke23"
            // new Profile.User().SignUp("ndvalkov@abv.bg", "nicke23");
            // new Profile.User().SignUp("ndvalkos", "nicke23");

            // new Profile.User().SignIn("ndvalkos@ss.aa", "ddssss");

            new Profile.User().SignIn("ndvalkov@abv.bg", "nicke23");

        }
    }
}
