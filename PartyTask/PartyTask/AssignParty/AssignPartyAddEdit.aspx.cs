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
    public partial class AssignPartyAdd : System.Web.UI.Page
    {
        public void AddPartyName()
        {
            if (!IsPostBack)
            {
                string strcon = ConfigurationManager.ConnectionStrings["PartyProductConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection(strcon);
                try
                {
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
                string strcon = ConfigurationManager.ConnectionStrings["PartyProductConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection(strcon);
                try
                {
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
        public void AssignPartyName()
        {
            if (!IsPostBack)
            {
                string strcon = ConfigurationManager.ConnectionStrings["PartyProductConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection(strcon);
                try
                {
                    int id = Convert.ToInt32(Request.QueryString["ID"]);
                    SqlDataAdapter sdr = new SqlDataAdapter("select * from Party", con);
                    SqlCommand cm = new SqlCommand("select Partyid from AssignParty where id=" + id, con);
                    con.Open();
                    DataTable dt = new DataTable();
                    sdr.Fill(dt);
                    var ids = cm.ExecuteScalar();
                    ddlAssignPartyNameAdd.DataSource = dt;
                    ddlAssignPartyNameAdd.DataTextField = "PartyName";
                    ddlAssignPartyNameAdd.DataValueField = "ID";
                    ddlAssignPartyNameAdd.DataBind();
                    ddlAssignPartyNameAdd.SelectedValue = ids.ToString();
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
        public void AssignProductName()
        {
            if (!IsPostBack)
            {
                string strcon = ConfigurationManager.ConnectionStrings["PartyProductConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection(strcon);
                try
                {
                    int id = Convert.ToInt32(Request.QueryString["ID"]);
                    SqlDataAdapter sdr = new SqlDataAdapter("select * from Products", con);
                    SqlCommand cm = new SqlCommand("select Productid from AssignParty where id=" + id, con);
                    con.Open();
                    DataTable dt = new DataTable();
                    sdr.Fill(dt);
                    var ids = cm.ExecuteScalar();
                    ddlAssignProductNameAdd.DataSource = dt;
                    ddlAssignProductNameAdd.DataTextField = "ProductName";
                    ddlAssignProductNameAdd.DataValueField = "ID";
                    ddlAssignProductNameAdd.DataBind();
                    ddlAssignProductNameAdd.SelectedValue = ids.ToString();
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
            if (Request.QueryString["ID"] != null)
            {
                AssignPartyName();
                AssignProductName();
            }
        }

        protected void btnSaveAssignPartyAdd_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["ID"] == null)
            {
                Boolean flag1 = CheckProduct();
                if (flag1 == false)
                {
                    if (ddlAssignPartyNameAdd.SelectedValue != "-1" && ddlAssignProductNameAdd.SelectedValue != "-1")
                    {
                        string strcon = ConfigurationManager.ConnectionStrings["PartyProductConnectionString"].ConnectionString;
                        SqlConnection con = new SqlConnection(strcon);
                        try
                        {
                            con.Open();
                            SqlCommand cm = new SqlCommand("SP_AssignParty_Insert", con);
                            cm.CommandType = CommandType.StoredProcedure;
                            cm.Parameters.AddWithValue("@Partyid", Convert.ToInt32(ddlAssignPartyNameAdd.SelectedValue));
                            cm.Parameters.AddWithValue("@Productid", Convert.ToInt32(ddlAssignProductNameAdd.SelectedValue));
                            cm.ExecuteNonQuery();
                            lblAssignData.Text = "Data Inserted Successfully...!";
                            lblAlreadyDataExist.Text = "";
                            ddlAssignPartyNameAdd.SelectedValue = "-1";
                            ddlAssignProductNameAdd.SelectedValue = "-1";
                        }
                        catch (Exception ex)
                        {
                            lblAlreadyDataExist.Text = ddlAssignPartyNameAdd.SelectedItem + " is already Assign to " + ddlAssignProductNameAdd.SelectedItem + "...!";
                            lblAssignData.Text = "";
                        }
                        finally
                        {
                            con.Close();
                        }
                    }
                }
                else
                {
                    lblAlreadyDataExist.Text = ddlAssignPartyNameAdd.SelectedItem + " is already Assign to " + ddlAssignProductNameAdd.SelectedItem + "...!";
                    lblAssignData.Text = "";
                }
            }
            else
            {
                Boolean flag1 = CheckProduct();
                if (flag1 == false)
                {
                    string strcon = ConfigurationManager.ConnectionStrings["PartyProductConnectionString"].ConnectionString;
                    SqlConnection con = new SqlConnection(strcon);
                    try
                    {
                        SqlCommand cm = new SqlCommand("SP_AssignParty_Edit", con);
                        con.Open();
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.Parameters.AddWithValue("@id", Convert.ToInt32(Request.QueryString["ID"]));
                        cm.Parameters.AddWithValue("@Partyid", Convert.ToInt32(ddlAssignPartyNameAdd.SelectedValue));
                        cm.Parameters.AddWithValue("@Productid", Convert.ToInt32(ddlAssignProductNameAdd.SelectedValue));
                        cm.ExecuteNonQuery();
                        Response.Redirect("~/AssignParty/AssignParty.aspx");
                    }
                    catch (Exception ex)
                    {
                        lblAlreadyDataExist.Text = ddlAssignPartyNameAdd.SelectedItem + " is already Assign to " + ddlAssignProductNameAdd.SelectedItem + "...!";
                    }
                    finally
                    {
                        con.Close();
                    }
                }
                else
                {
                    lblAlreadyDataExist.Text = ddlAssignPartyNameAdd.SelectedItem + " is already Assign to " + ddlAssignProductNameAdd.SelectedItem + "...!";
                }
            }
        }
        protected Boolean CheckProduct()
        {
            Boolean flag = false;
            string strcon = ConfigurationManager.ConnectionStrings["PartyProductConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(strcon);
            int id1 = Convert.ToInt32(ddlAssignPartyNameAdd.SelectedValue);
            int id2 = Convert.ToInt32(ddlAssignProductNameAdd.SelectedValue);
            SqlCommand cm = new SqlCommand("select id from AssignParty where Partyid in (" + id1 + ")and Productid in (" + id2 + ")", con);
            con.Open();
            int id = Convert.ToInt32(cm.ExecuteScalar());
            SqlDataReader sdr = cm.ExecuteReader();
            sdr.Read();
            if (sdr.HasRows)
            {
                if (sdr.GetInt32(0) == id)
                {
                    flag = true;
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
