using KpopZtationFrontEnd.Controller;
using KpopZtationFrontEnd.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KpopZtationFrontEnd.View
{
    public partial class Login : System.Web.UI.Page
    {
        private AuthenticationController authenticationController = AuthenticationController.GetInstance();
        protected void Page_Load(object sender, EventArgs e)
        {
            authenticationController.RedirectUnauthenticatedPage(this);
        }

        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
            string username = TextBoxUsername.Text;
            string password = TextBoxPassword.Text;
            bool remember = CheckBoxRememberMe.Checked;

            try
            {
                authenticationController.Login(this, username, password, remember);
            }
            catch (Exception ex)
            {
                LabelResult.Text = ex.Message;
                return;
            }

        }
    }
}