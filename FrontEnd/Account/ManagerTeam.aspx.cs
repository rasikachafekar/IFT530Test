using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
public partial class Account_ManagerTeam : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            if (Session["RoleID"].ToString().Equals(2.ToString()))
            {
                DataSet ds;
                DAL dal = new DAL();
                lblInfo.Text = "Team availablity details";

                //Setup Connection
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["IFT530"].ToString());

                SqlCommand cmd = new SqlCommand("[sp_RetrieveIndividualAvailability]", con);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IndividualId", SqlDbType.Int).Value = Session["ID"].ToString();
                cmd.Parameters.Add("@RoleID", SqlDbType.Int).Value = Session["RoleID"].ToString();

                ds = dal.getResults(cmd, con);

                grvAvailability.DataSource = ds.Tables[0];
                grvAvailability.DataBind();

                Master.FindControl("menu").Visible = true;

            }

            else
            {
                lblInfo.Text = "You are not authorized to view this page";
                grvAvailability.Visible = false;
            }
                
        }
    }
}