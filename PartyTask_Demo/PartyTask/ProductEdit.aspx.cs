using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace PartyTask
{
    public partial class ProductEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtProductEdit.Text = Request.QueryString["name"];
            }
        }

        protected void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            if (txtProductEdit.Text != null)
            {
                SqlConnection con = null;
                try
                {
                    int id = Convert.ToInt32(Request.QueryString["ID"]);
                    con = new SqlConnection("data source=DESKTOP-9J2CV47; database=PartyProduct; integrated security=SSPI");
                    SqlCommand cm = new SqlCommand("update Products set ProductName='" + txtProductEdit.Text + "'where ID=" + id, con);
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
                    txtProductEdit.Text = null;
                }
            }
        }
    }
}