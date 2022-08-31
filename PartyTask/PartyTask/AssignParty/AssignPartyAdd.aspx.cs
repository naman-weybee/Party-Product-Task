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
    public partial class AssignPartyAdd : System.Web.UI.Page
    {
        public void AddPartyName()
        {
            if (!IsPostBack)
            {
                SqlConnection con = null;
                try
                {
                    con = new SqlConnection("data source=DESKTOP-9J2CV47; database=PartyProduct; integrated security=SSPI");
                    SqlDataAdapter sdr = new SqlDataAdapter("Select * from Party", con);
                    con.Open();
                    DataTable dt = new DataTable();
                    sdr.Fill(dt);
                    ddlAssignPartyNameAdd.DataSource = dt;
                    ddlAssignPartyNameAdd.DataTextField = "PartyName";
                    ddlAssignPartyNameAdd.DataValueField = "ID";
                    ddlAssignPartyNameAdd.DataBind();
                    ddlAssignPartyNameAdd.Items.Insert(0, new ListItem("Select Party", "-1"));
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
        public void AddProductName()
        {
            if (!IsPostBack)
            {
                SqlConnection con = null;
                try
                {
                    con = new SqlConnection("data source=DESKTOP-9J2CV47; database=PartyProduct; integrated security=SSPI");
                    SqlDataAdapter sdr = new SqlDataAdapter("Select * from Products", con);
                    con.Open();
                    DataTable dt = new DataTable();
                    sdr.Fill(dt);
                    ddlAssignProductNameAdd.DataSource = dt;
                    ddlAssignProductNameAdd.DataTextField = "ProductName";
                    ddlAssignProductNameAdd.DataValueField = "ID";
                    ddlAssignProductNameAdd.DataBind();
                    ddlAssignProductNameAdd.Items.Insert(0, new ListItem("Select Product", "-1"));
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
            AddPartyName();
            AddProductName();
        }

        protected void btnSaveAssignPartyAdd_Click(object sender, EventArgs e)
        {
            Boolean flag1 = CheckProduct();
            if (flag1 == false)
            {
                if (ddlAssignPartyNameAdd.SelectedValue != "-1" && ddlAssignProductNameAdd.SelectedValue != "-1")
                {
                    SqlConnection con = null;
                    try
                    {
                        con = new SqlConnection("data source=DESKTOP-9J2CV47; database=PartyProduct; integrated security=SSPI");
                        con.Open();
                        SqlCommand cm = new SqlCommand("insert into AssignParty(Partyid, Productid)values(" + Convert.ToInt32(ddlAssignPartyNameAdd.SelectedValue) + "," + Convert.ToInt32(ddlAssignProductNameAdd.SelectedValue) + ")", con);
                        cm.ExecuteNonQuery();
                        lblAssignData.Text = "Data Inserted Successfully...!";
                        lblAlreadyDataExist.Text = "";
                        ddlAssignPartyNameAdd.SelectedValue = "-1";
                        ddlAssignProductNameAdd.SelectedValue = "-1";
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
            else
            {
                lblAlreadyDataExist.Text = ddlAssignPartyNameAdd.SelectedItem + " and " + ddlAssignProductNameAdd.SelectedItem + " Pair is already Exist...!";
                lblAssignData.Text = "";
            }
        }
        protected Boolean CheckProduct()
        {
            Boolean flag = false;
            SqlConnection con = new SqlConnection("data source=DESKTOP-9J2CV47; database=PartyProduct; integrated security=SSPI");
            int id1 = Convert.ToInt32(ddlAssignPartyNameAdd.SelectedValue);
            int id2 = Convert.ToInt32(ddlAssignProductNameAdd.SelectedValue);
            SqlCommand cm = new SqlCommand("select * from AssignParty", con);
            con.Open();
            SqlDataReader sdr = cm.ExecuteReader();
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    if (sdr.GetInt32(1) == id1 && sdr.GetInt32(2) == id2)
                    {
                        flag = true;
                        break;
                    }
                }
            }
            return flag;
        }

        protected void btnCancelAssignPartyAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AssignParty/AssignParty.aspx");
        }
    }
}
