﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.Entity.Entities;

namespace Training.Service.Services.Abstract
{
    public interface IBookService
    {
        Task<List<Book>> ListAllBooksAsync();
    }
}
