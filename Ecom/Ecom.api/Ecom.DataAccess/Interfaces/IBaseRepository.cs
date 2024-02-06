using Ecom.DataAccess.DBContext.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.DataAccess.Interfaces
{
    public interface IBaseRepository<T>
    {
        IEcomDbContext EcomDbContext { get; }
        Task<List<T>> List();
        Task<List<DTO>> List<DTO>(Expression<Func<T, DTO>> select);
        Task<T> First(Expression<Func<T, bool>> predicate);
        Task<DTO> First<DTO>(Expression<Func<T, bool>> predicate, Expression<Func<T, DTO>> select);
        Task<List<T>> Where(Expression<Func<T, bool>> predicate);
        Task<List<DTO>> Where<DTO>(Expression<Func<T, bool>> predicate, Expression<Func<T, DTO>> select);
        void Create(T entity);
        void CreateList(List<T> entity);
        void Update(T entity);
        void Update(T entity, string[] columns);
        void Update(T entity, bool isInclude, string[] columns, string[] notMapped = null);
        void UpdateList(List<T> entity);
        void Delete(T entity);
        void DeleteList(List<T> entity);
        int Commit();
        Task<int> CommitAsync();
        int ExecuteSql(string sql, Dictionary<string, object> arguement);
        void UpdateEntity(T entity);
    }
}
