namespace FootballTeamGenerator
{
    public static class ExceptionMessages
    {
        public const string NAME_CANNOT_BE_NULL_OR_WHITESPACE = "A name should not be empty.";
        public const string STATS_MUST_BE_0_TO_100 = "{0} should be between 0 and 100.";
        public const string PLAYER_CANNOT_BE_REMOVED = "Player {0} is not in {1} team.";
        public const string TEAM_DOES_NOT_EXIST = "Team {0} does not exist.";
    }
}
