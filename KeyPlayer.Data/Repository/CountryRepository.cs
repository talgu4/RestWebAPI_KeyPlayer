﻿using KeyPlayer.Data.Entities;
using KeyPlayer.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyPlayer.Data.Repository
{ 
    public class CountryRepository : BaseRepository<Country>, ICountryRepository
    {
        public CountryRepository(IDbFactory dbFactory)
            : base(dbFactory) { }
    }

    public interface ICountryRepository : IRepository<Country>
    {

    }
}
