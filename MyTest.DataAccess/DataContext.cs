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


        #region MyRegion
        //public DbSet<T1> T1 { get; set; }
        //public DbSet<T2> T2 { get; set; }
        //public DbSet<T3> T3 { get; set; }
        //public DbSet<T4> T4 { get; set; }
        //public DbSet<T5> T5 { get; set; }
        //public DbSet<T6> T6 { get; set; }
        //public DbSet<T7> T7 { get; set; }
        //public DbSet<T8> T8 { get; set; }
        #endregion
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
