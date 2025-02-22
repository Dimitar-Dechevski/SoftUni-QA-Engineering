using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamworkProjects
{
    internal class Team
    {
        public string TeamCreator { get; set; }
        public string TeamName { get; set; }
        public List<string> Members { get; set; }

        public Team(string teamOwner, string teamName, List<string> members)
        {
            TeamCreator = teamOwner;
            TeamName = teamName;
            Members = members;
        }

    }
}
