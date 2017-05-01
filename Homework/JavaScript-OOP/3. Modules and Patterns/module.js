function solve() {
	const VALID_TITLE_PATTERN = /^([\S]+\s?)*\S$/g;
	const VALID_NAME_PATTERN = /^[A-Z][a-z]*$/g;

	let _title;
	let _presentations;
	let _students = [];
	let _homeworks = [];

	let Course = {

		init: function(title, presentations) {
            if (typeof(title) !== 'string') {
            	throw 'Error, invalid title argument';
			}

			if (!title.match(VALID_TITLE_PATTERN)) {
                throw 'Error, invalid title';
			}

            if (!Array.isArray(presentations) || presentations.length === 0) {
                throw 'Error, invalid presentations argument';
            }

            presentations.forEach(function (element) {
				if (typeof(element) !== 'string' ||
					!element.match(VALID_TITLE_PATTERN)) {
                    throw 'Error, invalid presentation title';
				}
            });

			_title = title;
            _presentations = presentations;
		},
		addStudent: function(name) {
            if (typeof(name) !== 'string' || name.trim().length === 0) {
                throw 'Error, invalid name argument';
            }

            const names = name.split(' ');
            if (names.length > 2) {
                throw 'Error, more than 2 names';
			}

            let firstName = names[0];
            let lastName = names[1];

			if (!firstName.match(VALID_NAME_PATTERN) || !lastName.match(VALID_NAME_PATTERN)) {
                throw 'Error, invalid first or last name';
            }

            let student = {
                ID: _students.length + 1,
                firstname: firstName,
                lastname: lastName
            };

			_students.push(student);

			return student.ID;
		},
		getAllStudents: function() {
			let result = [];

			_students.forEach(function (student) {
                result.push({
                    firstname: student.firstname,
                    lastname: student.lastname,
                    id: student.ID
                });
            });

			return result;
		},
		submitHomework: function(studentID, homeworkID) {
			if (!Number.isInteger(studentID) || !Number.isInteger(homeworkID)) {
				throw 'Argument must be an integer';
			}

			if (homeworkID < 1 || homeworkID > _presentations.length) {
                throw 'Invalid homework id';
			}

			let student = _students.find(function (element) {
				return element.ID === studentID;
            });

			if (!student) {
                throw 'Invalid student id';
			}

			_homeworks.push({
				studentID: studentID,
                homeworkID: homeworkID
			});
		},
		pushExamResults: function(results) {
			/*if (!Array.isArray(results)) {
				throw 'Invalid argument results';
			}

            results.forEach(function (result) {
				if (!result.hasOwnProperty('StudentID') || !result.hasOwnProperty('score')) {
                    throw 'Invalid argument';
				}

                let score = +result['score'];
				let studentId = +result['StudentID'];

				if (Number.isNaN(score) || Number.isNaN(studentId)) {
                    throw 'Invalid value for score and studentId, must be numbers';
				}

                let student = _students.find(function (st) {
                    return st.ID === studentId;
                });

                if (!student) {
                    throw 'Invalid student id';
                }

                student.score = score;
            });

			// not listed get 0
            _students.forEach(function (st) {
                if (!st.hasOwnProperty('score')) {
                    st.score = 0;
                }
            });*/
		},
		getTopStudents: function() {

		}
	};

	return Course;
}