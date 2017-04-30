using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Home : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //Setup connection 
            SqlDataAdapter da;
            DataTable dtStats = new DataTable();
            DataTable dtRoles = new DataTable();
            DataSet dsResults = new DataSet();
            string id = Session["ID"].ToString();
            string roleText = "";

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["IFT530"].ToString());
            SqlCommand cmd = new SqlCommand("sp_PlayerProfile", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IndividualID", SqlDbType.Int).Value = id;
            SqlParameter playerName = cmd.Parameters.Add("@Name", SqlDbType.VarChar, 50);
            playerName.Direction = ParameterDirection.Output;


            using (con)
            {
                con.Open();
                da = new SqlDataAdapter(cmd);
                da.TableMappings.Add("Stats", "Roles");
                da.Fill(dsResults);
            }

            dtRoles = dsResults.Tables[1];
            foreach (DataRow row in dtRoles.Rows)
            {
                roleText += row["Title"].ToString() + "\n";
                Session["RoleID"] = row["RoleID"];
            }
            lblRoleDetails.Text = roleText;


            dtStats = dsResults.Tables[0];
            grvProfileDisplay.DataSource = dtStats;
            grvProfileDisplay.DataBind();
            lblProfileName.Text = (string)playerName.Value;

            Master.FindControl("menu").Visible = true;

            if(!Session["RoleID"].ToString().Equals(2.ToString()))
            {
                Master.FindControl("hlManagerTeam").Visible = false;
            }


        }

    }
}