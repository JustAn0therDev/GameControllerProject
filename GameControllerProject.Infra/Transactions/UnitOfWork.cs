using GameControllerProject.Infra.Persistence;

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
