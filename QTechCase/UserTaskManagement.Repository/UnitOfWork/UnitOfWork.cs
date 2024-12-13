using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserTaskManagement.Core.UnitOfWork;

namespace UserTaskManagement.Repository.UnitOfWork
{
    public class UnitOfWork(DataContext dataContext) : IUnitOfWork
    {
        private readonly DataContext _dataContext = dataContext;

        public void Commit()
        {
            _dataContext.SaveChanges();
        }
        public async Task CommitAsync()
        {
            await _dataContext.SaveChangesAsync();
        }
    }
}
