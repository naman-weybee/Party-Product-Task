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
            txtDateOfRateAdd.Text = Convert.ToDateTime(DateTime.Now).ToString("dd-MM-yyyy");
            txtDateOfRateAdd.Enabled = false;
        }

        protected void btnSaveProductAdd_Click(object sender, EventArgs e)
        {
            Boolean flag1 = CheckProduct();
            if (flag1 == false)
            {
                if (txtProductAdd.Text != "")
                {
                    SqlConnection con = null;
                    try
                    {
                        con = new SqlConnection("data source=DESKTOP-9J2CV47; database=PartyProduct; integrated security=SSPI");
                        SqlCommand cm = new SqlCommand("insert into Products(ProductName)values('" + txtProductAdd.Text.Trim() + "')", con);
                        SqlCommand cm2 = new SqlCommand("select top 1 id from Products order by id DESC", con);
                        con.Open();
                        cm.ExecuteNonQuery();
                        var x = cm2.ExecuteScalar();
                        int y = Convert.ToInt32(x);
                        SqlCommand cm1 = new SqlCommand("insert into ProductRate(Productid, Rate, DateOfRate)values(" + y + "," + Convert.ToInt32(txtProductRateAdd.Text.Trim()) + ",'" + Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd") + "')", con);
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


        //protected void btnSaveProductAdd_Click(object sender, EventArgs e)
        //{
        //    if (txtProductAdd.Text != "")
        //    {
        //        SqlConnection con = null;
        //        try
        //        {
        //            con = new SqlConnection("data source=DESKTOP-9J2CV47; database=PartyProduct; integrated security=SSPI");
        //            SqlCommand cm = new SqlCommand("insert into Products(ProductName)values('" + txtProductAdd.Text.Trim() + "')", con);
        //            SqlCommand cm2 = new SqlCommand("select top 1 id from Products order by id DESC", con);
        //            con.Open();
        //            cm.ExecuteNonQuery();
        //            var x = cm2.ExecuteScalar();
        //            int y = Convert.ToInt32(x);
        //            SqlCommand cm1 = new SqlCommand("insert into ProductRate(Productid, Rate, DateOfRate)values(" + y + "," + Convert.ToInt32(txtProductRateAdd.Text.Trim()) + ",'" + Convert.ToDateTime(txtDateOfRateAdd.Text.Trim()).ToString("yyyy-MM-dd") + "')", con);
        //            cm1.ExecuteNonQuery();
        //            lblProductAdd.Text = "Data Inserted Successfully...!";
        //            lblProductAddExist.Text = "";
        //        }
        //        catch (Exception ex)
        //        {
        //            Response.Write("<script>alert(\"Product Can't be Added Because it is already Present...!\")</script>");
        //            //Response.Write(ex.Message);
        //        }
        //        finally
        //        {
        //            con.Close();
        //        }
        //    }
        //}

        protected void btnCancelProductAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Products/Products.aspx");
        }

        protected Boolean CheckProduct()
        {
            Boolean flag = false;
            SqlConnection con = new SqlConnection("data source=DESKTOP-9J2CV47; database=PartyProduct; integrated security=SSPI");
            SqlCommand cm = new SqlCommand("SELECT id FROM Products WHERE ProductName in ('" + txtProductAdd.Text.Trim() + "')", con);
            con.Open();
            var x = cm.ExecuteScalar();
            int id = Convert.ToInt32(x);
            SqlCommand cm3 = new SqlCommand("SELECT * FROM ProductRate", con);
            SqlDataReader sdr = cm3.ExecuteReader();
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    if (sdr.GetInt32(1) == id)
                    {
                        flag = true;
                        break;
                    }
                }
            }
            return flag;
        }
    }
}