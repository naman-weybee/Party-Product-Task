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
    public partial class AssignParty : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection("data source=DESKTOP-9J2CV47; database=PartyProduct; integrated security=SSPI");
                SqlDataAdapter sdr = new SqlDataAdapter("select AssignParty.id, Party.id, Party.PartyName, Products.id, Products.ProductName from AssignParty inner join Party on Party.id = AssignParty.Partyid inner join Products on Products.id = AssignParty.Productid order by AssignParty.id", con);
                DataSet ds = new DataSet();
                sdr.Fill(ds);
                gdAssignParty.DataSource = ds;
                gdAssignParty.DataBind();
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

        protected void gdAssignParty_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "cmdAssignPartyEdit")
            {
                GridViewRow gd = gdAssignParty.Rows[Convert.ToInt32(e.CommandArgument)];
                int id = Convert.ToInt32(gd.Cells[0].Text);
                string name1 = gd.Cells[1].Text;
                string name2 = gd.Cells[2].Text;
                Response.Redirect("~/AssignParty/AssignPartyEdit.aspx?ID=" + id + "&name1=" + name1 + "&name2=" + name2);
            }
        }
        protected void btnDelete_Click(object sender, ImageClickEventArgs e)
        {
            int rowIndex = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
            int id = Convert.ToInt32(gdAssignParty.Rows[rowIndex].Cells[0].Text);
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                SqlConnection con = null;
                try
                {
                    con = new SqlConnection("data source=DESKTOP-9J2CV47; database=PartyProduct; integrated security=SSPI");
                    SqlCommand cm = new SqlCommand("delete from AssignParty where id =" + id, con);
                    con.Open();
                    cm.ExecuteNonQuery();
                    Response.Redirect("~/AssignParty/AssignParty.aspx");
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
    }
}