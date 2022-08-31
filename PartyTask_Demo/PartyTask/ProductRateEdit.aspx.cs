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
    public partial class ProductRateEdit : System.Web.UI.Page
    {
        public void ProductRateEditData()
        {
            if (!IsPostBack)
            {
                SqlConnection con = null;
                try
                {
                    int id = Convert.ToInt32(Request.QueryString["ID"]);
                    string name3 = Request.QueryString["name3"];
                    con = new SqlConnection("data source=DESKTOP-9J2CV47; database=PartyProduct; integrated security=SSPI");
                    SqlDataAdapter sdr = new SqlDataAdapter("select * from Products", con);
                    SqlCommand cm = new SqlCommand("select Productid from ProductRate where id=" + id, con);
                    con.Open();
                    DataTable dt = new DataTable();
                    sdr.Fill(dt);
                    var ids = cm.ExecuteScalar();
                    ddlProductNameEdit.DataSource = dt;
                    ddlProductNameEdit.DataTextField = "ProductName";
                    ddlProductNameEdit.DataValueField = "ID";
                    ddlProductNameEdit.DataBind();
                    ddlProductNameEdit.Items.Insert(0, new ListItem("Select Product", "-1"));
                    ddlProductNameEdit.SelectedValue = ids.ToString();
                    txtDateOfRateEdit.Text = name3;
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
            ProductRateEditData();
            if (!IsPostBack)
            {
                txtProductRateEdit.Text = Request.QueryString["name2"];
            }
        }

        protected void btnUpdateProductRateEdit_Click(object sender, EventArgs e)
        {
            if (txtProductRateEdit.Text != "" && txtDateOfRateEdit.Text != "")
            {
                SqlConnection con = null;
                try
                {
                    int id = Convert.ToInt32(Request.QueryString["ID"]);
                    con = new SqlConnection("data source=DESKTOP-9J2CV47; database=PartyProduct; integrated security=SSPI");
                    SqlCommand cm = new SqlCommand("update ProductRate set Productid =" + Convert.ToInt32(ddlProductNameEdit.SelectedValue) + "where id=" + id, con);
                    SqlCommand cm1 = new SqlCommand("update ProductRate set Rate =" + Convert.ToInt32(txtProductRateEdit.Text) + "where id=" + id, con);
                    SqlCommand cm2 = new SqlCommand("update ProductRate set DateOfRate ='" + Convert.ToDateTime(txtDateOfRateEdit.Text).ToString("yyyy-MM-dd") + "'where id=" + id, con);
                    con.Open();
                    cm.ExecuteNonQuery();
                    cm1.ExecuteNonQuery();
                    cm2.ExecuteNonQuery();
                    Response.Redirect("~/ProductRate.aspx");
                }
                catch (Exception ex)
                {
                    Response.Write("OOPs, something went wrong." + ex);
                }
                finally
                {
                    con.Close();
                    txtProductRateEdit.Text = "";
                }
            }
        }
    }
}