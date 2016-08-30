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
            var books = _dataBase.Set<Book>().Include("Authors").Where(b => b.Name == ormBook.Name).ToList();
            bool anyBook = false;
            foreach (var book in books)
            {
                foreach (var author in book.Authors)
                {
                    foreach (var ormAuther in ormBook.Authors)
                    {
                        if (ormAuther.Name == author.Name)
                        {
                            anyBook = true;
                            break;
                        }
                    }
                    if (anyBook)
                        break;
                }
                if (anyBook)
                    break;
            }
            if (!anyBook)
            {

                var existAuthors = ormBook.Authors.Select(ormA => _dataBase.Set<Author>().Where(a => a.Name == ormA.Name).FirstOrDefault()).ToList();
                foreach (var author in existAuthors)
                { 
                    if (!ReferenceEquals(author, null))
                    {
                        ((HashSet<Author>)ormBook.Authors).RemoveWhere(a => a.Name == author.Name);
                        author.Books.Add(ormBook);
                        _dataBase.Set<Author>().Attach(author);
                        _dataBase.Entry(author).State = EntityState.Modified;
                    }
                }
                _dataBase.Set<Book>().Add(ormBook);
            }
            return !anyBook;
        }

        public IEnumerable<DtoBook> GetAll()
        {
            throw new NotImplementedException();
        }

        public DtoBook GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
