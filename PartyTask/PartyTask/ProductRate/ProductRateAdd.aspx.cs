﻿using System;
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
            AddProductRate();
            lblProductRateAddSuccess.Text = "";
        }
        protected void btnSaveProductRateAdd_Click(object sender, EventArgs e)
        {
            Boolean flag1 = CheckProduct();
            if (ddlProductNameAdd.SelectedValue != "-1" && txtProductRateAdd.Text.Trim() != "" && txtDateOfRateAdd.Text.Trim() != "")
            {
                SqlConnection con = null;
                try
                {
                    con = new SqlConnection("data source=DESKTOP-9J2CV47; database=PartyProduct; integrated security=SSPI");
                    if (flag1 == false)
                    {
                        SqlCommand cm = new SqlCommand("insert into ProductRate(Productid, Rate, DateOfRate)values(" + Convert.ToInt32(ddlProductNameAdd.SelectedValue) + "," + Convert.ToInt32(txtProductRateAdd.Text.Trim()) + ",'" + Convert.ToDateTime(txtDateOfRateAdd.Text.Trim()).ToString("yyyy-MM-dd") + "')", con);
                        con.Open();
                        cm.ExecuteNonQuery();
                        lblProductRateAddSuccess.Text = "Data Inserted Successfully...!";
                        lblProductRateExist.Text = "";
                    }
                    else
                    {
                        lblProductRateExist.Text = ddlProductNameAdd.SelectedItem.Text + " is already Exist...!";
                        lblProductRateAddSuccess.Text = "";
                    }
                }
                catch (Exception ex)
                {
                    lblProductRateExist.Text = ddlProductNameAdd.SelectedItem.Text + " is already Exist...!";
                    lblProductRateAddSuccess.Text = "";
                }
                finally
                {
                    con.Close();
                }
            }
        }
        protected Boolean CheckProduct()
        {
            Boolean flag = false;
            SqlConnection con = new SqlConnection("data source=DESKTOP-9J2CV47; database=PartyProduct; integrated security=SSPI");
            int id1 = Convert.ToInt32(ddlProductNameAdd.SelectedValue);
            SqlCommand cm = new SqlCommand("select * from ProductRate", con);
            con.Open();
            SqlDataReader sdr = cm.ExecuteReader();
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    if (sdr.GetInt32(1) == id1)
                    {
                        flag = true;
                        break;
                    }
                }
            }
            return flag;
        }

        protected void btnCancelProductRateAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ProductRate/ProductRate.aspx");
        }
    }
}