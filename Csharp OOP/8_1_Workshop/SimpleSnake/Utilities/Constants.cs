using System;

namespace SimpleSnake.Utilities
{
    public class Constants
    {
        // Engine
        public const double DEFAULT_SLEEP_TIME = 100;
        public const double DIFFICULTY_STEP_EASY = 0.01;
        public const double DIFFICULTY_STEP_MEDIUM = 0.03;
        public const double DIFFICULTY_STEP_HARD = 0.05;

        // Snake
        public const int SNAKE_START_TOP_Y = 1;
        public const int SNAKE_START_LENGTH = 6;
        public const int SNAKE_END_TOP_Y = SNAKE_START_TOP_Y + SNAKE_START_LENGTH;
        public const char SNAKE_SYMBOL = '\u25CF';
        public const char EMPTY_SPACE = ' ';

        // Food Asterisk
        public const char FOOD_ASTERISK_SYMBOL = '*';
        public const int FOOD_ASTERISK_POINTS = 1;
        public const ConsoleColor FOOD_ASTERISK_COLOR = ConsoleColor.Red;

        // Food Dollar
        public const char FOOD_DOLLAR_SYMBOL = '$';
        public const int FOOD_DOLLAR_POINTS = 2;
        public const ConsoleColor FOOD_DOLLAR_COLOR = ConsoleColor.Green;

        // Food Hash
        public const char FOOD_HASH_SYMBOL = '#';
        public const int FOOD_HASH_POINTS = 3;
        public const ConsoleColor FOOD_HASH_COLOR = ConsoleColor.DarkYellow;

        // Food Percent
        public const char FOOD_PERCENT_SYMBOL = '%';
        public const int FOOD_PERCENT_POINTS = 4;
        public const ConsoleColor FOOD_PERCENT_COLOR = ConsoleColor.Magenta;

        // Wall
        public const char WALL_SYMBOL = '\u25A0';
    }
}
