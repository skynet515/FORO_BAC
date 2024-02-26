using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DataBaseModel.Commands
{
    public class Commands
    {
        private readonly DbContext_Foro _dbContext;

        public Commands(DbContext_Foro dbContext)
        {
            _dbContext = dbContext;
        }

        public int ExecuteSqlCommand(string sql, params SqlParameter[] parameters)
        {
            return _dbContext.Database.ExecuteSqlRaw(sql, parameters);
        }

        public IEnumerable<T> ExecuteSqlCommand<T>(string sql, params SqlParameter[] parameters) where T : class
        {
            return _dbContext.Set<T>().FromSqlRaw(sql, parameters).AsEnumerable();
        }

        public List<T> ExecuteSqlCommandList<T>(string sql, params SqlParameter[] parameters) where T : class
        {
            return _dbContext.Set<T>().FromSqlRaw(sql, parameters).ToList();
        }
    }
}
