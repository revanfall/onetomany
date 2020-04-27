using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onetomany
{
    class Program
    {
        static void Main(string[] args)
        {
            using (SoccerContext db = new SoccerContext()) {
                Team t1 = new Team { Name = "Real Madrid" };
                Team t2 = new Team { Name = "Liverpool" };
                db.Teams.Add(t1);
                db.Teams.Add(t2);
                db.SaveChanges();
                Player p1 = new Player { Name = "Eden Hazard", Age = 27, TeamId = t1.Id };
                Player p2 = new Player { Name = "Sadio Mane", Age = 25, TeamId = t2.Id };
                Player p3 = new Player { Name = "Karim Benzema", Age = 31, TeamId = t1.Id };
                Player p4 = new Player { Name = "Van Dijk", Age = 26, TeamId = t2.Id };
                Player p5 = new Player { Name = "Modric", Age = 33, TeamId = t1.Id };
                db.Players.AddRange(new List<Player> { p1, p2, p3, p4, p5 });
                db.SaveChanges();

                var players = from p in db.Players.Include("Team") orderby p.Team.Name select p;
                foreach(var player in players)
                    Console.WriteLine($"{player.Team.Name}-{player.Name}-{player.Age}");
            }
        }
    }
}
