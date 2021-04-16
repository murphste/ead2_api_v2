using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using eadca2_v2;

namespace eadca2_v2.Data
{
    public class eadca2_v2Context : DbContext
    {
        public eadca2_v2Context (DbContextOptions<eadca2_v2Context> options)
            : base(options)
        {
        }

        public DbSet<eadca2_v2.Account> Account { get; set; }
    }
}
