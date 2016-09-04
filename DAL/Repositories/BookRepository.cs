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

        bool IRepository<DtoBook>.Create(DtoBook entity)
        {
            return Create(entity, null, null);
        }

        public bool Create(DtoBook entity, IEnumerable<string> newAuthors, IEnumerable<string> newGenres)
        {
            Book ormBook = entity.ToOrmBook();
            var bookExists = Contains(ormBook);
            if (!bookExists)
            {
                //если дублируется выкидывает NotInvalideOpExc
                UpdateTags<Author>(ormBook.Authors);
                UpdateTags<Genre>(ormBook.Genres);
                //два вызова против одного
                if (!ReferenceEquals(newAuthors, null))
                    AddNewTags<Author>(ormBook.Authors, newAuthors.Select(nA => new Author { Name = nA }));
                if (!ReferenceEquals(newGenres, null))
                    AddNewTags<Genre>(ormBook.Genres, newGenres.Select(nG => new Genre { Name = nG }));

                _dataBase.Set<Book>().Add(ormBook);
            }
            return !bookExists;
        }

        public IEnumerable<DtoBook> GetAll()
        {
            throw new NotImplementedException();
        }

        public DtoBook GetById(int id)
        {
            throw new NotImplementedException();
        }

        private bool Contains(Book ormBook) //проверить
        {
            var authors = ormBook.Authors.Select(a => a.Name);
            bool bookExists = _dataBase.Set<Author>()
                              .Where(a => authors.Contains(a.Name))
                              .Any(a => a.Books
                                  .Any(b => b.Name == ormBook.Name));
            return bookExists;
        }

        private void AddNewTags<TEntity>(ICollection<TEntity> tagCollection, IEnumerable<TEntity> newTags) where TEntity : class, IEntity
        {
            foreach (var item in newTags)
            {
                tagCollection.Add(item);
            }
        }

        private void UpdateTags<TEntity>(ICollection<TEntity> tagCollection) where TEntity : class, IEntity
        {
            foreach (var item in tagCollection)
            {
                _dataBase.Set<TEntity>().Attach(item);
                var entry = _dataBase.Entry(item);
                entry.State = EntityState.Modified;
                entry.Property(e => e.Name).IsModified = false;
            }
        }
    }
}