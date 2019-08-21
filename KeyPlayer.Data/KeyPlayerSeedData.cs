using KeyPlayer.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyPlayer.Data
{
    public class KeyPlayerSeedData: DropCreateDatabaseIfModelChanges<KeyPlayerContext>
    {
        protected override void Seed(KeyPlayerContext context)
        {
            GetCountries().ForEach(g => context.Countries.Add(g));
            context.Commit();
            GetTeams().ForEach(g => context.Teams.Add(g));
            context.Commit();
            GetPlayers().ForEach(c => context.Players.Add(c));
            context.Commit();
        }

        private List<Team> GetTeams()
        {
            return new List<Team>
            {
                new Team
                {
                    Name= "Team1",
                    Color = ConsoleColor.Yellow,
                    CountryID= 1
                },
                new Team
                {
                    Name= "Team2",
                    Color = ConsoleColor.Green,
                    CountryID= 2
                },
                new Team
                {
                    Name= "Team3",
                    Color = ConsoleColor.Black,
                    CountryID= 2
                },
                new Team
                {
                    Name= "Team4",
                    Color = ConsoleColor.White,
                    CountryID= 1
                },
                new Team
                {
                    Name= "Team5",
                    Color = ConsoleColor.Gray,
                    CountryID= 1
                },
            };
        }

        private List<Country> GetCountries()
        {
            return new List<Country>
            {
                new Country
                {
                    Name = "Israel",
                    Color = ConsoleColor.Blue,
                },
                new Country
                {
                    Name = "England",
                    Color = ConsoleColor.White,
                },
                new Country
                {
                    Name = "Spain",
                    Color = ConsoleColor.Red,
                },
            };
        }

        private List<Player> GetPlayers()
        {
            return new List<Player>
            {
                new Player
                {
                    FirstName = "Tal",
                    Age = 21,
                    Position = Common.PlayerPosition.CM,
                    LastName = "Nahum",
                    TeamID = 3
                },
                new Player
                {
                    FirstName = "Sami",
                    Age = 21,
                    Position = Common.PlayerPosition.GK,
                    LastName = "Cohen",
                    TeamID = 1
                },
                new Player
                {
                    FirstName = "Dor",
                    Age = 21,
                    Position = Common.PlayerPosition.AMC,
                    LastName = "Micha",
                    TeamID = 1
                },
                new Player
                {
                    FirstName = "Dor",
                    Age = 22,
                    Position = Common.PlayerPosition.DL,
                    LastName = "Brown",
                    TeamID = 2
                },
                new Player
                {
                    FirstName = "Yoni",
                    Age = 23,
                    Position = Common.PlayerPosition.AML,
                    LastName = "Cohen",
                    TeamID = 3
                },
                new Player
                {
                    FirstName = "Yoni",
                    Age = 28,
                    Position = Common.PlayerPosition.DC,
                    LastName = "Bar",
                    TeamID = 2
                },
            };
        }
    }
}
