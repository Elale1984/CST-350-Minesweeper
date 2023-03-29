using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CST_350_Minesweeper.Models;
using Microsoft.EntityFrameworkCore;
using Milestone.Models;

    public class Create : DbContext
    {
        public Create (DbContextOptions<Create> options)
            : base(options)
        {
        }

        public DbSet<User> UserModel { get; set; }

        public DbSet<CellModel> CellModel { get; set; }

        public DbSet<BoardModel> BoardModel { get; set; }
    }
