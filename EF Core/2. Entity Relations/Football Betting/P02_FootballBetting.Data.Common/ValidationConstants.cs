namespace P02_FootballBetting.Data.Common;

public static class ValidationConstants
{
    // Team
    public const int TEAM_NAME_MAX_LENGTH = 50;
    public const int TEAM_LOGO_MAX_LENGTH = 2048;
    public const int TEAM_INITIALS_MAX_LENGTH = 4;

    // Color
    public const int COLOR_NAME_MAX_LENGTH = 10;

    // Town
    public const int TOWN_NAME_MAX_LENGTH = 58;
    
    // Country
    public const int COUNTRY_NAME_MAX_LENGTH = 56;

    // Player
    public const int PLAYER_NAME_MAX_LENGTH = 100;

    // Position
    public const int POSITION_NAME_MAX_LENGTH = 50;

    // Game
    public const int GAME_RESULT_MAX_LENGTH = 10;

    // User
    public const int USER_USERNAME_MAX_LENGTH = 36;
    public const int USER_PASSWORD_MAX_LENGTH = 256;
    public const int USER_EMAIL_MAX_LENGTH = 256;
    public const int USER_NAME_MAX_LENGTH = 100;
}
