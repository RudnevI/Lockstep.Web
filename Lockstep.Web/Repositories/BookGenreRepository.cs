﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lockstep.Web.Data;
using Lockstep.Web.Interfaces;
using LockStep.Library.Domain;


namespace Lockstep.Web.Repositories
{
    public class BookGenreRepository : GenericRepository<BookGenre>, IBookGenreRepository
    {
        public BookGenreRepository(ApplicationDbContext context) : base(context) { }
    }
}
