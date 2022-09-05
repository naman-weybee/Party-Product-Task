using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace PartyTask
{
    public partial class AssignPartyEdit : System.Web.UI.Page
    {
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
                    ddlAssignPartyNameEdit.DataSource = dt;
                    ddlAssignPartyNameEdit.DataTextField = "PartyName";
                    ddlAssignPartyNameEdit.DataValueField = "ID";
                    ddlAssignPartyNameEdit.DataBind();
                    ddlAssignPartyNameEdit.SelectedValue = ids.ToString();
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
                    ddlAssignProductNameEdit.DataSource = dt;
                    ddlAssignProductNameEdit.DataTextField = "ProductName";
                    ddlAssignProductNameEdit.DataValueField = "ID";
                    ddlAssignProductNameEdit.DataBind();
                    ddlAssignProductNameEdit.SelectedValue = ids.ToString();
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
            AssignPartyName();
            AssignProductName();
            lblAlreadyDataEditExist.Text = "";
        }

        protected void btnUpdateAssignPartyEdit_Click(object sender, EventArgs e)
        {
            Boolean flag1 = CheckProduct();
            if (flag1 == false)
            {
                string strcon = ConfigurationManager.ConnectionStrings["PartyProductConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection(strcon);
                try
                {
                    int id = Convert.ToInt32(Request.QueryString["ID"]);
                    SqlCommand cm = new SqlCommand("update AssignParty set Partyid=" + Convert.ToInt32(ddlAssignPartyNameEdit.SelectedValue) + "where id=" + id, con);
                    SqlCommand cm1 = new SqlCommand("update AssignParty set Productid=" + Convert.ToInt32(ddlAssignProductNameEdit.SelectedValue) + "where id=" + id, con);
                    con.Open();
                    cm.ExecuteNonQuery();
                    cm1.ExecuteNonQuery();
                    Response.Redirect("~/AssignParty/AssignParty.aspx");
                }
                catch (Exception ex)
                {
                    lblAlreadyDataEditExist.Text = ddlAssignPartyNameEdit.SelectedItem + " is already Assign to " + ddlAssignProductNameEdit.SelectedItem + "...!";
                }
                finally
                {
                    con.Close();
                }
            }
            else
            {
                lblAlreadyDataEditExist.Text = ddlAssignPartyNameEdit.SelectedItem + " is already Assign to " + ddlAssignProductNameEdit.SelectedItem + "...!";
            }
        }

        protected void btnCancelAssignPartyEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AssignParty/AssignParty.aspx");
        }
        protected Boolean CheckProduct()
        {
            Boolean flag = false;
            string strcon = ConfigurationManager.ConnectionStrings["PartyProductConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(strcon);
            int id1 = Convert.ToInt32(ddlAssignPartyNameEdit.SelectedValue);
            int id2 = Convert.ToInt32(ddlAssignProductNameEdit.SelectedValue);
            SqlCommand cm = new SqlCommand("select * from AssignParty", con);
            con.Open();
            SqlDataReader sdr = cm.ExecuteReader();
            sdr.Read();
            if (sdr.HasRows)
            {
                if (sdr.GetInt32(1) == id1 && sdr.GetInt32(2) == id2)
                {
                    flag = true;
                }
            }
            return flag;
        }
    }
}