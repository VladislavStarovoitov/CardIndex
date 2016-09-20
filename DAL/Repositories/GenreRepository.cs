using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL.Interface.Repositories;
using System.Data.Entity;
using DAL.Mappers;
using ORM;

namespace DAL.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly DbContext _dataBase;

        public GenreRepository(DbContext dataBase)
        {
            _dataBase = dataBase;
        }

        public IEnumerable<DtoGenre> GetAll()
        {
            var genres = _dataBase.Set<Genre>().Select(g => g)?.ToList().Select(g => g.ToDtoGenre());
            return genres;
        }
    }
}
