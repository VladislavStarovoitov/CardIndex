using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.Repositories;
using System.Data.Entity;
using DTO;
using ORM;
using DAL.Mappers;

namespace DAL.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly DbContext _dataBase;

        public BookRepository(DbContext dataBase)
        {
            _dataBase = dataBase;
        }

        public bool Create(DtoBook entity)
        {
            Book ormBook = entity.ToOrmBook();
            var bookExists = Contains(ormBook);
            if (!bookExists)
            {

                var existAuthors = ormBook.Authors.Select(ormA => _dataBase.Set<Author>().Where(a => a.Name == ormA.Name).FirstOrDefault()).ToList();
                var authorList = ormBook.Authors.ToList();
                ormBook.Authors = new List<Author>();
                foreach (var author in existAuthors)
                { 
                    if (!ReferenceEquals(author, null))
                    {
                        authorList.RemoveAll(a => string.Compare(a.Name, author.Name) == 0);
                        author.Books.Add(ormBook);
                        _dataBase.Set<Author>().Attach(author);
                        _dataBase.Entry(author).State = EntityState.Modified;
                    }
                }
                ((List<Author>)ormBook.Authors).AddRange(authorList);
                _dataBase.Set<Book>().Add(ormBook);
            }
            return !bookExists;
        }

        public bool Create(DtoBook entity, string[] newAuthors, string[] newGenres)
        {
            Book ormBook = entity.ToOrmBook();
            var bookExists = Contains(ormBook);
            var existGenres = _dataBase.Set<Genre>().Where(g => newGenres.Contains(g.Name));
            foreach (var item in existGenres)
            {
                ormBook.Genres.Add(item);
            }
            //var existAuthors = ormBook.Authors.Select(ormA => _dataBase.Set<Author>().Where(a => a.Name == ormA.Name).FirstOrDefault()).ToList();
            return true;
        }

        public IEnumerable<DtoBook> GetAll()
        {
            throw new NotImplementedException();
        }

        public DtoBook GetById(int id)
        {
            throw new NotImplementedException();
        }

        private bool Contains(Book ormBook)
        {
            var books = _dataBase.Set<Book>().Include("Authors").Where(b => b.Name == ormBook.Name).ToList();
            bool bookExists = false;
            foreach (var book in books)
            {
                foreach (var author in book.Authors)
                {
                    foreach (var ormAuther in ormBook.Authors)
                    {
                        if (ormAuther.Name == author.Name)
                        {
                            bookExists = true;
                            break;
                        }
                    }
                    if (bookExists)
                        break;
                }
                if (bookExists)
                    break;
            }
            return bookExists;
        }
    }
}
