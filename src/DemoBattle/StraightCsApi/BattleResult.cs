using System.Collections.Generic;

namespace StraightCsApi
{
    public class BattleResult
    {
        public string ResultMessage { get; set; }

        public List<Fighter> FightersLeftStanding { get; set; }
    }
}