using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace PartyTask
{
    public partial class ProductRate : System.Web.UI.Page
    {
        public void ProductRateData()
        {
            if (!IsPostBack)
            {
                SqlConnection con = null;
                try
                {
                    con = new SqlConnection("data source=DESKTOP-9J2CV47; database=PartyProduct; integrated security=SSPI");
                    SqlDataAdapter sde = new SqlDataAdapter("select ProductRate.id, Products.id , ProductRate.Productid, Products.ProductName, Rate, DateOfRate from ProductRate inner join Products on Products.id = ProductRate.Productid; ", con);
                    con.Open();
                    DataSet ds = new DataSet();
                    sde.Fill(ds);
                    gdProductRate.DataSource = ds;
                    gdProductRate.DataBind();
                }
                catch (Exception ex)
                {
                    Response.Write("OOPs, something went wrong." + ex);
                }
                finally
                {
                    con.Close();
                }
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            ProductRateData();
        }

        protected void gdProductRate_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "cmdProductRateEdit")
            {
                GridViewRow gd = gdProductRate.Rows[Convert.ToInt32(e.CommandArgument)];
                int id = Convert.ToInt32(gd.Cells[0].Text);
                string name1 = gd.Cells[1].Text;
                string name2 = gd.Cells[2].Text;
                string name3 = gd.Cells[3].Text;
                Response.Redirect("~/ProductRateEdit.aspx?ID=" + id + "&name1=" + name1 + "&name2=" + name2 + "&name3=" + name3);
            }
            else if (e.CommandName == "cmdProductRateDelete")
            {
                GridViewRow gd = gdProductRate.Rows[Convert.ToInt32(e.CommandArgument)];
                int id = Convert.ToInt32(gd.Cells[0].Text);
                SqlConnection con = null;
                try
                {
                    con = new SqlConnection("data source=DESKTOP-9J2CV47; database=PartyProduct; integrated security=SSPI");
                    SqlCommand cm = new SqlCommand("delete from ProductRate where id=" + id, con);
                    con.Open();
                    cm.ExecuteNonQuery();
                    Response.Redirect("~/ProductRate.aspx");
                }
                catch (Exception ex)
                {
                    Response.Write("OOPs, something went wrong." + ex);
                }
                finally
                {
                    con.Close();
                }
            }

        }
    }
}