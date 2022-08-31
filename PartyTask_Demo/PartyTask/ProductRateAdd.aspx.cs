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
    public partial class ProductRateAdd : System.Web.UI.Page
    {
        public void AddProductRate()
        {
            if (!IsPostBack)
            {
                SqlConnection con = null;
                try
                {
                    con = new SqlConnection("data source=DESKTOP-9J2CV47; database=PartyProduct; integrated security=SSPI");
                    SqlDataAdapter sdr = new SqlDataAdapter("select * from Products", con);
                    con.Open();
                    DataTable dt = new DataTable();
                    sdr.Fill(dt);
                    ddlProductNameAdd.DataSource = dt;
                    ddlProductNameAdd.DataTextField = "ProductName";
                    ddlProductNameAdd.DataValueField = "ID";
                    ddlProductNameAdd.DataBind();
                    ddlProductNameAdd.Items.Insert(0, new ListItem("Select Product", "-1"));
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
            AddProductRate();
            lblProductRateAddSuccess.Text = "";
        }
        protected void btnSaveProductRateAdd_Click(object sender, EventArgs e)
        {
            if (ddlProductNameAdd.SelectedValue != "-1" && txtProductRateAdd.Text != "" && txtDateOfRateAdd.Text != "")
            {
                SqlConnection con = null;
                try
                {
                    con = new SqlConnection("data source=DESKTOP-9J2CV47; database=PartyProduct; integrated security=SSPI");
                    SqlCommand cm = new SqlCommand("insert into ProductRate(Productid, Rate, DateOfRate)values(" + Convert.ToInt32(ddlProductNameAdd.SelectedValue) + "," + Convert.ToInt32(txtProductRateAdd.Text) + ",'" + Convert.ToDateTime(txtDateOfRateAdd.Text).ToString("yyyy-MM-dd") + "')", con);
                    con.Open();
                    cm.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Response.Write("OOPs, something went wrong." + ex);
                }
                finally
                {
                    con.Close();
                    ddlProductNameAdd.SelectedValue = "-1";
                    txtProductRateAdd.Text = "";
                    txtDateOfRateAdd.Text = "";
                    lblProductRateAddSuccess.Text = "Data Inserted Successfully...!";
                }
            }
        }
    }
}