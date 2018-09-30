using System;

namespace UpstackTest
{
    public partial class LoginForm : System.Web.UI.Page
    {
        private DBManager db = new DBManager();
        private Encryptor encryptor = new Encryptor();

        private const string FailedLogin = "Login failed, no such user.";
        private const string InactiveUser = "User not activated, check e-mail for activation link.";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login_Click(object sender, EventArgs e)
        {
            var user = db.GetUser(Username.Text);

            if (user == null || !encryptor.IsMatch(Password.Text, user.Password))
            {
                Info.Text = FailedLogin;
                return;
            }

            if (user.Active == false)
            {
                Info.Text = InactiveUser;
                return;
            }

            Response.Redirect("Content.aspx");
        }

        protected void Register_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }
    }
}