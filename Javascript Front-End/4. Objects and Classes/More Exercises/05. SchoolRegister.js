function getSchoolRegister(studentData) {
    let schoolRegister = [];

    function getStudentData(data) {
        let [nameToken, gradeToken, scoreToken] = data.split(', ');
        let name = nameToken.split(': ')[1];
        let grade = Number(gradeToken.split(': ')[1]) + 1;
        let score = Number(scoreToken.split(': ')[1]);

        return { name, grade, score };
    }

    function addToRegister(schoolRegister, student) {
        if (student.score >= 3) {
            let gradeIndex = schoolRegister.findIndex(g => g.grade === student.grade);
            if (gradeIndex === -1) {
                schoolRegister.push({
                    grade: student.grade, students: [student]
                });
            } else {
                schoolRegister[gradeIndex].students.push(student);
            }
        }

        return schoolRegister;
    }

    function sortRegister(schoolRegister) {
        return schoolRegister.sort((a, b) => a.grade - b.grade);
    }

    function getAverageGrade(students) {
        let sum = students.reduce((total, student) => total + student.score, 0);
        
        return (sum / students.length).toFixed(2);
    }

    function printRegister(schoolRegister) {
        for (let gradeData of schoolRegister) {
            console.log(`${gradeData.grade} Grade`);
            console.log(`List of students: ${gradeData.students.map(s => s.name).join(', ')}`);
            console.log(`Average annual score from last year: ${getAverageGrade(gradeData.students)}`);
            console.log();
        }
    }

    for (let data of studentData) {
        let student = getStudentData(data);
        schoolRegister = addToRegister(schoolRegister, student);
    }

    schoolRegister = sortRegister(schoolRegister);
    printRegister(schoolRegister);
}


getSchoolRegister([
    'Student name: George, Grade: 5, Graduated with an average score: 2.75',
    'Student name: Alex, Grade: 9, Graduated with an average score: 3.66',
    'Student name: Peter, Grade: 8, Graduated with an average score: 2.83',
    'Student name: Boby, Grade: 5, Graduated with an average score: 4.20',
    'Student name: John, Grade: 9, Graduated with an average score: 2.90',
    'Student name: Steven, Grade: 2, Graduated with an average score: 4.90',
    'Student name: Darsy, Grade: 1, Graduated with an average score: 5.15'
]);
// 2 Grade
// List of students: Darsy
// Average annual score from last year: 5.15

// 3 Grade
// List of students: Steven
// Average annual score from last year: 4.90

// 6 Grade
// List of students: Boby
// Average annual score from last year: 4.20

// 10 Grade
// List of students: Alex
// Average annual score from last year: 3.66