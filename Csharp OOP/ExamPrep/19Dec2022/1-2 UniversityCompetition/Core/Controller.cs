using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UniversityCompetition.Core.Contracts;
using UniversityCompetition.Models;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Models.Subjects;
using UniversityCompetition.Repositories;
using UniversityCompetition.Utilities.Messages;

namespace UniversityCompetition.Core
{
    internal class Controller : IController
    {
        private SubjectRepository subjects;
        private StudentRepository students;
        private UniversityRepository universities;

        public Controller()
        {
            subjects = new SubjectRepository();
            students = new StudentRepository();
            universities = new UniversityRepository();
        }

        public string AddStudent(string firstName, string lastName)
        {
            string fullName = $"{firstName} {lastName}";
            IStudent student = students.FindByName(fullName);

            if (student != null)
            {
                return string.Format(OutputMessages.AlreadyAddedStudent, firstName, lastName);
            }

            student = new Student(students.Models.Count + 1, firstName, lastName);
            students.AddModel(student);

            return string.Format(OutputMessages.StudentAddedSuccessfully, firstName, lastName, students.GetType().Name);
        }

        public string AddSubject(string subjectName, string subjectType)
        {
            if (subjectType != nameof(EconomicalSubject) && subjectType != nameof(TechnicalSubject) && subjectType != nameof(HumanitySubject))
            {
                return string.Format(OutputMessages.SubjectTypeNotSupported, subjectType);
            }

            ISubject subject = subjects.FindByName(subjectName);

            if (subject != null)
            {
                return string.Format(OutputMessages.AlreadyAddedSubject, subjectName);
            }

            switch (subjectType)
            {
                case "EconomicalSubject":
                    subject = new EconomicalSubject(subjects.Models.Count + 1, subjectName);
                    subjects.AddModel(subject);
                    break;
                case "HumanitySubject":
                    subject = new HumanitySubject(subjects.Models.Count + 1, subjectName);
                    subjects.AddModel(subject);
                    break;
                case "TechnicalSubject":
                    subject = new TechnicalSubject(subjects.Models.Count + 1, subjectName);
                    subjects.AddModel(subject);
                    break;
            }

            return string.Format(OutputMessages.SubjectAddedSuccessfully, subjectType, subjectName, subjects.GetType().Name);
        }

        public string AddUniversity(string universityName, string category, int capacity, List<string> requiredSubjects)
        {
            IUniversity university = universities.FindByName(universityName);

            if (university != null)
            {
                return string.Format(OutputMessages.AlreadyAddedUniversity, universityName);
            }

            List<int> requiredSubjectIds = requiredSubjects
                .Select(requiredSubject => subjects.FindByName(requiredSubject))
                .Select(s => s.Id)
                .ToList();

            university = new University(universities.Models.Count + 1, universityName, category, capacity, requiredSubjectIds);
            universities.AddModel(university);

            return string.Format(OutputMessages.UniversityAddedSuccessfully, universityName, universities.GetType().Name);
        }

        public string ApplyToUniversity(string studentName, string universityName)
        {
            string[] nameParts = studentName.Split(" ");
            IStudent student = students.FindByName(studentName);

            if (student == null)
            {
                return string.Format(OutputMessages.StudentNotRegitered, nameParts[0], nameParts[1]);
            }

            IUniversity university = universities.FindByName(universityName);

            if (university == null)
            {
                return string.Format(OutputMessages.UniversityNotRegitered, universityName);
            }

            if (university.RequiredSubjects.Any(uniReqSubject => !student.CoveredExams.Contains(uniReqSubject)))
            {
                return string.Format(OutputMessages.StudentHasToCoverExams, studentName, universityName);
            }

            if (student.University != null && student.University.Name == universityName)
            {
                return string.Format(OutputMessages.StudentAlreadyJoined, nameParts[0], nameParts[1], universityName);
            }

            student.JoinUniversity(university);

            return string.Format(OutputMessages.StudentSuccessfullyJoined, nameParts[0], nameParts[1], universityName);
        }

        public string TakeExam(int studentId, int subjectId)
        {
            IStudent student = students.FindById(studentId);
            ISubject subject = subjects.FindById(subjectId);

            if (student == null)
            {
                return OutputMessages.InvalidStudentId;
            }

            if (subject == null)
            {
                return OutputMessages.InvalidSubjectId;
            }

            if (student.CoveredExams.Contains(subjectId))
            {
                return string.Format(OutputMessages.StudentAlreadyCoveredThatExam, student.FirstName, student.LastName, subject.Name);
            }

            student.CoverExam(subject);

            return string.Format(OutputMessages.StudentSuccessfullyCoveredExam, student.FirstName, student.LastName, subject.Name);
        }

        public string UniversityReport(int universityId)
        {
            var university = universities.FindById(universityId);
            StringBuilder sb = new StringBuilder();

            sb
                .AppendLine($"*** {university.Name} ***")
                .AppendLine($"Profile: {university.Category}")
                .AppendLine($"Students admitted: {students.Models.Where(s => s.University == university).Count()}")
                .AppendLine($"University vacancy: {university.Capacity - students.Models.Where(s => s.University == university).Count()}");

            return sb.ToString().TrimEnd();
        }
    }
}
