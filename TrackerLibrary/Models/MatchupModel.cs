using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary.Models
{
    public class MatchupModel
    {
        /// <summary>
        /// Represents the matchups
        /// </summary>
        public List<MatchupEntryModel> Entries { get; set; } = new List<MatchupEntryModel>();

        /// <summary>
        /// Represents the winner of this match
        /// </summary>
        public TeamModel Winner { get; set; }

        /// <summary>
        /// Represents the round of this match
        /// </summary>
        public int MatchupRound { get; set; }
    }
}
