function softuniStudents(input) {
    let courses = {};

    for (let line of input) {
        if (line.includes(': ')) {
            let [course, capacity] = line.split(': ');
            createCourse(courses, course, capacity);
        } else {
            let [name, rest] = line.split('[');
            let [credits, email] = rest.split('] with email ');
            let course = line.split(' with email ')[1].split(' joins ')[1];
            addStudentToCourse(courses, name, credits, email, course);
        }
    }

    let sortedCourses = sortCourses(courses);
    printCourses(sortedCourses);

    function createCourse(courses, course, capacity) {
        if (!courses.hasOwnProperty(course)) {
            courses[course] = { capacity: Number(capacity), students: [] };
        }
    }

    function addStudentToCourse(courses, name, credits, email, courseName) {
        for (let course in courses) {
            if (course === courseName) {
                if (courses[course].capacity > 0) {
                    courses[course].students.push({ name, credits: credits, email });
                    courses[course].capacity--;
                }
            }
        }
    }

    function sortCourses(courses) {
        return Object.entries(courses).sort((a, b) => b[1].students.length - a[1].students.length); // count DESC
    }

    function printCourses(sortedCourses) {
        for (let [courseName, course] of sortedCourses) {
            console.log(`${courseName}: ${course.capacity} places left`);
            course.students.sort((a, b) => b.credits - a.credits); // credits DESC

            for (let student of course.students) {
                console.log(`--- ${student.credits}: ${student.name}, ${student.email.split(' joins ')[0]}`);
            }
        }
    }
}

softuniStudents([
    'JavaBasics: 2', 'user1[25] with email user1@user.com joins C#Basics', 'C#Advanced: 3', 'JSCore: 4', 'user2[30] with email user2@user.com joins C#Basics', 'user13[50] with email user13@user.com joins JSCore', 'user1[25] with email user1@user.com joins JSCore', 'user8[18] with email user8@user.com joins C#Advanced', 'user6[85] with email user6@user.com joins JSCore', 'JSCore: 2', 'user11[3] with email user11@user.com joins JavaBasics', 'user45[105] with email user45@user.com joins JSCore', 'user007[20] with email user007@user.com joins JSCore', 'user700[29] with email user700@user.com joins JSCore', 'user900[88] with email user900@user.com joins JSCore'
]);
// JSCore: 0 places left
// --- 105: user45, user45@user.com
// --- 85: user6, user6@user.com
// --- 50: user13, user13@user.com
// --- 29: user700, user700@user.com
// --- 25: user1, user1@user.com
// --- 20: user007, user007@user.com
// JavaBasics: 1 places left
// --- 3: user11, user11@user.com
// C#Advanced: 2 places left
// --- 18: user8, user8@user.com
console.log(' ');
softuniStudents([
    'JavaBasics: 15',
    'user1[26] with email user1@user.com joins JavaBasics',
    'user2[36] with email user11@user.com joins JavaBasics',
    'JavaBasics: 5',
    'C#Advanced: 5',
    'user1[26] with email user1@user.com joins C#Advanced',
    'user2[36] with email user11@user.com joins C#Advanced',
    'user3[6] with email user3@user.com joins C#Advanced',
    'C#Advanced: 1',
    'JSCore: 8',
    'user23[62] with email user23@user.com joins JSCore'
]);
// C#Advanced: 3 places left
// --- 36: user2, user11@user.com
// --- 26: user1, user1@user.com
// --- 6: user3, user3@user.com
// JavaBasics: 18 places left
// --- 36: user2, user11@user.com
// --- 26: user1, user1@user.com
// JSCore: 7 places left
// --- 62: user23, user23@user.com