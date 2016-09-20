using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DtoComment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime CreationDate { get; set; }
        public int BookId { get; set; }
        public int UserId { get; set; }
        public string UserEmail { get; set; }
        public byte[] Avatar { get; set; }

        public DtoComment()
        {
            Avatar = new byte[0];
        }
    }
}
