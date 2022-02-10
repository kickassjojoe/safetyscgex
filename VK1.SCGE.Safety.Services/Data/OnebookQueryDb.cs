using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VK1.SCGE.Safety.Models.ViewModels;

namespace VK1.SCGE.Safety.Services.Data {
    public class OnebookQueryDb : DbContext {
        public OnebookQueryDb(DbContextOptions<OnebookQueryDb> options) : base(options) {
            //
        }

        public DbSet<EmployeeViewModel> EmployeeViewModels { get; set; }

        public async Task<IQueryable<T>> QuerySqlAsync<T>(string sql) where T : class {
            return await Task.FromResult(Set<T>().FromSqlRaw(sql));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            //

            modelBuilder.Entity<EmployeeViewModel>().HasNoKey();
        }
    }
}
