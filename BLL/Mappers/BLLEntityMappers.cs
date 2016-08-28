using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.DTO;
using BLL.Interface.Entities;

namespace BLL.Mappers
{
    public static class BLLEntityMappers
    {
        public static DALBook ToDalBook(this BLLBook bllBook)
        {
            return new DALBook
            {
                Id = bllBook.Id,
                Authors = bllBook.Authors,
                Description = bllBook.Description,
                Image = bllBook.Image,
                Name = bllBook.Name,
                Year = bllBook.Year
            };
        }

        public static BLLBook ToBllBook(this DALBook dalBook)
        {
            return new BLLBook
            {
                Id = dalBook.Id,
                Authors = dalBook.Authors,
                Description = dalBook.Description,
                Image = dalBook.Image,
                Name = dalBook.Name,
                Year = dalBook.Year
            };
        }
    }
}
