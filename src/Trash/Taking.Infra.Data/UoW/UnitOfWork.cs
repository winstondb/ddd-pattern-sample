using System;
using Taking.Infra.Data.Context;
using Taking.Infra.Data.Interfaces;

namespace Taking.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TakingContext _context;
        private bool _disposed;

        public UnitOfWork(TakingContext context)
        {
            _context = context;
        }

        public void BeginTransaction()
        {
            _disposed = false;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void RollBack()
        {
            _disposed = false;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
