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
    public partial class ProductAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["ID"] != null)
                {
                    txtProductAdd.Text = Request.QueryString["name"];
                    txtProductRateAdd.Text = Request.QueryString["name1"];
                }
            }
            txtDateOfRateAdd.Text = Convert.ToDateTime(DateTime.Now).ToString("dd-MM-yyyy");
            txtDateOfRateAdd.Enabled = false;
        }

        protected void btnSaveProductAdd_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["ID"] == null)
            {
                Boolean flag1 = CheckProduct();
                if (flag1 == false)
                {
                    if (txtProductAdd.Text != "")
                    {
                        string strcon = ConfigurationManager.ConnectionStrings["PartyProductConnectionString"].ConnectionString;
                        SqlConnection con = new SqlConnection(strcon);
                        try
                        {
                            SqlCommand cm = new SqlCommand("SP_Product_Insert", con);
                            SqlCommand cm2 = new SqlCommand("select top 1 id from Products order by id DESC", con);
                            SqlCommand cm1 = new SqlCommand("SP_ProductRate_Insert", con);
                            con.Open();
                            cm.CommandType = CommandType.StoredProcedure;
                            cm.Parameters.AddWithValue("@ProductName", txtProductAdd.Text.Trim());
                            cm.ExecuteNonQuery();
                            int x = Convert.ToInt32(cm2.ExecuteScalar());
                            cm1.CommandType = CommandType.StoredProcedure;
                            cm1.Parameters.AddWithValue("@Productid", x);
                            cm1.Parameters.AddWithValue("@Rate", Convert.ToInt32(txtProductRateAdd.Text.Trim()));
                            cm1.Parameters.AddWithValue("@DateOfRate", Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd"));
                            cm1.ExecuteNonQuery();
                            lblProductAdd.Text = "Data Inserted Successfully...!";
                            lblProductAddExist.Text = "";
                        }
                        catch (Exception ex)
                        {
                            lblProductAddExist.Text = txtProductAdd.Text + " is already Exist...!";
                            //Response.Write(ex.Message);
                        }
                        finally
                        {
                            con.Close();
                            txtProductAdd.Text = "";
                            txtProductRateAdd.Text = "";
                        }
                    }
                }
                else
                {
                    lblProductAdd.Text = "";
                    lblProductAddExist.Text = txtProductAdd.Text + " is already Exist...!";
                }
            }
            else
            {
                Boolean flag1 = CheckProductRate();
                if (flag1 == false)
                {
                    if (txtProductAdd.Text != null)
                    {
                        string strcon = ConfigurationManager.ConnectionStrings["PartyProductConnectionString"].ConnectionString;
                        SqlConnection con = new SqlConnection(strcon);
                        try
                        {
                            int id = Convert.ToInt32(Request.QueryString["ID"]);
                            SqlCommand cm = new SqlCommand("SP_Product_Edit", con);
                            SqlCommand cm1 = new SqlCommand("SP_ProductRate_Edit", con);
                            con.Open();
                            cm.CommandType = CommandType.StoredProcedure;
                            cm.Parameters.AddWithValue("@id", Convert.ToInt32(Request.QueryString["ID"]));
                            cm.Parameters.AddWithValue("@ProductName", txtProductAdd.Text.Trim());
                            cm.ExecuteNonQuery();
                            cm1.CommandType = CommandType.StoredProcedure;
                            cm1.Parameters.AddWithValue("@Productid", Convert.ToInt32(Request.QueryString["ID"]));
                            cm1.Parameters.AddWithValue("@Rate", Convert.ToInt32(txtProductRateAdd.Text.Trim()));
                            cm1.Parameters.AddWithValue("@DateOfRate", Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd"));
                            cm1.ExecuteNonQuery();
                            Response.Redirect("~/Products/Products.aspx");
                        }
                        catch (Exception ex)
                        {
                            lblProductAddExist.Text = txtProductAdd.Text + " is already Exist...!";
                            //Response.Write(ex.Message);
                        }
                        finally
                        {
                            con.Close();
                        }
                    }
                }
                else
                {
                    lblProductAddExist.Text = txtProductAdd.Text + " is already Exist...!";
                }
            }
        }

        protected void btnCancelProductAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Products/Products.aspx");
        }

        protected Boolean CheckProduct()
        {
            Boolean flag = false;
            string strcon = ConfigurationManager.ConnectionStrings["PartyProductConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(strcon);
            SqlCommand cm = new SqlCommand("SELECT id FROM Products WHERE ProductName in ('" + txtProductAdd.Text.Trim() + "')", con);
            con.Open();
            int id = Convert.ToInt32(cm.ExecuteScalar());
            SqlCommand cm3 = new SqlCommand("SELECT * FROM ProductRate", con);
            SqlDataReader sdr = cm3.ExecuteReader();
            sdr.Read();
            if (sdr.HasRows)
            {
                if (sdr.GetInt32(1) == id)
                {
                    flag = true;
                }
            }
            return flag;
        }

        protected Boolean CheckProductRate()
        {
            Boolean flag = false;
            string strcon = ConfigurationManager.ConnectionStrings["PartyProductConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(strcon);
            SqlCommand cm = new SqlCommand("SELECT id FROM Products WHERE ProductName in ('" + txtProductAdd.Text.Trim() + "')", con);
            con.Open();
            int id = Convert.ToInt32(cm.ExecuteScalar());
            SqlCommand cm3 = new SqlCommand("SELECT id FROM ProductRate where Productid in (" + id + ")" + "and Rate in(" + Convert.ToInt32(txtProductRateAdd.Text.Trim()) + ")", con);
            int id2 = Convert.ToInt32(cm3.ExecuteScalar());
            SqlDataReader sdr = cm3.ExecuteReader();
            sdr.Read();
            if (sdr.HasRows)
            {
                if (sdr.GetInt32(0) == id2)
                {
                    flag = true;
                }
            }
            return flag;
        }
    }
}