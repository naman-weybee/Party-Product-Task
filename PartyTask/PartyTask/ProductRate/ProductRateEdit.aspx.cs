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
    public partial class ProductRateEdit : System.Web.UI.Page
    {
        public void ProductRateEditData()
        {
            if (!IsPostBack)
            {
                string strcon = ConfigurationManager.ConnectionStrings["PartyProductConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection(strcon);
                try
                {
                    int id = Convert.ToInt32(Request.QueryString["ID"]);
                    string name3 = Request.QueryString["name3"];
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
                    Response.Write(ex.Message);
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
            lblProductRateEditExist.Text = "";
            if (!IsPostBack)
            {
                txtProductRateEdit.Text = Request.QueryString["name2"];
            }
        }

        protected void btnUpdateProductRateEdit_Click(object sender, EventArgs e)
        {
            Boolean flag1 = CheckProduct();
            if (flag1 == false)
            {
                if (txtProductRateEdit.Text.Trim() != "" && txtDateOfRateEdit.Text.Trim() != "")
                {
                    string strcon = ConfigurationManager.ConnectionStrings["PartyProductConnectionString"].ConnectionString;
                    SqlConnection con = new SqlConnection(strcon);
                    try
                    {
                        int id = Convert.ToInt32(Request.QueryString["ID"]);
                        SqlCommand cm = new SqlCommand("update ProductRate set Productid =" + Convert.ToInt32(ddlProductNameEdit.SelectedValue) + "where id=" + id, con);
                        SqlCommand cm1 = new SqlCommand("update ProductRate set Rate =" + Convert.ToInt32(txtProductRateEdit.Text.Trim()) + "where id=" + id, con);
                        SqlCommand cm2 = new SqlCommand("update ProductRate set DateOfRate ='" + Convert.ToDateTime(txtDateOfRateEdit.Text.Trim()).ToString("yyyy-MM-dd") + "'where id=" + id, con);
                        con.Open();
                        cm.ExecuteNonQuery();
                        cm1.ExecuteNonQuery();
                        cm2.ExecuteNonQuery();
                        Response.Redirect("~/ProductRate/ProductRate.aspx");
                    }
                    catch (Exception ex)
                    {
                        lblProductRateEditExist.Text = ddlProductNameEdit.SelectedItem + " is already Exist";
                    }
                    finally
                    {
                        con.Close();
                        txtProductRateEdit.Text = "";
                    }
                }
            }
            else
            {
                lblProductRateEditExist.Text = ddlProductNameEdit.SelectedItem + " is already Exist";
            }
        }

        protected void btnCancelProductRateEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ProductRate/ProductRate.aspx");
        }

        protected Boolean CheckProduct()
        {
            Boolean flag = false;
            string strcon = ConfigurationManager.ConnectionStrings["PartyProductConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(strcon);
            int id1 = Convert.ToInt32(ddlProductNameEdit.SelectedValue);
            SqlCommand cm = new SqlCommand("select * from ProductRate", con);
            con.Open();
            SqlDataReader sdr = cm.ExecuteReader();
            sdr.Read();
            if (sdr.HasRows)
            {
                if (sdr.GetInt32(1) == id1)
                {
                    flag = true;
                }
            }
            return flag;
        }
    }
}