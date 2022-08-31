using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace PartyTask
{
    public partial class AssignPartyEdit : System.Web.UI.Page
    {
        public void AssignPartyName()
        {
            if (!IsPostBack)
            {
                SqlConnection con = null;
                try
                {
                    int id = Convert.ToInt32(Request.QueryString["ID"]);
                    con = new SqlConnection("data source=DESKTOP-9J2CV47; database=PartyProduct; integrated security=SSPI");
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
                    Response.Write("OOPs, something went wrong." + ex);
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
                SqlConnection con = null;
                try
                {
                    int id = Convert.ToInt32(Request.QueryString["ID"]);
                    con = new SqlConnection("data source=DESKTOP-9J2CV47; database=PartyProduct; integrated security=SSPI");
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
            AssignPartyName();
            AssignProductName();
        }

        protected void btnUpdateAssignPartyEdit_Click(object sender, EventArgs e)
        {
            SqlConnection con = null;
            try
            {
                int id = Convert.ToInt32(Request.QueryString["ID"]);
                con = new SqlConnection("data source=DESKTOP-9J2CV47; database=PartyProduct; integrated security=SSPI");
                SqlCommand cm = new SqlCommand("update AssignParty set Partyid=" + Convert.ToInt32(ddlAssignPartyNameEdit.SelectedValue) + "where id=" + id, con);
                SqlCommand cm1 = new SqlCommand("update AssignParty set Productid=" + Convert.ToInt32(ddlAssignProductNameEdit.SelectedValue) + "where id=" + id, con);
                con.Open();
                cm.ExecuteNonQuery();
                cm1.ExecuteNonQuery();
                Response.Redirect("~/AssignParty.aspx");
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
}