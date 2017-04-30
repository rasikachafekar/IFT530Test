using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for DAL
/// </summary>
public class DAL
{
    public DAL()
    {
    }

    public DataSet getResults(SqlCommand cmd, SqlConnection con)
    {
        //Comment
        DataSet ds = new DataSet();
        SqlDataAdapter da;
        using (cmd)
        {
            con.Open();
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            con.Close();
            return ds;
        }
    }


}