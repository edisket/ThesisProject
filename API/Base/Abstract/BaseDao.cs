using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Base.Abstract
{
    public abstract class BaseDao<T> : DbContext where T : DbContext
    {

        protected T _context;

        public BaseDao()
        {
            _context = new ContextFactory<T>().CreateDbContext(null);

        }

    }
}
