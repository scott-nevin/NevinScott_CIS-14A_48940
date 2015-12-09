using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class public_basket : System.Web.UI.Page
{
    DataTable Basket_DataTable = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["basket"] != null)
            ///read Basket_DataTable from session if exist
            Basket_DataTable = (DataTable)Session["basket"];
        else
        {
            //create an empty DataTable and Add some columns to it
            Basket_DataTable = new DataTable();
            Basket_DataTable.Columns.Add("id");
            Basket_DataTable.Columns.Add("name");
            Basket_DataTable.Columns.Add("price");
            Basket_DataTable.Columns.Add("pic");
            Basket_DataTable.Columns.Add("count");
            Basket_DataTable.Columns.Add("total");
        }
        /////////////////////////

        if (Request["DelID"] != null)
        {
            for (int i = 0; i < Basket_DataTable.Rows.Count; i++)
                if (Basket_DataTable.Rows[i][0].ToString() == Request["DelID"].ToString())
                    Basket_DataTable.Rows.Remove(Basket_DataTable.Rows[i]);

        }
        if (Request["ID"] != null)
        {
            //search item in DataTable
            bool Found = false;
            for (int i = 0; i < Basket_DataTable.Rows.Count; i++)
                if (Basket_DataTable.Rows[i][0].ToString() == Request["ID"].ToString())
                    Found = true;

            //add to basket
            if (Found == false)
            {
                DataAcess data = new DataAcess();
                string sql = "SELECT * FROM Items where id=" + Request["ID"];
                DataTable ret= data.exe_select(sql);
                if (ret != null && ret.Rows.Count == 1)
                {
                    Basket_DataTable.Rows.Add(new object[] { Request["ID"],ret.Rows[0]["name"].ToString()
                                              ,ret.Rows[0]["price"].ToString(),ret.Rows[0]["pic"].ToString()
                                             ,"1",ret.Rows[0]["price"].ToString()});
                }
            }
        }
        /////////////////////////
        if (IsPostBack == false)
        {
            GridView2.DataSource = Basket_DataTable;
            GridView2.DataBind();
        }

        Session["basket"] = Basket_DataTable;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            for (int i = 0; i < GridView2.Rows.Count; i++)
            {
                TextBox Tb = (TextBox)GridView2.Rows[i].FindControl("TextBoxCount");
                Basket_DataTable.Rows[i]["count"] = Tb.Text;
                Basket_DataTable.Rows[i]["total"] = Convert.ToInt32(Tb.Text) * Convert.ToInt32(Basket_DataTable.Rows[i]["price"]);
            }
        }
        catch
        {
        }
        Response.Redirect("basket.aspx");
    }
    protected void save_Click(object sender, EventArgs e)
    {
        DataAcess data = new DataAcess();
        for (int i = 0; i < GridView2.Rows.Count; i++)
        {
            String ID = GridView2.Rows[i].Cells[0].Text.ToString(); ;
            TextBox Tb = (TextBox)GridView2.Rows[i].FindControl("TextBoxCount");
            string sql = "INSERT INTO Basket (count, id)VALUES ({0}, {1})";
            sql = string.Format(sql, Tb.Text, ID);
            data.exe_cmd(sql);
        }
    }
}
