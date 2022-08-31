﻿using System;
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
            lblProductEditExist.Text = "";
            txtDateOfRateEdit.Enabled = false;
            if (!IsPostBack)
            {
                txtProductEdit.Text = Request.QueryString["name"];
                txtProductRateEdit.Text = Request.QueryString["name1"];
                txtDateOfRateEdit.Text = Convert.ToDateTime(DateTime.Now).ToString("dd-MM-yyyy");
            }
        }

        protected void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            Boolean flag1 = CheckProduct();
            if (flag1 == false)
            {
                if (txtProductEdit.Text != null)
                {
                    SqlConnection con = null;
                    try
                    {
                        int id = Convert.ToInt32(Request.QueryString["ID"]);
                        con = new SqlConnection("data source=DESKTOP-9J2CV47; database=PartyProduct; integrated security=SSPI");
                        SqlCommand cm = new SqlCommand("update Products set ProductName='" + txtProductEdit.Text.Trim() + "'where id=" + id, con);
                        SqlCommand cm1 = new SqlCommand("update ProductRate set Rate='" + Convert.ToInt32(txtProductRateEdit.Text.Trim()) + "'where Productid=" + id, con);
                        SqlCommand cm2 = new SqlCommand("update ProductRate set DateOfRate='" + Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd") + "'where Productid=" + id, con);
                        con.Open();
                        cm.ExecuteNonQuery();
                        cm1.ExecuteNonQuery();
                        cm2.ExecuteNonQuery();
                        Response.Redirect("~/Products/Products.aspx");
                    }
                    catch (Exception ex)
                    {
                        Response.Write("<script>alert(\"Product Can't be Edited Because it is already Present...!\")</script>");
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
                lblProductEditExist.Text = txtProductEdit.Text + " With Product Rate " + txtProductRateEdit.Text + " is already Exist...!";
            }
        }


        //protected void btnUpdateProduct_Click(object sender, EventArgs e)
        //{
        //    if (txtProductEdit.Text != null)
        //    {
        //        SqlConnection con = null;
        //        try
        //        {
        //            int id = Convert.ToInt32(Request.QueryString["ID"]);
        //            con = new SqlConnection("data source=DESKTOP-9J2CV47; database=PartyProduct; integrated security=SSPI");
        //            SqlCommand cm = new SqlCommand("update Products set ProductName='" + txtProductEdit.Text.Trim() + "'where ID=" + id, con);
        //            con.Open();
        //            cm.ExecuteNonQuery();
        //            Response.Redirect("~/Products/Products.aspx");
        //        }
        //        catch (Exception ex)
        //        {
        //            Response.Write("<script>alert(\"Product Can't be Edited Because it is already Present...!\")</script>");
        //            //Response.Write(ex.Message);
        //        }
        //        finally
        //        {
        //            con.Close();
        //        }
        //    }
        //}

        protected void btnCancelProduct_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Products/Products.aspx");
        }

        protected Boolean CheckProduct()
        {
            Boolean flag = false;
            SqlConnection con = new SqlConnection("data source=DESKTOP-9J2CV47; database=PartyProduct; integrated security=SSPI");
            SqlCommand cm = new SqlCommand("SELECT id FROM Products WHERE ProductName in ('" + txtProductEdit.Text.Trim() + "')", con);
            SqlCommand cm1 = new SqlCommand("SELECT Rate FROM ProductRate WHERE Rate in (" + Convert.ToInt32(txtProductRateEdit.Text.Trim()) + ")", con);
            con.Open();
            var x = cm.ExecuteScalar();
            int id = Convert.ToInt32(x);
            var a = cm1.ExecuteScalar();
            int id1 = Convert.ToInt32(a);
            SqlCommand cm3 = new SqlCommand("SELECT * FROM ProductRate", con);
            SqlDataReader sdr = cm3.ExecuteReader();
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    if (sdr.GetInt32(1) == id && sdr.GetInt32(2) == id1)
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