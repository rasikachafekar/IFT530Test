using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Configuration;
using System.Web;
using System.Web.UI;
using System.Data.SqlClient;
using WebSite1;
using System.Data;
using System.Web.SessionState;

public partial class Account_Login : Page
{
        protected void Page_Load(object sender, EventArgs e)
        {
            //RegisterHyperLink.NavigateUrl = "Register";
            ////OpenAuthLogin.ReturnUrl = Request.QueryString["ReturnUrl"];
            //var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            //if (!String.IsNullOrEmpty(returnUrl))
            //{
            //    RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            //}
        }

        protected void LogIn(object sender, EventArgs e)
        {
            if (IsValid)
            {
                // Validate the user password
                var manager = new UserManager();
                //ApplicationUser user = manager.Find(UserName.Text, Password.Text);
                string user = UserName.Text;
                string pass = Password.Text;
                if (user != null)
                {
                //IdentityHelper.SignIn(manager, user, RememberMe.Checked);
                //IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                
                string connStr = ConfigurationManager.ConnectionStrings["IFT530"].ToString();
                SqlConnection conn = new SqlConnection(connStr);
                //conn.ConnectionString =
                //"Data Source=LAPTOP-BP5IN1R5;" +
                //"Initial Catalog=IFT530;" +
                //"User id=IFT530;" +
                //"Password=IFT530;";
                {
                    using (SqlCommand cmd = new SqlCommand("dbo.sp_RetirevePassword", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@UserName", SqlDbType.VarChar).Value = UserName.Text;
                        cmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = Password.Text;
                        //cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value;
                        SqlParameter output = cmd.Parameters.Add("@Status", SqlDbType.Int);
                        output.Direction = ParameterDirection.Output;
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        int status = (int) output.Value;

                        if(status == 0)
                        {
                            SqlCommand cmd2 = new SqlCommand("dbo.sp_GetIndividualID", conn);
                            cmd2.CommandType = CommandType.StoredProcedure;
                            cmd2.Parameters.Add("@Username", SqlDbType.VarChar).Value = UserName.Text;
                            SqlParameter id = cmd2.Parameters.Add("@IndividualID", SqlDbType.Int);
                            id.Direction = ParameterDirection.Output;
                            cmd2.ExecuteNonQuery();
                            int ID = (int)id.Value;
                            Session["ID"] = ID;
                            conn.Close();
                            Response.Redirect("Home.aspx");
                            
                        }
                        else
                        {
                            FailureText.Text = "Invalid username or password.";
                            ErrorMessage.Visible = true;
                            conn.Close();
                        }

                    }
                }
            }
                else
                {
                    FailureText.Text = "Invalid username or password.";
                    ErrorMessage.Visible = true;
                }
            }
        }
}