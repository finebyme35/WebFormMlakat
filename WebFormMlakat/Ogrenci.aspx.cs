using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace WebFormMlakat
{
    public partial class Ogrenci : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillYil();
                FillDönem();
               
            }

        }
        
        protected void bListele_Click(object sender, EventArgs e)
        {

            if (ddlYil.SelectedValue != "")
            {
                YilaGoreListe(Convert.ToInt32(ddlYil.SelectedValue));


            }
            if (ddlDönem.SelectedValue != "")
            {
                DonemeGoreListele(ddlDönem.SelectedValue);
            }
            if (!string.IsNullOrWhiteSpace(tbTC.Text))
            {
                TCKimlikNoyaGore(tbTC.Text);
            }
            if (!string.IsNullOrWhiteSpace(tbOgrenciNo.Text))
            {
                OgrenciNoyaGore(tbOgrenciNo.Text);
            }
            if (!string.IsNullOrWhiteSpace(tbAdi.Text))
            {
                AdaGoreListele(tbAdi.Text);
            }
            if (!string.IsNullOrWhiteSpace(tbSoyadi.Text))
            {
                SoyadaGoreListele(tbSoyadi.Text);
            }
            if (!string.IsNullOrWhiteSpace(tbDersAdi.Text))
            {
                DersAdiListele(tbDersAdi.Text);
            }
            if (!string.IsNullOrWhiteSpace(tbDerskodu.Text))
            {
                DersKoduListele(tbDerskodu.Text);
            }








        }
        
        public void FillYil()
        {
            string CS = ConfigurationManager.ConnectionStrings["MlakatDBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlDataAdapter yil = new SqlDataAdapter("Select distinct Yil from OgrenciDersBilgisis", con);
                DataSet yilGetir = new DataSet();
                yil.Fill(yilGetir);
                ddlYil.DataTextField = "Yil";
                ddlYil.DataSource = yilGetir;
                ddlYil.DataBind();
                ddlYil.Items.Insert(0, new ListItem()
                {
                    Value = "",
                    Text = "-- Seçiniz --"
                });
            }
        }
        public void FillDönem()
        {
            string CS = ConfigurationManager.ConnectionStrings["MlakatDBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {

                SqlDataAdapter dönem = new SqlDataAdapter("Select distinct Dönem from OgrenciDersBilgisis", con);
                DataSet dönemGetir = new DataSet();
                dönem.Fill(dönemGetir);
                //ddlDönem.DataValueField = "Id";
                ddlDönem.DataTextField = "Dönem";
                ddlDönem.DataSource = dönemGetir;
                ddlDönem.DataBind();
                ddlDönem.Items.Insert(0, new ListItem()
                {
                    Value = "",
                    Text = "-- Seçiniz --"
                });
            }
        }

        public void TumListe()
        {
            string CS = ConfigurationManager.ConnectionStrings["MlakatDBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlDataAdapter da = new SqlDataAdapter("Select Id,TcKimlik,Adi,Soyadi,OgrenciNo,DersAdi,DersKodu,Yil,Dönem,Notu from OgrenciDersBilgisis inner join Ogrencis on OgrenciDersBilgisis.OgrenciId = Ogrencis.Id inner join DersBilgisis on OgrenciDersBilgisis.DersBilgisiId = DersBilgisis.Id ", con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                gvOgrenciler.DataSource = ds;
                gvOgrenciler.DataBind();
            }
        }
        public void YilaGoreListe(int Yili)
        {
            string CS = ConfigurationManager.ConnectionStrings["MlakatDBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {

                SqlDataAdapter find = new SqlDataAdapter("Select Yil,Dönem,Notu,TCKimlik,Adi,Soyadi,OgrenciNo,DersAdi,DersKodu from OgrenciDersBilgisis inner join Ogrencis on OgrenciDersBilgisis.OgrenciId =Ogrencis.Id inner join DersBilgisis on OgrenciDersBilgisis.DersBilgisiId = DersBilgisis.Id where OgrenciDersBilgisis.Yil = " + Yili, con);
                DataSet findDs = new DataSet();
                find.Fill(findDs);
                gvOgrenciler.DataSource = findDs;
                gvOgrenciler.DataBind();

            }
        }

        public void DonemeGoreListele(string Dönemi)
        {
            string CS = ConfigurationManager.ConnectionStrings["MlakatDBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {


                SqlCommand sql = new SqlCommand(
                    "Select Yil,Dönem,Notu,TCKimlik,Adi,Soyadi,OgrenciNo,DersAdi,DersKodu from OgrenciDersBilgisis inner join Ogrencis on OgrenciDersBilgisis.OgrenciId =Ogrencis.Id inner join DersBilgisis on OgrenciDersBilgisis.DersBilgisiId = DersBilgisis.Id where OgrenciDersBilgisis.Dönem like @Dönemi", con);
                sql.Parameters.AddWithValue("@Dönemi", Dönemi);
                SqlDataAdapter donemFind = new SqlDataAdapter(sql);

                DataSet donemFinder = new DataSet();
                donemFind.Fill(donemFinder);
                gvOgrenciler.DataSource = donemFinder;
                gvOgrenciler.DataBind();

            }
        }
        public void TCKimlikNoyaGore(string TCKimlik)
        {
            string CS = ConfigurationManager.ConnectionStrings["MlakatDBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {


                SqlCommand tcFind = new SqlCommand(
                    "Select Yil,Dönem,Notu,TCKimlik,Adi,Soyadi,OgrenciNo,DersAdi,DersKodu from OgrenciDersBilgisis inner join Ogrencis on OgrenciDersBilgisis.OgrenciId = Ogrencis.Id inner join DersBilgisis on OgrenciDersBilgisis.DersBilgisiId = DersBilgisis.Id where Ogrencis.TCKimlik=@TCKimlik", con);
                tcFind.Parameters.AddWithValue("@TCKimlik", TCKimlik);
                SqlDataAdapter sqlData = new SqlDataAdapter(tcFind);
                DataSet tcFinder = new DataSet();
                sqlData.Fill(tcFinder);
                gvOgrenciler.DataSource = tcFinder;
                gvOgrenciler.DataBind();

            }
        }
        public void OgrenciNoyaGore(string OgrenciNo)
        {
            string CS = ConfigurationManager.ConnectionStrings["MlakatDBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {


                SqlCommand sql = new SqlCommand(
                    "Select Yil,Dönem,Notu,TCKimlik,Adi,Soyadi,OgrenciNo,DersAdi,DersKodu from OgrenciDersBilgisis inner join Ogrencis on OgrenciDersBilgisis.OgrenciId = Ogrencis.Id inner join DersBilgisis on OgrenciDersBilgisis.DersBilgisiId = DersBilgisis.Id where Ogrencis.OgrenciNo=@OgrenciNo", con);
                sql.Parameters.AddWithValue("@OgrenciNo", OgrenciNo);
                SqlDataAdapter sqlData = new SqlDataAdapter(sql);
                DataSet ogrenciNoFind = new DataSet();
                sqlData.Fill(ogrenciNoFind);
                gvOgrenciler.DataSource = ogrenciNoFind;
                gvOgrenciler.DataBind();

            }
        }

        public void AdaGoreListele(string Adi)
        {
            string CS = ConfigurationManager.ConnectionStrings["MlakatDBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {


                SqlCommand sql = new SqlCommand(
                    "Select Yil,Dönem,Notu,TCKimlik,Adi,Soyadi,OgrenciNo,DersAdi,DersKodu from OgrenciDersBilgisis inner join Ogrencis on OgrenciDersBilgisis.OgrenciId = Ogrencis.Id inner join DersBilgisis on OgrenciDersBilgisis.DersBilgisiId = DersBilgisis.Id where Ogrencis.Adi like @Adi", con);
                sql.Parameters.AddWithValue("@Adi", Adi);
                SqlDataAdapter sqlData = new SqlDataAdapter(sql);
                DataSet adiFind = new DataSet();
                sqlData.Fill(adiFind);
                gvOgrenciler.DataSource = adiFind;
                gvOgrenciler.DataBind();

            }
        }
        public void SoyadaGoreListele(string Soyadi)
        {
            string CS = ConfigurationManager.ConnectionStrings["MlakatDBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {


                SqlCommand sql = new SqlCommand(
                    "Select Yil,Dönem,Notu,TCKimlik,Adi,Soyadi,OgrenciNo,DersAdi,DersKodu from OgrenciDersBilgisis inner join Ogrencis on OgrenciDersBilgisis.OgrenciId = Ogrencis.Id inner join DersBilgisis on OgrenciDersBilgisis.DersBilgisiId = DersBilgisis.Id where Ogrencis.Soyadi like @Soyadi", con);
                sql.Parameters.AddWithValue("@Soyadi", Soyadi);
                SqlDataAdapter sqlData = new SqlDataAdapter(sql);
                DataSet soyadiFind = new DataSet();
                sqlData.Fill(soyadiFind);
                gvOgrenciler.DataSource = soyadiFind;
                gvOgrenciler.DataBind();

            }
        }

        public void DersAdiListele(string DersAdi)
        {
            string CS = ConfigurationManager.ConnectionStrings["MlakatDBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {


                SqlCommand sql = new SqlCommand(
                    "Select Yil,Dönem,Notu,TCKimlik,Adi,Soyadi,OgrenciNo,DersAdi,DersKodu from OgrenciDersBilgisis inner join Ogrencis on OgrenciDersBilgisis.OgrenciId = Ogrencis.Id inner join DersBilgisis on OgrenciDersBilgisis.DersBilgisiId = DersBilgisis.Id where DersBilgisis.DersAdi like @DersAdi", con);
                sql.Parameters.AddWithValue("@DersAdi", DersAdi);
                SqlDataAdapter sqlData = new SqlDataAdapter(sql);
                DataSet dersAdiFind = new DataSet();
                sqlData.Fill(dersAdiFind);
                gvOgrenciler.DataSource = dersAdiFind;
                gvOgrenciler.DataBind();

            }
        }
        public void DersKoduListele(string DersKodu)
        {
            string CS = ConfigurationManager.ConnectionStrings["MlakatDBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {


                SqlCommand sql = new SqlCommand(
                    "Select Yil,Dönem,Notu,TCKimlik,Adi,Soyadi,OgrenciNo,DersAdi,DersKodu from OgrenciDersBilgisis inner join Ogrencis on OgrenciDersBilgisis.OgrenciId = Ogrencis.Id inner join DersBilgisis on OgrenciDersBilgisis.DersBilgisiId = DersBilgisis.Id where DersBilgisis.DersKodu=@DersKodu", con);
                sql.Parameters.AddWithValue("@DersKodu", DersKodu);
                SqlDataAdapter sqlData = new SqlDataAdapter(sql);
                DataSet dersKoduFind = new DataSet();
                sqlData.Fill(dersKoduFind);
                gvOgrenciler.DataSource = dersKoduFind;
                gvOgrenciler.DataBind();

            }
        }


        public void DersAdiFiltreleme(string DersAdi)
        {
            string CS = ConfigurationManager.ConnectionStrings["MlakatDBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {


                SqlCommand sql = new SqlCommand(
                    "Select Yil,Dönem,Notu,TCKimlik,Adi,Soyadi,OgrenciNo,DersAdi,DersKodu from OgrenciDersBilgisis inner join Ogrencis on OgrenciDersBilgisis.OgrenciId = Ogrencis.Id inner join DersBilgisis on OgrenciDersBilgisis.DersBilgisiId = DersBilgisis.Id where DersBilgisis.DersAdi like @DersAdi", con);
                sql.Parameters.AddWithValue("@DersAdi", DersAdi);
                SqlDataAdapter sqlData = new SqlDataAdapter(sql);
                DataSet dersAdiFind = new DataSet();
                sqlData.Fill(dersAdiFind);
                gvOgrenciler.DataSource = dersAdiFind;
                gvOgrenciler.DataBind();

            }
        }
        protected void bTumListe_Click(object sender, EventArgs e)
        {
            refreshdata();
        }
        public void Silmeİslemi()
        {
            string CS = ConfigurationManager.ConnectionStrings["MlakatDBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {


                SqlCommand sql = new SqlCommand(
                    "Select * from Ogrenci inner join DersBilgisi on DersBilgisi.Id = Ogrenci.Id ", con);
                var id = gvOgrenciler.SelectedRow.Cells[1].Text;
                sql.Parameters.AddWithValue("@id", id);
                SqlDataAdapter sqlData = new SqlDataAdapter(sql);
                DataSet sil = new DataSet();
                sqlData.Fill(sil);
                gvOgrenciler.DataSource = sil;
                gvOgrenciler.DataBind();

            }
        }

        protected void bSil_Click(object sender, EventArgs e)
        {
            if (gvOgrenciler.SelectedIndex == -1)
            {
                lMesaj.Text = "Kayıt seçiniz";
                return;
            }
            Silmeİslemi();

        }

        

        protected void gvOgrenciler_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataTable dtrslt = (DataTable)ViewState["dirState"];
            if (dtrslt.Rows.Count >= -1)
            {
                if (Convert.ToString(ViewState["sortdr"]) == "Asc")
                {
                    dtrslt.DefaultView.Sort = e.SortExpression + " Desc";
                    ViewState["sortdr"] = "Desc";
                }
                else
                {
                    dtrslt.DefaultView.Sort = e.SortExpression + " Asc";
                    ViewState["sortdr"] = "Asc";
                }
                gvOgrenciler.DataSource = dtrslt;
                gvOgrenciler.DataBind();


            }
        }

        public void refreshdata()
        {

            string CS = ConfigurationManager.ConnectionStrings["MlakatDBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("Select OgrenciId,TcKimlik,Adi,Soyadi,OgrenciNo,Notu,Yil,Dönem,DersAdi,DersKodu from OgrenciDersBilgisis inner join Ogrencis on OgrenciDersBilgisis.OgrenciId = Ogrencis.Id inner join DersBilgisis on OgrenciDersBilgisis.DersBilgisiId = DersBilgisis.Id", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                gvOgrenciler.DataSource = dt;
                gvOgrenciler.DataBind();
                ViewState["dirState"] = dt;
                ViewState["sortdr"] = "Asc";
            }

        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }
        protected void ExportToWordClick(object sender, EventArgs e)
        {
            ExportGridToword();
        }
        private void ExportGridToword()
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Charset = "UTF-8";
            Response.ContentEncoding = System.Text.Encoding.Unicode;
            Response.BinaryWrite(System.Text.Encoding.Unicode.GetPreamble());
            string FileName = "Sample" + DateTime.Now + ".doc";
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/msword";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            gvOgrenciler.GridLines = GridLines.Both;
            gvOgrenciler.HeaderStyle.Font.Bold = true;
            gvOgrenciler.RenderControl(htmltextwrtter);
            Response.Write(strwritter.ToString());
            Response.End();

        }

        protected void ExportToExcelClick(object sender, EventArgs e)
        {
            ExportGridToExcel();
        }

        private void ExportGridToExcel()
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Charset = "UTF-8";
            Response.ContentEncoding = System.Text.Encoding.Unicode;
            Response.BinaryWrite(System.Text.Encoding.Unicode.GetPreamble());
            string FileName = "Sample" + DateTime.Now + ".xls";
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            gvOgrenciler.GridLines = GridLines.Both;
            gvOgrenciler.HeaderStyle.Font.Bold = true;
            gvOgrenciler.RenderControl(htmltextwrtter);
            Response.Write(strwritter.ToString());
            Response.End();

        }

        protected void gvOgrenciler_SelectedIndexChanged(object sender, EventArgs e)
        {
            string CustomerID = gvOgrenciler.SelectedDataKey.Value.ToString();
            string CustomerName = gvOgrenciler.SelectedRow.Cells[0].Text;
        }

        protected void gvOgrenciler_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("ondblclick", "__doPostBack('gvOgrenciler','Select$" + e.Row.RowIndex + "');");
            }
        }

        protected void gvOgrenciler_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditButton")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvOgrenciler.Rows[index];
                Response.Redirect("~/UpdateGridView.aspx?OgrenciId=" + row.Cells[1].Text);
            }
        }
    }   
}