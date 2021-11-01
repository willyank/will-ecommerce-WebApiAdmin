﻿using EcommerceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiAdmin.Repositories.Interfaces
{
    public interface ICategoriesRepository : IBaseRepository<Category>
    {
        Task<bool> Teste();
    }
}