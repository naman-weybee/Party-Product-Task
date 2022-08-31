using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace PartyTask
{
    public partial class PartyEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtPartyEdit.Text = Request.QueryString["name"];
            }
        }
        protected void btnUpdateParty_Click(object sender, EventArgs e)
        {
            if (txtPartyEdit.Text != "")
            {
                SqlConnection con = null;
                try
                {
                    int id = Convert.ToInt32(Request.QueryString["ID"]);
                    con = new SqlConnection("data source=DESKTOP-9J2CV47; database=PartyProduct; integrated security=SSPI");
                    SqlCommand cm = new SqlCommand("update Party set PartyName = '" + txtPartyEdit.Text + "' where ID = " + id, con);
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
                    txtPartyEdit.Text = "";
                }
            }
        }
    }
}