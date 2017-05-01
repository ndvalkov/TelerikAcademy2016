function solve() {
    let library = (function () {
        const AUTHOR = 'author';
        const TITLE = 'title';
        const ISBN = 'isbn';
        const CATEGORY = 'category';
        const VALID_TITLE_PATTERN = /^.{2,100}$/;
        const VALID_CATEGORY_PATTERN = VALID_TITLE_PATTERN;
        const VALID_ISBN_PATTERN = /^\d\d\d\d\d\d\d\d\d\d$|^\d\d\d\d\d\d\d\d\d\d\d\d\d$/;

        let books = [];
        let categories = [];

        function listBooks() {
            const options = arguments[0];

            let result = [];

            books.forEach(function (element) {
                result.push(JSON.parse(JSON.stringify(element)));
            });

            result = result.sort(function (a, b) {
                return a.ID < b.ID;
            });

            if (typeof(options) !== 'object') {
                // no optional sorting
            } else if (options.hasOwnProperty(AUTHOR)) {
                // filter by author
                result = result.filter(function (a) {
                    return a[AUTHOR] === options[AUTHOR];
                });
            } else if (options.hasOwnProperty(CATEGORY)) {
                // filter by category
                result = result.filter(function (a) {
                    return a[CATEGORY] === options[CATEGORY];
                });
            }

            return result;
        }

        function addBook(book) {
            if (book === undefined) {
                throw 'Error, book undefined';
            }

            if (!book.hasOwnProperty(AUTHOR) ||
                !book.hasOwnProperty(TITLE) ||
                !book.hasOwnProperty(ISBN) ||
                !book.hasOwnProperty(CATEGORY)) {
                throw 'Error, book property missing';
            }

            if (typeof(book[TITLE]) !== 'string' || book[TITLE].trim().length === 0) {
                throw 'Error, invalid title';
            }

            if (typeof(book[AUTHOR]) !== 'string' || book[AUTHOR].trim().length === 0) {
                throw 'Error, invalid author';
            }

            if (typeof(book[CATEGORY]) !== 'string' || book[CATEGORY].trim().length === 0) {
                throw 'Error, invalid category';
            }

            if (!book[ISBN].match(VALID_ISBN_PATTERN)) {
                throw 'Error, invalid ISBN';
            }

            if (!book[TITLE].match(VALID_TITLE_PATTERN)) {
                throw 'Error, invalid title';
            }

            if (!book[CATEGORY].match(VALID_CATEGORY_PATTERN)) {
                throw 'Error, invalid category';
            }

            books.forEach(function (element) {
                if (element[TITLE] === book[TITLE]) {
                    throw 'Error, book with same title already exists';
                }

                if (element[ISBN] === book[ISBN]) {
                    throw 'Error, book with ISBN already exists';
                }
            });

            if (!categories.includes(book[CATEGORY])) {
                categories.push(book[CATEGORY]);
            }

            book.ID = books.length + 1;

            books.push(book);

            let result = JSON.parse(JSON.stringify(book));

            return result;
        }

        function listCategories() {
            return categories;
        }

        return {
            books: {
                list: listBooks,
                add: addBook
            },
            categories: {
                list: listCategories
            }
        };
    }());

    return library;
}