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
    public partial class Party : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection("data source=DESKTOP-9J2CV47; database=PartyProduct; integrated security=SSPI");
                SqlDataAdapter sde = new SqlDataAdapter("Select * from Party", con);
                DataSet ds = new DataSet();
                sde.Fill(ds);
                gdParty.DataSource = ds;
                gdParty.DataBind();
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

        protected void gdParty_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "cmdPartyEdit")
            {
                GridViewRow gd = gdParty.Rows[Convert.ToInt32(e.CommandArgument)];
                int id = Convert.ToInt32(gd.Cells[0].Text);
                string name = gd.Cells[1].Text;
                Response.Redirect("~/PartyEdit.aspx?ID=" + id + "&name=" + name);
            }
            else if (e.CommandName == "cmdPartyDelete")
            {
                GridViewRow gd = gdParty.Rows[Convert.ToInt32(e.CommandArgument)];
                int id = Convert.ToInt32(gd.Cells[0].Text);
                SqlConnection con = null;
                try
                {
                    con = new SqlConnection("data source=DESKTOP-9J2CV47; database=PartyProduct; integrated security=SSPI");
                    SqlCommand cm = new SqlCommand("delete from Party where id =" + id, con);
                    con.Open();
                    cm.ExecuteNonQuery();
                    Response.Redirect("~/Party.aspx");
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