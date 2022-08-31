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
    public partial class Products : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection("data source=DESKTOP-9J2CV47; database=PartyProduct; integrated security=SSPI");
                SqlDataAdapter sde = new SqlDataAdapter("Select * from Products", con);
                DataSet ds = new DataSet();
                sde.Fill(ds);
                gdProducts.DataSource = ds;
                gdProducts.DataBind();
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

        protected void gdProducts_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "cmdProductEdit")
            {
                GridViewRow gd = gdProducts.Rows[Convert.ToInt32(e.CommandArgument)];
                int id = Convert.ToInt32(gd.Cells[0].Text);
                string name = gd.Cells[1].Text;
                Response.Redirect("~/ProductEdit.aspx?ID=" + id + "&name=" + name);
            }
            else if (e.CommandName == "cmdProductDelete")
            {
                GridViewRow gd = gdProducts.Rows[Convert.ToInt32(e.CommandArgument)];
                int id = Convert.ToInt32(gd.Cells[0].Text);
                SqlConnection con = null;
                try
                {
                    con = new SqlConnection("data source=DESKTOP-9J2CV47; database=PartyProduct; integrated security=SSPI");
                    SqlCommand cm = new SqlCommand("delete from Products where id =" + id, con);
                    con.Open();
                    cm.ExecuteNonQuery();
                    Response.Redirect("~/Products.aspx");
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