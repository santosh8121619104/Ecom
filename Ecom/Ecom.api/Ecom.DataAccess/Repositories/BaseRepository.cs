using Ecom.DataAccess.DBConfig;
using Ecom.DataAccess.DBContext.Interface;
using Ecom.DataAccess.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.DataAccess.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        public IEcomDbContext EcomDbContext { get; }


        public IClientDBConnection _ClientDBConnection;

        public BaseRepository()
        {

        }
        public BaseRepository(IEcomDbContext EcomDbContext, IClientDBConnection ClientDBConnection)
        {
            this.EcomDbContext = EcomDbContext;
            this._ClientDBConnection = ClientDBConnection;
        }

        public Task<List<T>> List()
        {
            SetReadSettings();
            return EcomDbContext.Instance.Set<T>().AsNoTracking().ToListAsync();
        }

        public Task<List<DTO>> List<DTO>(Expression<Func<T, DTO>> select)
        {
            SetReadSettings();
            return EcomDbContext.Instance.Set<T>().AsNoTracking().Select(select).ToListAsync();
        }

        public Task<T> First(Expression<Func<T, bool>> predicate)
        {
            SetReadSettings();
            return EcomDbContext.Instance.Set<T>().AsNoTracking().FirstOrDefaultAsync<T>(predicate);
        }

        public Task<DTO> First<DTO>(Expression<Func<T, bool>> predicate, Expression<Func<T, DTO>> select)
        {
            SetReadSettings();
            return EcomDbContext.Instance.Set<T>().AsNoTracking().Where(predicate).Select(select).FirstOrDefaultAsync();
        }

        public Task<List<T>> Where(Expression<Func<T, bool>> predicate)
        {
            SetReadSettings();
            return EcomDbContext.Instance.Set<T>().AsNoTracking().Where(predicate).ToListAsync();
        }

        public Task<List<DTO>> Where<DTO>(Expression<Func<T, bool>> predicate, Expression<Func<T, DTO>> select)
        {
            SetReadSettings();
            return EcomDbContext.Instance.Set<T>().AsNoTracking().Where(predicate).Select(select).ToListAsync();
        }

        public void Create(T entity)
        {
            EcomDbContext.Instance.Set<T>().AddAsync(entity);
        }

        public void CreateList(List<T> entity)
        {
            EcomDbContext.Instance.Set<T>().AddRangeAsync(entity);
        }

        public void Update(T entity)
        {
            EcomDbContext.Instance.Set<T>().Update(entity);
        }

        public void Update(T entity, string[] columns)
        {
            EcomDbContext.Instance.Entry(entity).State = EntityState.Modified;
            string[] parameter = typeof(T).GetProperties().Where(x => x.PropertyType.Name != x.Name && !x.PropertyType.FullName.StartsWith("System.Collections.Generic")).Select(x => x.Name).Where(x => !columns.Contains(x)).ToArray();
            foreach (string property in parameter)
            {
                EcomDbContext.Instance.Entry(entity).Property(property).IsModified = false;
            }
        }

        public void Update(T entity, bool isInclude, string[] columns, string[] notMapped = null)
        {
            if (EcomDbContext.Instance.Entry(entity).State == EntityState.Detached)
                EcomDbContext.Instance.Attach(entity);

            EcomDbContext.Instance.Entry(entity).State = EntityState.Modified;

            string[] param = null;
            if (isInclude)
                param = typeof(T).GetProperties().Select(x => x.Name).Where(x => !columns.Contains(x)).ToArray();
            else
                param = columns;

            List<string> columnList = null;
            if (notMapped != null)
                columnList = param.ToList().Where(x => !notMapped.Contains(x)).ToList();
            else
                columnList = param.ToList();

            foreach (string exc in columnList)
            {
                EcomDbContext.Instance.Entry(entity).Property(exc).IsModified = false;
            }
        }
        public void UpdateEntity(T entity)
        {
            EcomDbContext.Instance.Entry(entity).State = EntityState.Modified;
            EcomDbContext.Instance.Set<T>().Update(entity);
            EcomDbContext.Instance.SaveChanges();
        }
        public void UpdateList(List<T> entity)
        {
            EcomDbContext.Instance.Set<T>().UpdateRange(entity);
        }
        public virtual void Delete(T entity)
        {
            EcomDbContext.Instance.Set<T>().Remove(entity);
        }

        public void DeleteList(List<T> entity)
        {
            EcomDbContext.Instance.Set<T>().RemoveRange(entity);
        }

        public int ExecuteSql(string sql, Dictionary<string, object> arguement)
        {
            List<SqlParameter> param = new List<SqlParameter>();
            if (arguement != null)
            {
                foreach (var arg in arguement)
                {
                    param.Add(new SqlParameter(arg.Key, arg.Value));
                }
            }

            return EcomDbContext.Instance.Database.ExecuteSqlRaw(sql, param);
        }
        public int Commit()
        {
            return EcomDbContext.Instance.SaveChanges();
        }

        public async Task<int> CommitAsync()
        {
            Task<int> rowAffected = Task.FromResult<int>(0);
            rowAffected = EcomDbContext.Instance.SaveChangesAsync();
            return await rowAffected;
        }

        private void SetReadSettings()
        {
            EcomDbContext.Instance.Database.AutoTransactionsEnabled = false;
            
        }
    }
}
