using Microsoft.AspNet.Identity;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSite1;

public partial class Account_Register : Page
{
    protected void CreateUser_Click(object sender, EventArgs e)
    {
        DAL dal = new DAL();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        string connStr = ConfigurationManager.ConnectionStrings["IFT530"].ToString();
        SqlConnection con = new SqlConnection(connStr);
        int status;
        using (SqlCommand cmd = new SqlCommand("sp_Individual_Insert", con))
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = txtFirstName.Text;
            cmd.Parameters.Add("@LastName", SqlDbType.VarChar).Value = txtLastName.Text;
            cmd.Parameters.Add("@DateOfBirth", SqlDbType.Date).Value = txtDoB.Text;
            cmd.Parameters.Add("@Major", SqlDbType.VarChar).Value = txtMajor.Text;
            cmd.Parameters.Add("@TeamID", SqlDbType.Int).Value = ddlTeams.SelectedValue;
            cmd.Parameters.Add("@RoleName", SqlDbType.VarChar).Value = ddlRole.SelectedValue;
            SqlParameter retVal = cmd.Parameters.Add("@Status", SqlDbType.Int);
            retVal.Direction = ParameterDirection.ReturnValue;
            con.Open();
            cmd.ExecuteNonQuery();
            status = (int) retVal.Value;
            con.Close();
        }

        if(status == 0)
        {
            txtInsertStatus.Visible = true;
            txtInsertStatus.Text = "Individual added successfully";
        }
        else
        {
            txtInsertStatus.Visible = true;
            txtInsertStatus.Text = "Something went wrong. Try again!!";
        }
    }

    protected void calDoB_SelectionChanged(object sender, EventArgs e)
    {
        txtDoB.Text = calDoB.SelectedDate.ToShortDateString();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        DAL dal = new DAL();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        string connStr = ConfigurationManager.ConnectionStrings["IFT530"].ToString();
        SqlConnection con = new SqlConnection(connStr);

        using (SqlCommand cmd = new SqlCommand("sp_RoleTeamList", con))
        {
            cmd.CommandType = CommandType.StoredProcedure;

            ds = dal.getResults(cmd, con);
            dt = ds.Tables[0];
            ddlTeams.DataSource = dt;
            ddlTeams.DataTextField = "Name";
            ddlTeams.DataValueField = "TeamID";
            ddlTeams.DataBind();
            //ddlTeams.Items.Insert(0, new ListItem("<Select Team>", "-1"));

            dt = ds.Tables[1];
            ddlRole.DataSource = dt;
            ddlRole.DataTextField = "Title";
            ddlRole.DataValueField = "RoleID";
            ddlRole.DataBind();
        }
    }

}