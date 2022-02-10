using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VK1.SCGE.Safety.Function.ViewModels;
using VK1.SCGE.Safety.Models;

namespace VK1.SCGE.Safety.Function {
    public class FunctionDb : DbContext {
        public FunctionDb(DbContextOptions<FunctionDb> options) : base(options) {
            //
        }

        public DbSet<TruckInspectionCard> TruckInspectionCards { get; set; }
        public DbSet<CorrectiveActionRequest> CorrectiveActionRequests { get; set; }
        public DbSet<CorrectiveActionRequestItem> CorrectiveActionRequestItems { get; set; }
        public DbSet<LogNumber> LogNumbers { get; set; }

        public DbSet<CARViewModel> CARViewModels { get; set; }

        public async Task<IQueryable<T>> QuerySqlAsync<T>(string sql) where T : class {
            return await Task.FromResult(Set<T>().FromSqlRaw(sql));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CARViewModel>().HasNoKey();
            //enum to string
            modelBuilder.Entity<CorrectiveActionRequest>()
               .Property(x => x.VehicleType)
               .HasConversion<string>();
        }
    }
}
