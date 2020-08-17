using System;
using System.Data;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using BookRental.database_Access_layer;
using BookRental.Models;

namespace BookRental.RepositoryPattern
{
    public class GenreRepository : IGenreRepository
    {
        private database_Access_layer.db dblayer = new database_Access_layer.db();

        public List<Genre> Display()
        {
            DataSet ds = dblayer.Show_data();
            DataTable dt = ds.Tables[0];
            List<Genre> genres = new List<Genre>();

            foreach (DataRow row in dt.Rows)
            {
                Genre genre = new Genre();
                genre.Id = (int)row["Id"];
                genre.Name = (string)row["Name"];
                genres.Add(genre);
            }

            return genres;


        }

        public void Add(Genre genre)
        {
            Genre _genre = new Genre();
            _genre = genre;
            dblayer.Add_record(_genre);
            
        }

        public void Update(Genre genre)
        {
            Debug.Write(genre.Name);
            dblayer.Update_record(genre);
            
        }

        public void Remove(int Id)
        {
            dblayer.delete_record(Id);
        }

        public Genre FindById(int Id)
        {
            DataSet ds = dblayer.Show_record_byid(Id);
            
            DataRow dataRow = ds.Tables[0].Rows[0];
            

            Genre genre = new Genre();
            genre.Id = (int) dataRow["Id"];
            genre.Name = (string) dataRow["Name"];
            return genre;
        }
    }
}