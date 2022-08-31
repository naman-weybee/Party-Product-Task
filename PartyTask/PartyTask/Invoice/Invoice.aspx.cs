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
    public partial class Invoice : System.Web.UI.Page
    {
        public void InvoicePartyNameAdd()
        {
            if (!IsPostBack)
            {
                SqlConnection con = null;
                try
                {
                    con = new SqlConnection("data source=DESKTOP-9J2CV47; database=PartyProduct; integrated security=SSPI");
                    SqlDataAdapter sdr = new SqlDataAdapter("select * from Party", con);
                    con.Open();
                    DataTable dt = new DataTable();
                    sdr.Fill(dt);
                    ddlInvoicePartyName.DataSource = dt;
                    ddlInvoicePartyName.DataTextField = "PartyName";
                    ddlInvoicePartyName.DataValueField = "ID";
                    ddlInvoicePartyName.DataBind();
                    ddlInvoicePartyName.Items.Insert(0, new ListItem("Select Party", "-1"));
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
        public void InvoiceProductNameAdd()
        {
            SqlConnection con = null;
            try
            {
                int id = Convert.ToInt32(ddlInvoicePartyName.SelectedValue);
                con = new SqlConnection("data source=DESKTOP-9J2CV47; database=PartyProduct; integrated security=SSPI");
                SqlDataAdapter sdr = new SqlDataAdapter("select AssignParty.id, Party.id , AssignParty.Partyid, Party.PartyName, Products.id, AssignParty.Productid, Products.ProductName from AssignParty inner join Party on Party.id = AssignParty.Partyid inner join Products on Products.id = AssignParty.Productid where AssignParty.Partyid =" + id, con);
                con.Open();
                DataTable dt = new DataTable();
                sdr.Fill(dt);
                ddlInvoiceProductName.DataSource = dt;
                ddlInvoiceProductName.DataTextField = "ProductName";
                ddlInvoiceProductName.DataValueField = "ID";
                ddlInvoiceProductName.DataBind();
                ddlInvoiceProductName.Items.Insert(0, new ListItem("Select Product", "-1"));
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
        protected void Page_Load(object sender, EventArgs e)
        {
            InvoicePartyNameAdd();
            lblInvoiceAddSuccess.Text = "";
            if (!IsPostBack)
            {
                btnClearInvoice.Visible = false;
            }
        }

        protected void ddlInvoicePartyName_SelectedIndexChanged(object sender, EventArgs e)
        {
            InvoiceProductNameAdd();
        }

        protected void ddlInvoiceProductName_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = null;
            try
            {
                txtCurrentRate.Enabled = true;
                int id = Convert.ToInt32(ddlInvoicePartyName.SelectedValue);
                int id1 = Convert.ToInt32(ddlInvoiceProductName.SelectedValue);
                con = new SqlConnection("data source=DESKTOP-9J2CV47; database=PartyProduct; integrated security=SSPI");
                SqlCommand cm1 = new SqlCommand("select Productid from AssignParty where id=" + id1, con);
                con.Open();
                var id2 = cm1.ExecuteScalar();
                int id3 = Convert.ToInt32(id2);
                SqlCommand cm = new SqlCommand("select Rate from ProductRate inner join Party on Party.id =" + id + " and Productid =" + id3, con);
                var name = cm.ExecuteScalar();
                int name1 = Convert.ToInt32(name);
                if (name1 == 0)
                {
                    txtCurrentRate.Text = "";
                }
                else
                {
                    txtCurrentRate.Text = name1.ToString();
                }
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

        protected void btnAddToInvoice_Click(object sender, EventArgs e)
        {
            Boolean flag1 = Condition();
            SqlConnection con = null;
            try
            {
                gdInvoice.Visible = true;
                int id3 = Convert.ToInt32(ddlInvoicePartyName.SelectedValue);
                int id = Convert.ToInt32(ddlInvoiceProductName.SelectedValue);
                con = new SqlConnection("data source=DESKTOP-9J2CV47; database=PartyProduct; integrated security=SSPI");
                SqlDataAdapter sdr = new SqlDataAdapter("select Invoice.id, Invoice.Partyid, Invoice.Productid, Party.PartyName, Products.ProductName, RateOfProduct, Quantity, Total from Invoice inner join Party on Party.id = Invoice.Partyid inner join Products on Products.id = Invoice.Productid order by Invoice.id", con);
                SqlCommand cm = new SqlCommand("select Productid from AssignParty where id=" + id, con);
                con.Open();
                var id1 = cm.ExecuteScalar();
                int id2 = Convert.ToInt32(id1);
                if (flag1 == false)
                {
                    SqlCommand cm1 = new SqlCommand("insert into Invoice(Partyid, Productid, RateOfProduct, Quantity, Total)values(" + Convert.ToInt32(ddlInvoicePartyName.SelectedValue) + "," + id2 + "," + Convert.ToInt32(txtCurrentRate.Text.Trim()) + "," + Convert.ToInt32(txtQuantity.Text.Trim()) + "," + Convert.ToInt64(Convert.ToInt32(txtCurrentRate.Text.Trim()) * Convert.ToInt32(txtQuantity.Text.Trim())) + ")", con);
                    cm1.ExecuteNonQuery();
                }
                else
                {
                    SqlCommand cm1 = new SqlCommand("select Quantity from Invoice where Productid=" + id2, con);
                    var quan = cm1.ExecuteScalar();
                    int quantity = Convert.ToInt32(quan);
                    SqlCommand cm3 = new SqlCommand("update Invoice set Quantity =" + Convert.ToInt32(quantity + Convert.ToInt32(txtQuantity.Text)) + " where Partyid=" + id3 + "and Productid ="+ id2, con);
                    cm3.ExecuteNonQuery();
                    SqlCommand cm4 = new SqlCommand("update Invoice set Total =" + Convert.ToInt64(Convert.ToInt32(txtCurrentRate.Text.Trim()) * Convert.ToInt32(quantity + Convert.ToInt32(txtQuantity.Text.Trim()))) + "where Partyid =" + id3 + " and Productid=" + id2, con);
                    cm4.ExecuteNonQuery();
                }
                SqlCommand cm2 = new SqlCommand("select sum(Total) from Invoice", con);
                var total = cm2.ExecuteScalar();
                DataSet ds = new DataSet();
                sdr.Fill(ds);
                gdInvoice.DataSource = ds;
                gdInvoice.DataBind();
                lblGrandTotal.Text = total.ToString();
                btnClearInvoice.Visible = true;
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            finally
            {
                con.Close();
                txtQuantity.Text = "";
                txtCurrentRate.Enabled = false;
                lblInvoiceAddSuccess.Text = "Data Inserted Successfully...!";
                ddlInvoicePartyName.Enabled = false;
            }
        }

        protected void btnCloseInvoice_Click(object sender, EventArgs e)
        {
            lblGrandTotal.Text = "";
            lblInvoiceAddSuccess.Text = "";
            txtCurrentRate.Text = "";
            txtQuantity.Text = "";
            ddlInvoicePartyName.SelectedValue = "-1";
            ddlInvoiceProductName.SelectedValue = "-1";
            gdInvoice.Visible = false;
            ddlInvoicePartyName.Enabled = true;
            btnClearInvoice.Visible = false;
        }

        protected void btnClearInvoice_Click(object sender, EventArgs e)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection("data source=DESKTOP-9J2CV47; database=PartyProduct; integrated security=SSPI");
                SqlCommand cm = new SqlCommand("truncate table Invoice", con);
                con.Open();
                cm.ExecuteNonQuery();
                btnClearInvoice.Visible = false;
                Response.Redirect("~/Invoice/Invoice.aspx");
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
        protected Boolean Condition()
        {
            Boolean flag = false;
            SqlConnection con = new SqlConnection("data source=DESKTOP-9J2CV47; database=PartyProduct; integrated security=SSPI");
            int id1 = Convert.ToInt32(ddlInvoicePartyName.SelectedValue);
            int id2 = Convert.ToInt32(ddlInvoiceProductName.SelectedValue);
            SqlCommand cm = new SqlCommand("select * from Invoice", con);
            SqlCommand cm1 = new SqlCommand("select Productid from AssignParty where id=" + id2, con);
            con.Open();
            var x = cm1.ExecuteScalar();
            int id3 = Convert.ToInt32(x);
            SqlDataReader sdr = cm.ExecuteReader();
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    if (sdr.GetInt32(1) == id1 && sdr.GetInt32(2) == id3)
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
