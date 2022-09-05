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
    public partial class PartyAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["ID"] != null)
                {
                    txtPartyAdd.Text = Request.QueryString["name"];
                }
            }
        }

        protected void btnSavePartyAdd_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["ID"] == null)
            {
                Boolean flag1 = CheckParty();
                if (flag1 == false)
                {
                    if (txtPartyAdd.Text != "")
                    {
                        string strcon = ConfigurationManager.ConnectionStrings["PartyProductConnectionString"].ConnectionString;
                        SqlConnection con = new SqlConnection(strcon);
                        try
                        {
                            SqlCommand cm = new SqlCommand("SP_Party_Insert", con);
                            con.Open();
                            cm.CommandType = CommandType.StoredProcedure;
                            cm.Parameters.AddWithValue("@PartyName", txtPartyAdd.Text.Trim());
                            cm.ExecuteNonQuery();
                            lblPartyAdd.Text = "Data Inserted Successfully...!";
                            lblPartyAddExist.Text = "";
                        }
                        catch (Exception ex)
                        {
                            lblPartyAdd.Text = "";
                            lblPartyAddExist.Text = txtPartyAdd.Text + " is already Exist...!";
                        }
                        finally
                        {
                            con.Close();
                            txtPartyAdd.Text = "";
                        }
                    }
                }
                else
                {
                    lblPartyAdd.Text = "";
                    lblPartyAddExist.Text = txtPartyAdd.Text + " is already Exist...!";
                }
            }
            else
            {
                Boolean flag1 = CheckParty();
                if (flag1 == false)
                {
                    if (txtPartyAdd.Text != "")
                    {
                        string strcon = ConfigurationManager.ConnectionStrings["PartyProductConnectionString"].ConnectionString;
                        SqlConnection con = new SqlConnection(strcon);
                        try
                        {
                            int id = Convert.ToInt32(Request.QueryString["ID"]);
                            SqlCommand cm = new SqlCommand("SP_Party_Edit", con);
                            con.Open();
                            cm.CommandType = CommandType.StoredProcedure;
                            cm.Parameters.AddWithValue("@id", Convert.ToInt32(Request.QueryString["ID"]));
                            cm.Parameters.AddWithValue("@PartyName", txtPartyAdd.Text.Trim());
                            cm.ExecuteNonQuery();
                            Response.Redirect("~/Party/Party.aspx");
                        }
                        catch (Exception ex)
                        {
                            lblPartyAddExist.Text = txtPartyAdd.Text + " is already Exist...!";
                        }
                        finally
                        {
                            con.Close();
                        }
                    }
                }
                else
                {
                    lblPartyAddExist.Text = txtPartyAdd.Text + " is already Exist...!";
                }
            }
        }

        protected void btnCancelPartyAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Party/Party.aspx");
        }

        protected Boolean CheckParty()
        {
            Boolean flag = false;
            string strcon = ConfigurationManager.ConnectionStrings["PartyProductConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(strcon);
            SqlCommand cm = new SqlCommand("SELECT id FROM Party WHERE PartyName in ('" + txtPartyAdd.Text.Trim() + "')", con);
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
    }
}