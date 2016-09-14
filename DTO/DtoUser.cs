﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DtoUser
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public DateTime CreationDate { get; set; }

        public List<DtoRole> Roles { get; set; }
    }
}