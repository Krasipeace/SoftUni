namespace P01_StudentSystem.Data.Common;

public class ValidationConstants
{
    // Student
    public const int STUDENT_NAME_MAX_LENGTH = 100;
    public const int STUDENT_PHONENUMBER_MAX_LENGTH = 10;
    
    // Course
    public const int COURSE_NAME_MAX_LENGTH = 80;
    public const int COURSE_DESCRIPTION_MAX_LENGTH = 9999;

    // Resource 
    public const int RESOURCE_NAME_MAX_LENGTH = 50;
    public const int RESOURCE_URL_MAX_LENGTH = 2048;

    // Homework
    public const int HOMEWORK_CONTENT_MAX_LENGTH = 2048;
}
