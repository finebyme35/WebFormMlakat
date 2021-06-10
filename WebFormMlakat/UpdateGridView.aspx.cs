using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormMlakat
{
    public partial class UpdateGridView : System.Web.UI.Page
    {
        int OgrId = 1;
        protected void Page_Load(object sender, EventArgs e)
        {

             OgrId = Convert.ToInt32(Request.QueryString["OgrenciId"]);
            
            if (!IsPostBack)
            {
                BindTextBoxvalues(OgrId);
            }
        }

        private void BindTextBoxvalues(int OgrId)
        {
            string constr = ConfigurationManager.ConnectionStrings["MlakatDBConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand("select OgrenciId,DersAdi,Yil,Dönem,Notu from OgrenciDersBilgisis inner join Ogrencis on Ogrencis.Id = OgrenciDersBilgisis.OgrenciId inner join DersBilgisis on DersBilgisis.Id = OgrenciDersBilgisis.DersBilgisiId where Ogrencis.Id=" + OgrId, con);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            txtId.Text = dt.Rows[0][0].ToString();
            txtOgrDersAdi.Text = dt.Rows[0][1].ToString();
            txtDersYil.Text = dt.Rows[0][2].ToString();
            txtDersinDönemi.Text = dt.Rows[0][3].ToString();
            txtNot.Text = dt.Rows[0][4].ToString();
            
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["MlakatDBConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand("update OgrenciDersBilgisis set Yil='" + txtDersYil.Text + "', Dönem='" + txtDersinDönemi.Text + "', Notu='" + txtNot.Text + "' where OgrenciId=" + OgrId
                + "update DersBilgisis set DersAdi='" + txtOgrDersAdi.Text + "' where Id=" + OgrId, con);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            if (result == 1)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowSuccess", "javascript:alert('Record Updated Successfully');", true);
            }
            Response.Redirect("~/Ogrenci.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Ogrenci.aspx");
        }
    }
}