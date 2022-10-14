using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcCandel.Models;

namespace MvcCandel.Data
{
    public class MvcCandelContext
   : DbContext
    {
        public MvcCandelContext(DbContextOptions<MvcCandelContext> options)
            : base(options)
        {
        }

        public DbSet<Candel> Candel { get; set; }
    }
}
