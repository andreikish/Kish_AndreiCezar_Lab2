using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Kish_AndreiCezar_Lab2.Models;

namespace Kish_AndreiCezar_Lab2.Data
{
    public class Kish_AndreiCezar_Lab2Context : DbContext
    {
        public Kish_AndreiCezar_Lab2Context (DbContextOptions<Kish_AndreiCezar_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Kish_AndreiCezar_Lab2.Models.Book> Book { get; set; } = default!;
        public DbSet<Kish_AndreiCezar_Lab2.Models.Publisher> Publisher { get; set; } = default!;
    }
}
