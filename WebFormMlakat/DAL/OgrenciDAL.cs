using Backend.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace WebFormMlakat.DAL
{
    public class OgrenciDAL
    {
        public List<OgrenciE> GetOgrencis()
        {
            SqlConnection connection = new SqlConnection(@"server=OGUZCAN\SQLEXPRESS;initial catalog=MlakatDB;integrated security=true");
            if(connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            SqlCommand command = new SqlCommand("SELECT TCKimlik,Adi,Soyadi,OgrenciNo FROM Ogrencis", connection);

            SqlDataReader reader = command.ExecuteReader();

            List<OgrenciE> ogrencis = new List<OgrenciE>();
            while (reader.Read())
            {

                OgrenciE ogrenci = new OgrenciE
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Adi = reader["Adi"].ToString(),
                    Soyadi = reader["Soyadi"].ToString(),
                    OgrenciNo = Convert.ToInt32(reader["OgrenciNo"]),
                    TcKimlik = reader["TcKimlik"].ToString(),
                    //OgrenciDersBilgisiId = Convert.ToInt32(reader["Id"]),
                    ////OgrenciDersBilgileri = new OgrenciDersBilgisi
                    ////{
                    ////    Yil = reader["Yil"].ToString(),
                    ////    Notu = Convert.ToInt32(reader["Notu"]),
                    ////    Dönem = reader["Dönem"].ToString(),
                    ////},
                    //DersBilgisiId = Convert.ToInt32(reader["Id"]),
                    ////DersBilgisi = new DersBilgisi
                    ////{
                    ////    DersAdi = reader["DersAdi"].ToString(),
                    ////    DersKodu = Convert.ToInt32(reader["DersKodu"])
                    ////},
                };
                
                ogrencis.Add(ogrenci);
            }


            reader.Close();
            connection.Close();
            return ogrencis;
        } 
    }
}