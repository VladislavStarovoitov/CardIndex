﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL.Interface.Repositories
{
    public interface IRoleRepository
    {
        DtoRole GetByName(string name);
    }
}
