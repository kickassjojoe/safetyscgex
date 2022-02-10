using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace VK1.SCGE.Safety.Services.Core {
    public abstract class ServiceBase<T> : IService<T> where T : class {
        private readonly App app;

        public ServiceBase(App app) {
            this.app = app;
        }

        public virtual async Task<T> AddAsync(T item) {
            var _result = await app.db.Set<T>().AddAsync(item);
            Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<T> result = await Task.FromResult(_result);
            return result.Entity;
        }

        public virtual async Task<IQueryable<T>> AllAsync() {
            return await QueryAsync(x => true);
        }

        public virtual async Task<IQueryable<T>> QueryAsync(Expression<Func<T, bool>> criteria) {
            return await Task.FromResult(app.db.Set<T>().Where(criteria));
        }

        public virtual async Task<IQueryable<T>> AllAsyncAsNoTracking() {
            return await QueryAsyncAsNoTracking(x => true);
        }

        public virtual async Task<IQueryable<T>> QueryAsyncAsNoTracking(Expression<Func<T, bool>> criteria) {
            return await Task.FromResult(app.db.Set<T>().AsNoTracking().Where(criteria));
        }

        public virtual async Task<bool> AnyAsync(Expression<Func<T, bool>> criteria) {
            return await await Task.FromResult(app.db.Set<T>().AnyAsync(criteria));
        }

        public virtual async Task<bool> AnyAsyncAsNoTracking(Expression<Func<T, bool>> criteria) {
            return await await Task.FromResult(app.db.Set<T>().AsNoTracking().AnyAsync(criteria));
        }

        public async Task BulkDeleteAsync(List<T> items) {
            await app.db.BulkDeleteAsync(items);
        }

        public async Task BulkInsert(List<T> items) {
            await app.db.BulkInsertAsync(items);
        }

        public async Task BulkUpdateAsync(List<T> items) {
            await app.db.BulkUpdateAsync(items);
        }

        public virtual async Task<T> FindAsync(params object[] keys) {
            return await app.db.Set<T>().FindAsync(keys);
        }

        public virtual async Task<T> RemoveAsync(T item) {
            return await Task.FromResult(app.db.Set<T>().Remove(item).Entity);
        }

        public virtual async Task<T> SingleOrDefaultAsNoTracking(Expression<Func<T, bool>> criteria) {
            return (await await Task.FromResult(app.db.Set<T>().AsNoTracking().SingleOrDefaultAsync(criteria)));
        }

        public virtual async Task<T> UpdateAsync(T item) {
            return await Task.FromResult(app.db.Set<T>().Update(item).Entity);
        }
    }
}
