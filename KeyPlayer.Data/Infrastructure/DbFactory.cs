using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyPlayer.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        KeyPlayerContext dbContext;

        public KeyPlayerContext Init()
        {
            return dbContext ?? (dbContext = new KeyPlayerContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
