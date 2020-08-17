using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using BookRental.Models;



namespace BookRental.database_Access_layer
{
    public class db
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);

        public void Add_record(Genre gen)
        {
            SqlCommand com = new SqlCommand("Sp_genre_Add", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Name", gen.Name);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
        
        
        public void Update_record(Genre gen)
        {
            SqlCommand com = new SqlCommand("Sp_genre_new", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Id", gen.Id);
            com.Parameters.AddWithValue("@Name", gen.Name);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }

        public DataSet Show_record_byid(int id)
        {
            SqlCommand com = new SqlCommand("Sp_genre_id", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Id", id);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public DataSet Show_data()
        {
            SqlCommand com = new SqlCommand("Sp_genre_All", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public void delete_record(int id)
        {
            SqlCommand com = new SqlCommand("Sp_genre_delete", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Id", id);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
    }
}