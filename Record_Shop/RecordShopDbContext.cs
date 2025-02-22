﻿using Microsoft.EntityFrameworkCore;

namespace Record_Shop
{
    public class RecordShopDbContext: DbContext
    {
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    //optionsBuilder.UseInMemoryDatabase(databaseName: "RecordShopMemory");
        //    //optionsBuilder.UseSqlServer();
        //}
        //public RecordShopDbContext()
        //{

        //}
        public RecordShopDbContext(DbContextOptions<RecordShopDbContext> options)
       : base(options) { }


        //public DbSet<Artist> Artists { get; set; }
        public DbSet<Album> Albums { get; set; }
        //public DbSet<Song> Songs { get; set; }

    }
}
