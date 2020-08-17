using System.Collections.Generic;
using BookRental.Models;
namespace BookRental.RepositoryPattern
{
    public interface IGenreRepository
    {
        List<Genre> Display();
        void Add(Genre genre);
        void Update(Genre genre);
        void Remove(int Id);
        Genre FindById(int Id);
    }
}