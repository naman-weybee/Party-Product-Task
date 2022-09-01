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
    public partial class PartyAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSavePartyAdd_Click(object sender, EventArgs e)
        {
            Boolean flag1 = CheckParty();
            if (flag1 == false)
            {
                if (txtPartyAdd.Text != "")
                {
                    SqlConnection con = null;
                    try
                    {
                        con = new SqlConnection("data source=DESKTOP-9J2CV47; database=PartyProduct; integrated security=SSPI");
                        SqlCommand cm = new SqlCommand("insert into Party(PartyName)values('" + txtPartyAdd.Text.Trim() + "')", con);
                        con.Open();
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


        //protected void btnSavePartyAdd_Click(object sender, EventArgs e)
        //{
        //    if (txtPartyAdd.Text != "")
        //    {
        //        SqlConnection con = null;
        //        try
        //        {
        //            con = new SqlConnection("data source=DESKTOP-9J2CV47; database=PartyProduct; integrated security=SSPI");
        //            SqlCommand cm = new SqlCommand("insert into Party(PartyName)values('" + txtPartyAdd.Text.Trim() + "')", con);
        //            con.Open();
        //            cm.ExecuteNonQuery();
        //            lblPartyAdd.Text = "Data Inserted Successfully...!";
        //            lblPartyAddExist.Text = "";
        //        }
        //        catch (Exception ex)
        //        {
        //            Response.Write("<script>alert(\"Party Can't be Added Because it is already Present...!\")</script>");
        //            Response.Write(ex.Message);
        //        }
        //        finally
        //        {
        //            con.Close();
        //        }
        //    }
        //}

        protected void btnCancelPartyAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Party/Party.aspx");
        }

        protected Boolean CheckParty()
        {
            Boolean flag = false;
            SqlConnection con = new SqlConnection("data source=DESKTOP-9J2CV47; database=PartyProduct; integrated security=SSPI");
            SqlCommand cm = new SqlCommand("SELECT id FROM Party WHERE PartyName in ('" + txtPartyAdd.Text.Trim() + "')", con);
            con.Open();
            var x = cm.ExecuteScalar();
            int id = Convert.ToInt32(x);
            SqlDataReader sdr = cm.ExecuteReader();
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    if (sdr.GetInt32(0) == id)
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