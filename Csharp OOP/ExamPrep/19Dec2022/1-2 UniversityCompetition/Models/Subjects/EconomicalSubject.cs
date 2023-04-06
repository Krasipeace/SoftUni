using UniversityCompetition.Utilities;

namespace UniversityCompetition.Models.Subjects
{
    public class EconomicalSubject : Subject
    {
        public EconomicalSubject(int subjectId, string subjectName) 
            : base(subjectId, subjectName, Constants.ECONOMICAL_SUBJECT_RATE) { }
    }
}
