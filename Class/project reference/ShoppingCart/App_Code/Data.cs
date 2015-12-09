using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Data
/// </summary>
public class DataAcess
{
    SqlConnection con = new SqlConnection();
    string con_string = @"Data Source=.\SQLEXPRESS;AttachDbFilename='|DataDirectory|\Database.mdf';Integrated Security=True;User Instance=True";
    SqlCommand cmd = new SqlCommand();
    

	public DataAcess()
	{
        con.ConnectionString = con_string;
        cmd.Connection = con;
        

	}

    public bool exe_cmd(string query,SqlParameter [] param)
    {
        try
        {
            con.Open();
            cmd.CommandText = query;
            cmd.Parameters.AddRange(param);
            cmd.ExecuteNonQuery();
            con.Close();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool exe_cmd(string query)
    {
        try
        {
            con.Open();
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
            con.Close();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public DataTable exe_select(string query)
    {
        try
        {
            cmd.CommandText = query;
            SqlDataAdapter adap = new SqlDataAdapter(cmd);
            DataTable t = new DataTable();
            adap.Fill(t);
            return t;
        }
        catch 
        {
            return null;
        }
    }
}
