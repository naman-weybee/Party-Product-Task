using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace PartyTask
{
    public partial class Products : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string strcon = ConfigurationManager.ConnectionStrings["PartyProductConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(strcon);
            try
            {
                SqlDataAdapter sde = new SqlDataAdapter("Select * from Products order by id", con);
                DataSet ds = new DataSet();
                sde.Fill(ds);
                gdProducts.DataSource = ds;
                gdProducts.DataBind();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
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
                string strcon = ConfigurationManager.ConnectionStrings["PartyProductConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection(strcon);
                try
                {
                    SqlCommand cm = new SqlCommand("Select Rate from ProductRate where Productid=" + id, con);
                    con.Open();
                    var a = cm.ExecuteScalar();
                    int x = Convert.ToInt32(a);
                    Response.Redirect("~/Products/ProductAddEdit.aspx?ID=" + id + "&name=" + name + "&name1=" + x);
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        protected void btnDelete_Click(object sender, ImageClickEventArgs e)
        {
            int rowIndex = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
            int id = Convert.ToInt32(gdProducts.Rows[rowIndex].Cells[0].Text);
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                string strcon = ConfigurationManager.ConnectionStrings["PartyProductConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection(strcon);
                try
                {
                    SqlCommand cm1 = new SqlCommand("delete from ProductRate where Productid =" + id, con);
                    SqlCommand cm2 = new SqlCommand("delete from AssignParty where Productid =" + id, con);
                    SqlCommand cm = new SqlCommand("delete from Products where id =" + id, con);
                    con.Open();
                    cm1.ExecuteNonQuery();
                    cm2.ExecuteNonQuery();
                    cm.ExecuteNonQuery();
                    Response.Redirect("~/Products/Products.aspx");
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert(\"Product Can't be Deleted Because it Contains FK References...!\")</script>");
                    //Response.Write(ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
        }
    }
}