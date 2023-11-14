function getStudentClassifyByGrade(grade) {
    if (grade < 3.00) {
        return 'Fail (2)';
    } else if (grade < 3.50) {
        return `Poor (${grade.toFixed(2)})`;
    } else if (grade < 4.50) {
        return `Good (${grade.toFixed(2)})`;
    } else if (grade < 5.50) {
        return `Very good (${grade.toFixed(2)})`;
    } else {
        return `Excellent (${grade.toFixed(2)})`;
    }
}

console.log(getStudentClassifyByGrade(3.33)); // Poor (3.33)
console.log(getStudentClassifyByGrade(4.50)); // Very good (4.50)
console.log(getStudentClassifyByGrade(2.99)); // Fail (2)