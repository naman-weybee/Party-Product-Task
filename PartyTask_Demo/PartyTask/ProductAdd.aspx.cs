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
    public partial class ProductAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSaveProductAdd_Click(object sender, EventArgs e)
        {
            if (txtProductAdd.Text != "")
            {
                SqlConnection con = null;
                try
                {
                    con = new SqlConnection("data source=DESKTOP-9J2CV47; database=PartyProduct; integrated security=SSPI");
                    SqlCommand cm = new SqlCommand("insert into Products(ProductName)values('" + txtProductAdd.Text + "')", con);
                    con.Open();
                    cm.ExecuteNonQuery();
                    lblProductAdd.Text = "Data Inserted Successfully...!";
                }
                catch (Exception ex)
                {
                    Response.Write("OOPs, something went wrong." + ex);
                }
                finally
                {
                    con.Close();
                    txtProductAdd.Text = "";
                }
            }
        }
    }
}