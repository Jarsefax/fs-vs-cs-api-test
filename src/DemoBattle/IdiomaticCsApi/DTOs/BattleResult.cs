namespace IdiomaticCsApi.DTOs
{
    public class BattleResult
    {
        public string ResultMessage { get; set; }
        public object FightersLeftStanding { get; internal set; }
    }
}