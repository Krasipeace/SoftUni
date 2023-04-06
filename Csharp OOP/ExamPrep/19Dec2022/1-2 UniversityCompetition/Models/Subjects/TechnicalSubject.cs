using UniversityCompetition.Utilities;

namespace UniversityCompetition.Models.Subjects
{
    public class TechnicalSubject : Subject
    {
        public TechnicalSubject(int subjectId, string subjectName) 
            : base(subjectId, subjectName, Constants.TECHNICAL_SUBJECT_RATE) { }
    }
}
