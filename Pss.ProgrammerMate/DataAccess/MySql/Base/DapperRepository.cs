using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pss.ProgrammerMate.DataAccess.MySql.Base
{
    public class DapperRepository<T> : IRepository<T>
    {
        private const string ConnString = "WorkForce360Context";
        private IDbConnection _connection;
        private Database _db;
        protected IDbConnection Db
        {
            get
            {
                var factory = new DatabaseProviderFactory();                                
                _db = factory.Create(ConnString);
                _connection = _db.CreateConnection();
                return _connection;
            }
        }
    }
}
