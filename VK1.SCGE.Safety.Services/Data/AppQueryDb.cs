using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VK1.SCGE.Safety.Models.ViewModels;

namespace VK1.SCGE.Safety.Services.Data {
    public class AppQueryDb : DbContext{
        public AppQueryDb(DbContextOptions<AppQueryDb> options):base(options) {
            //
        }

        public DbSet<TruckInspectionReportViewModel> TruckInspectionReportViewModels { get; set; }
        public DbSet<YearlyDistanceViewModel> YearlyDistanceViewModels { get; set; }
        public DbSet<MonthlyDistanceViewModel> MonthlyDistanceViewModels { get; set; }
        public DbSet<MonthlyAccidentTransportViewModel> MonthlyAccidentTransportViewModels { get; set; }

        public async Task<IQueryable<T>> QuerySqlAsync<T>(string sql) where T : class {
            return await Task.FromResult(Set<T>().FromSqlRaw(sql));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            //

            modelBuilder.Entity<EmployeeViewModel>().HasNoKey();
            modelBuilder.Entity<TruckInspectionReportViewModel>().HasNoKey();
            modelBuilder.Entity<YearlyDistanceViewModel>().HasNoKey();
            modelBuilder.Entity<MonthlyDistanceViewModel>().HasNoKey();
            modelBuilder.Entity<MonthlyAccidentTransportViewModel>().HasNoKey();
        }
    }
}
