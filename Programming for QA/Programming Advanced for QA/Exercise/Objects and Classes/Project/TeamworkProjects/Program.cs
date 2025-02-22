using System.Text;

namespace TeamworkProjects
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Team> teams = new List<Team>();
            List<Team> disbandTeams = new List<Team>();

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split("-", StringSplitOptions.RemoveEmptyEntries);
                string teamCreator = tokens[0];
                string teamName = tokens[1];

                if (teams.Any(t => t.TeamName.Equals(teamName)))
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                }
                else if (teams.Any(t => t.TeamCreator.Equals(teamCreator)))
                {
                    Console.WriteLine($"{teamCreator} cannot create another team!");
                }
                else
                {
                    Team team = new Team(teamCreator, teamName, new List<string>());
                    teams.Add(team);
                    Console.WriteLine($"Team {teamName} has been created by {teamCreator}!");
                }
            }

            string input = Console.ReadLine();

            while (!input.Equals("end of assignment"))
            {
                string[] data = input.Split("->", StringSplitOptions.RemoveEmptyEntries);
                string memberName = data[0];
                string nameTeam = data[1];

                if (!teams.Any(t => t.TeamName.Equals(nameTeam)))
                {
                    Console.WriteLine($"Team {nameTeam} does not exist!");
                }
                else if (teams.Any(t => t.Members.Contains(memberName) || teams.Any(t => t.TeamCreator.Equals(memberName))))
                {
                    Console.WriteLine($"Member {memberName} cannot join team {nameTeam}!");
                }
                else
                {
                    Team teamToJoin = teams.First(t => t.TeamName.Equals(nameTeam));
                    teamToJoin.Members.Add(memberName);
                }

                input = Console.ReadLine();
            }

            disbandTeams = teams.Where(t => t.Members.Count == 0).ToList();
            disbandTeams = disbandTeams.OrderBy(t => t.TeamName).ToList();
            teams = teams.Where(t => t.Members.Count > 0).ToList();
            teams = teams.OrderByDescending(t => t.Members.Count()).ThenBy(t => t.TeamName).ToList();

            foreach (Team team in teams)
            {
                StringBuilder sb = new StringBuilder();

                sb.Append(team.TeamName).Append("\n");
                sb.Append($"- {team.TeamCreator}").Append("\n");
                team.Members = team.Members.OrderBy(t => t).ToList();
                foreach (string member in team.Members)
                {
                    sb.Append($"-- {member}").Append("\n");
                }

                Console.WriteLine(sb.ToString().Trim());
            }

            Console.WriteLine("Teams to disband:");

            foreach (Team team in disbandTeams)
            {
                Console.WriteLine(team.TeamName);
            }

        }
    }
}