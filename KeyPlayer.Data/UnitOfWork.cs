using KeyPlayer.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyPlayer.Data
{
    public interface IUnitOfWork : IDisposable
    {
        bool SaveChanges();
    }





    class UnitOfWork : IUnitOfWork
    {
        private readonly KeyPlayerContext _ctx;
        private bool _disposed;

        public UnitOfWork(KeyPlayerContext ctx, 
                          ITeamRepository teamRepository, 
                          IPlayerRepository playerRepository)
        {
            _ctx = ctx;

            PlayerRepository = playerRepository;
            TeamRepository = teamRepository;
        }

        public IPlayerRepository PlayerRepository { get; private set; }
        public ITeamRepository TeamRepository { get; private set; }


        ~UnitOfWork()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (_disposed)
                throw new ObjectDisposedException("UnitOfWork");

            _ctx.Dispose();

            _disposed = true;

        }

        public bool SaveChanges()
        {
            return _ctx.SaveChanges() > 0;
        }        
    }

    
}
