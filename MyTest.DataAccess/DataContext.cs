using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using MyTest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using WalkingTec.Mvvm.Core;

namespace MyTest.DataAccess
{
    public class DataContext : FrameworkContext
    {
        public DbSet<TableTest> TableTest { get; set; }

        public DbSet<Exam> Exam { get; set; }

        public DbSet<ExamType> ExamType { get; set; }

        public DbSet<LinkManInfo> LinkManInfo { get; set; }

        public DbSet<LinkManType> LinkManType { get; set; }

        public DbSet<StuTable> StuTable { get; set; }

        public DbSet<MyUser> MyUser { get; set; }

        public DataContext(CS cs)
             : base(cs)
        {
        }

        public DataContext(string cs, DBTypeEnum dbtype, string version = null)
             : base(cs, dbtype, version)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }

    /// <summary>
    /// DesignTimeFactory for EF Migration, use your full connection string,
    /// EF will find this class and use the connection defined here to run Add-Migration and Update-Database
    /// </summary>
    public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            return new DataContext("your full connection string", DBTypeEnum.SqlServer);
        }
    }

}
