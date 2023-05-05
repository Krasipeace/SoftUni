namespace Blog.Common
{
    public static class ValidationConstants
    {
        // Application User Validation Constants
        public const int USERNAMEMINLENGTH = 5;
        public const int USERNAMEMAXLENGTH = 20;

        public const int EMAILMINLENGTH = 10;
        public const int EMAILMAXLENGTH = 50;

        public const int PASSWORDMINLENGTH = 5;
        public const int PASSWORDMAXLENGTH = 256;
        public const int PASSWORDSALTLENGTH = 256;

        // Article Validation Constants
        public const int TITLEMINLENGTH = 10;
        public const int TITLEMAXLENGTH = 50;

        public const int CONTENTMINLENGTH = 50;
        public const int CONTENTMAXLENGTH = 1500;

        public const int GENRELENGTH = 30;
    }
}
