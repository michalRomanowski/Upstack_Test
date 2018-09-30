using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using UpstackTest.Models;

namespace UpstackTest
{
    public partial class RegisterForm : System.Web.UI.Page
    {
        private DBManager db = new DBManager();
        private Encryptor encryptor = new Encryptor();
        private EMailSender emailSender = new EMailSender();

        private const string InvalidUsername = "Invalid username.";
        private const string InvalidEmail = "Invalid E-Mail.";
        private const string InvalidPassword = "Invalid Password.";
        private const string SuccesfulRegister = "Activation link sent to an email.";

        private static readonly Regex validUsername = new Regex("([a-zA-Z])+");

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Register_Click(object sender, EventArgs e)
        {
            if (!validUsername.IsMatch(Username.Text))
            {
                Info.Text = InvalidUsername;
                return;
            }

            if (new EmailAddressAttribute().IsValid(Email))
            {
                Info.Text = InvalidEmail;
                return;
            }

            if (Password.Text.Length < 8 || Password.Text.Contains(' '))
            {
                Info.Text = InvalidPassword;
                return;
            }

            var user = new User()
            {
                Email = Email.Text,
                Password = encryptor.Encrypt(Password.Text),
                Username = Username.Text
            };
            
            var registerResult = db.RegisterUser(user);

            if(registerResult != RegisterUserResult.Ok)
            {
                Info.Text = registerResult.ToString();
                return;
            }

            emailSender.SendActivationEMail(user.Email, user.Id);

            Info.Text = SuccesfulRegister;
        }
    }
}