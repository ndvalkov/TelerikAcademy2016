using System;
using System.Windows.Forms;
using DefiningClasses;
using Firebase.Auth;

namespace StockApp.Profile
{
    class User
    {
        public User()
        {

        }

        public async void SignUp(string email, string password)
        {
            try
            {
                SimpleValidator.CheckNullOrEmpty(email, "email");
                SimpleValidator.CheckNullOrEmpty(password, "password");
            }
            catch (ArgumentException e)
            {
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show("Invalid email or password", e.Message, buttons);
                return;
            }

            if (password.Length < 6)
            {
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show("Password must be at least 6 chars long", "", buttons);
                return;
            }


            // teamelderberry.firebaseapp.com
            FirebaseAuthProvider authProvider = new FirebaseAuthProvider(new FirebaseConfig("AIzaSyCs3jVuwKl9ntdSaJWvGqzAzGoVX7Xblk4"));

            try
            {
                var authLink = await authProvider.CreateUserWithEmailAndPasswordAsync(email, password);
            }
            catch (FirebaseAuthException e)
            {
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                if (e.Reason.ToString().Equals("EmailExists"))
                {
                    MessageBox.Show("The account already exists", "", buttons);
                }
                else
                {
                    MessageBox.Show(e.Reason.ToString(), "", buttons);
                }
                
                return;
            }


            // TODO: Sign up successful, notify and redirect to main Form
            // TODO: Refactor
            MainForm main = Application.OpenForms["MainForm"] as MainForm;

            if (main != null)
            {
                main.ShowDialog();
            }
            else
            {
                new MainForm().ShowDialog();
            }

            // FirebaseAuthLink authLink = await authProvider.CreateUserWithEmailAndPasswordAsync(email, password);

            Console.WriteLine();
        }

        public async void SignIn(string email, string password)
        {
            try
            {
                SimpleValidator.CheckNullOrEmpty(email, "email");
                SimpleValidator.CheckNullOrEmpty(password, "password");
            }
            catch (ArgumentException e)
            {
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show("Invalid email or password", e.Message, buttons);
                return;
            }

            if (password.Length < 6)
            {
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show("Password must be at least 6 chars long", "", buttons);
                return;
            }


            // teamelderberry.firebaseapp.com
            FirebaseAuthProvider authProvider = new FirebaseAuthProvider(new FirebaseConfig("AIzaSyCs3jVuwKl9ntdSaJWvGqzAzGoVX7Xblk4"));

            try
            {
                // TODO: Figure out what to do with the response
                var authLink = await authProvider.SignInWithEmailAndPasswordAsync(email, password);
            }
            catch (FirebaseAuthException e)
            {
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(e.Reason.ToString(), "", buttons);

                return;
            }


            // TODO: Sign in successful, notify and redirect to main Form
            // TODO: Refactor
            MainForm main = Application.OpenForms["MainForm"] as MainForm;

            if (main != null)
            {
                main.ShowDialog();
            }
            else
            {
                new MainForm().ShowDialog();
            }

            // FirebaseAuthLink authLink = await authProvider.CreateUserWithEmailAndPasswordAsync(email, password);

            Console.WriteLine();
        }
    }
}
