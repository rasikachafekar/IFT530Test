using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Account_Schedules : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string sessionid = Session["RoleID"].ToString();
        if (!(sessionid.Equals(2.ToString())))
        {
            lbl_player.Text = "You are not authorised to view this page !";
            Container.Visible = false;
        }
        else
        {
            lbl_player.Text = "Available Players";
        }
    }

    protected void cal_calChooseDate_SelectionChanged(object sender, EventArgs e)
    {
        txt_ChooseDate.Text = cal_calChooseDate.SelectedDate.ToString();
    }

    protected void btn_FindPlayers_Click(object sender, EventArgs e)
    {
        grv_displayPlayers.Visible = true;
        DataSet results = new DataSet();
        DAL Players = new DAL();
        DataTable dt = new DataTable();
        string connStr = ConfigurationManager.ConnectionStrings["PolySoccerTeam"].ToString();
        SqlConnection conn = new SqlConnection(connStr);

        using (SqlCommand cmd = new SqlCommand("select * from suggestPlayers('" + txt_ChooseDate.Text + "')", conn))
        {
           
            cmd.CommandType = CommandType.Text;
            
            results =Players.getResults(cmd, conn);
            dt = results.Tables[0];
        }

        grv_displayPlayers.DataSource = dt;
        grv_displayPlayers.DataBind();

        }
}