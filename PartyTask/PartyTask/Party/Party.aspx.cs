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
    public partial class Party : System.Web.UI.Page
    {
        public void UpdateData()
        {
            string strcon = ConfigurationManager.ConnectionStrings["PartyProductConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(strcon);
            try
            {
                SqlDataAdapter sdr = new SqlDataAdapter("Select * from Party order by id", con);
                DataSet ds = new DataSet();
                sdr.Fill(ds);
                gdParty.DataSource = ds;
                gdParty.DataBind();
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
        protected void Page_Load(object sender, EventArgs e)
        {
            UpdateData();
        }

        protected void gdParty_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "cmdPartyEdit")
            {
                GridViewRow gd = gdParty.Rows[Convert.ToInt32(e.CommandArgument)];
                int id = Convert.ToInt32(gd.Cells[0].Text);
                string name = gd.Cells[1].Text;
                Response.Redirect("~/Party/PartyAddEdit.aspx?ID=" + id + "&name=" + name);
            }
        }

        protected void btnDelete_Click(object sender, ImageClickEventArgs e)
        {
            int rowIndex = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
            int id = Convert.ToInt32(gdParty.Rows[rowIndex].Cells[0].Text);
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                string strcon = ConfigurationManager.ConnectionStrings["PartyProductConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection(strcon);
                try
                {
                    con.Open();
                    SqlCommand cm = new SqlCommand("delete from Party where id =" + id, con);
                    cm.ExecuteNonQuery();
                    UpdateData();
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert(\"Party Can't be Deleted Because it Contains FK References...!\")</script>");
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