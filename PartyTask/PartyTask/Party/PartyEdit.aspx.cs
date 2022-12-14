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
    public partial class PartyEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblPartyEditExist.Text = "";
            if (!IsPostBack)
            {
                txtPartyEdit.Text = Request.QueryString["name"];
            }
        }

        protected void btnUpdateParty_Click(object sender, EventArgs e)
        {
            Boolean flag1 = CheckParty();
            if (flag1 == false)
            {
                if (txtPartyEdit.Text != "")
                {
                    string strcon = ConfigurationManager.ConnectionStrings["PartyProductConnectionString"].ConnectionString;
                    SqlConnection con = new SqlConnection(strcon);
                    try
                    {
                        int id = Convert.ToInt32(Request.QueryString["ID"]);
                        SqlCommand cm = new SqlCommand("update Party set PartyName = '" + txtPartyEdit.Text + "' where ID = " + id, con);
                        con.Open();
                        cm.ExecuteNonQuery();
                        Response.Redirect("~/Party/Party.aspx");
                    }
                    catch (Exception ex)
                    {
                        lblPartyEditExist.Text = txtPartyEdit.Text + " is already Exist...!";
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
            else
            {
                lblPartyEditExist.Text = txtPartyEdit.Text + " is already Exist...!";
            }
        }

        protected void btnCancelParty_Click1(object sender, EventArgs e)
        {
            Response.Redirect("~/Party/Party.aspx");
        }

        protected Boolean CheckParty()
        {
            Boolean flag = false;
            string strcon = ConfigurationManager.ConnectionStrings["PartyProductConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(strcon);
            SqlCommand cm = new SqlCommand("SELECT id FROM Party WHERE PartyName like ('" + txtPartyEdit.Text.Trim() + "')", con);
            con.Open();
            var x = cm.ExecuteScalar();
            int id = Convert.ToInt32(x);
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