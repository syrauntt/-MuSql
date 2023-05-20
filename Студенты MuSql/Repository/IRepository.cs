using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Студенты_MuSql.Repository
{
    internal interface IRepository<T>
    {
            List<T> GetAll();
            int Insert(T value);
            int Update(int id, T value);
    }
}
