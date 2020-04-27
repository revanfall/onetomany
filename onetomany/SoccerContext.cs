﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onetomany
{
    class SoccerContext:DbContext
    {
        public SoccerContext():base("SoccerContext"){}

        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
    }
}
