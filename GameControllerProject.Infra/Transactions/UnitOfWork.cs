using GameControllerProject.Infra.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameControllerProject.Infra.Transactions
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GameControllerProjectContext _context;

        public UnitOfWork(GameControllerProjectContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
