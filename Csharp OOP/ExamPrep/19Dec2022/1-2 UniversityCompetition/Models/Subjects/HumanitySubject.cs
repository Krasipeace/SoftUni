using UniversityCompetition.Utilities;

namespace UniversityCompetition.Models.Subjects
{
    public class HumanitySubject : Subject
    {
        public HumanitySubject(int subjectId, string subjectName) 
            : base(subjectId, subjectName, Constants.HUMANITY_SUBJECT_RATE) { }
    }
}
